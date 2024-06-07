using AutoMapper;
using ManhPT_MidAssignment.Application.Common.Paging;
using ManhPT_MidAssignment.Application.DTOs.BorrowingRequest;
using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Application.IRpository;
using ManhPT_MidAssignment.Domain.Entity;
using ManhPT_MidAssignment.Domain.Enum;
using ManhPT_MidAssignment.Domain.Exceptions;

namespace ManhPT_MidAssignment.Application.Services.BorrowRequestService
{
    public class BorrowRequestService : IBorrowRequestService
    {
        private readonly IBookBorrowingRequestRepo _borrowingRequestRepo;
        private readonly IBookRepo _bookRepo;
        private readonly IMapper _mapper;

        public BorrowRequestService(IBookBorrowingRequestRepo borrowingRequestRepo, IBookRepo bookRepo, IMapper mapper)
        {
            _borrowingRequestRepo = borrowingRequestRepo;
            _bookRepo = bookRepo;
            _mapper = mapper;
        }
        public async Task<BorrowingRequestDTO> GetByIdAsync(Guid id)
        {
            var entity = await _borrowingRequestRepo.GetByIdAsync(id);
            if (entity == null)
            {
                throw new NotFoundException();
            }
            var dto = _mapper.Map<BorrowingRequestDTO>(entity);
            return dto;

        }
        public async Task<PaginationResponse<BorrowingRequestDTO>> GetRequestByRequestorIdAsync(FilterRequest filter, Guid id)
        {
            PaginationResponse<BookBorrowingRequest>? res = await _borrowingRequestRepo.GetRequestByRequestorIdAsync(filter, id);
            if (res == null)
            {
                throw new NotFoundException();
            }
            var dtos = _mapper.Map<IEnumerable<BorrowingRequestDTO>>(res.Data);
            return new(dtos, res.TotalCount);
        }
        public async Task<string> BorrowBooksAsync(Guid userId, string userName, List<Guid> bookIds)
        {
            if (bookIds.Count > 5)
            {
                throw new DataInvalidException("Cannot borrow more than 5 books in one request.");
            }

            HashSet<Guid> seen = [];
            foreach (var bookId in bookIds)
            {
                if (!seen.Add(bookId))
                {
                    throw new DataInvalidException("Duplicate book IDs found in the request.");
                }
            }
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;

            var userRequestsThisMonth = await _borrowingRequestRepo.GetRequestsByUserAndMonthAsync(
                userId,
                month,
                year
            );

            if (userRequestsThisMonth.Count >= 3)
            {
                throw new DataInvalidException("Limit of 3 borrowing requests per month exceeded.");
            }
            var id = Guid.NewGuid();
            var newRequest = new BookBorrowingRequest
            {

                Id = id,
                RequestorId = userId,
                DateRequested = DateTime.Now,
                Status = Status.Waiting,
                CreatedBy = userName,
                CreatedAt = DateTime.Now,
                BookBorrowingRequestDetails = bookIds
                    .Select(bookId => new BookBorrowingRequestDetails { BorrowingRequestId = id, BookId = bookId, Quantity = 1 })
                    .ToList()
            };

            await _borrowingRequestRepo.InsertAsync(newRequest);
            return $"Request submitted. Status: {newRequest.Status}";
        }

        public async Task<bool> UpdateRequestStatusAsync(Guid userId, string userName, Guid requestId, Status status)
        {
            var borrowingRequest = await _borrowingRequestRepo.GetByIdAsync(requestId);
            if (borrowingRequest == null)
            {
                throw new NotFoundException();
            }
            if (borrowingRequest.Status == Status.Waiting)
            {
                borrowingRequest.ApproverId = userId;
                borrowingRequest.Status = status;
                borrowingRequest.ModifiedBy = userName;
                borrowingRequest.ModifiedAt = DateTime.Now;

                if (status == Status.Approved)
                {
                    foreach (var detail in borrowingRequest.BookBorrowingRequestDetails)
                    {
                        var book = detail.Book;
                        if (book != null && book.AvailableCopies >= detail.Quantity)
                        {
                            book.AvailableCopies -= detail.Quantity;
                            book.Category = null;
                            await _bookRepo.UpdateAsync(book);
                        }
                        else
                        {
                            throw new DataInvalidException("Not enough copies available");
                        }
                    }
                }
                await _borrowingRequestRepo.UpdateAsync(borrowingRequest);
                return true;
            }
            return false;
        }
        public async Task<bool> ConfirmReturnedAsync(Guid userId, string userName, Guid requestId)
        {
            var borrowingRequest = await _borrowingRequestRepo.GetByIdAsync(requestId) ?? throw new NotFoundException();

            if (borrowingRequest.IsReturn == false)
            {
                borrowingRequest.IsReturn = true;
                borrowingRequest.ModifiedBy = userName;
                borrowingRequest.ModifiedAt = DateTime.Now;
                foreach (var detail in borrowingRequest.BookBorrowingRequestDetails)
                {
                    var book = detail.Book;
                    book.AvailableCopies += detail.Quantity;
                    book.Category = null;
                    await _bookRepo.UpdateAsync(book);
                }
                await _borrowingRequestRepo.UpdateAsync(borrowingRequest);
                return true;

            }
            return false;
        }
        public async Task<PaginationResponse<BorrowingRequestDTO>> GetRequestAsync(
            FilterRequest request
        )
        {
            var res = await _borrowingRequestRepo.GetRequestAsync(request);
            var dtos = _mapper.Map<IEnumerable<BorrowingRequestDTO>>(res.Data);
            return new(dtos, res.TotalCount);
        }

        public async Task<PaginationResponse<BorrowingRequestDTO>> GetRequestNotReturnedAsync(
            FilterRequest request
        )
        {
            var res = await _borrowingRequestRepo.GetRequestNotReturnedAsync(request);
            var dtos = _mapper.Map<IEnumerable<BorrowingRequestDTO>>(res.Data);
            return new(dtos, res.TotalCount);
        }
    }
}
