using AutoMapper;
using ManhPT_MidAssignment.Application.Common.Paging;
using ManhPT_MidAssignment.Application.DTOs.BorrowingRequest;
using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Application.IRpository;
using ManhPT_MidAssignment.Domain.Entity;
using ManhPT_MidAssignment.Domain.Enum;

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

        public async Task<string> BorrowBooksAsync(Guid userId, string userName, List<Guid> bookIds)
        {
            if (bookIds.Count > 5)
            {
                return "Cannot borrow more than 5 books in one request.";
            }

            var month = DateTime.Now.Month;

            var userRequestsThisMonth = await _borrowingRequestRepo.GetRequestsByUserAndMonthAsync(
                userId,
                month
            );

            if (userRequestsThisMonth.Count >= 3)
            {
                return "Limit of 3 borrowing requests per month exceeded.";
            }

            var newRequest = new BookBorrowingRequest
            {
                RequestorId = userId,
                DateRequested = DateTime.Now,
                Status = Status.Waiting,
                CreatedBy = userName,
                CreatedAt = DateTime.Now,
                BookBorrowingRequestDetails = bookIds
                    .Select(bookId => new BookBorrowingRequestDetails { BookId = bookId, })
                    .ToList()
            };

            _borrowingRequestRepo.InsertAsync(newRequest);
            return $"Request submitted. Status: {newRequest.Status}";
        }

        public async Task<bool> UpdateRequestStatus(Guid userId, string userName, Guid requestId, Status status)
        {
            var borrowingRequest = await _borrowingRequestRepo.GetByIdAsync(requestId);
            if (borrowingRequest == null)
            {
                throw new Exception("Not Found");
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
                        var book = await _bookRepo.GetByIdAsync(detail.BookId);
                        if (book != null && book.AvailableCopies >= detail.Quantity)
                        {
                            book.AvailableCopies -= detail.Quantity;
                            _bookRepo.UpdateAsync(book);
                        }
                        else
                        {
                            throw new Exception("Not enough copies available");
                        }
                    }
                }
                _borrowingRequestRepo.UpdateAsync(borrowingRequest);
                return true;
            }
            return false;
        }
        public async Task<bool> ConfirmReturned(Guid userId, string userName, Guid requestId)
        {
            var borrowingRequest = await _borrowingRequestRepo.GetByIdAsync(requestId) ?? throw new Exception("Not Found");
            if (borrowingRequest.IsReturn == false)
            {
                borrowingRequest.IsReturn = true;
                borrowingRequest.ModifiedBy = userName;
                borrowingRequest.ModifiedAt = DateTime.Now;
                foreach (var detail in borrowingRequest.BookBorrowingRequestDetails)
                {
                    var book = await _bookRepo.GetByIdAsync(detail.BookId);

                    book.AvailableCopies += detail.Quantity;
                    _bookRepo.UpdateAsync(book);
                }
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
            var res = await _borrowingRequestRepo.GetRequestAsync(request);
            var dtos = _mapper.Map<IEnumerable<BorrowingRequestDTO>>(res.Data);
            return new(dtos, res.TotalCount);
        }
    }
}
