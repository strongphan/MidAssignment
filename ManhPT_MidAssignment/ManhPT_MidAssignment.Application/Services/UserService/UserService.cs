using ManhPT_MidAssignment.Application.DTOs.AuthDTOs;
using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Application.IRpository;
using ManhPT_MidAssignment.Core.Entity;
using ManhPT_MidAssignment.Core.Enum;

namespace ManhPT_MidAssignment.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IBookBorrowingRequestRepo _borrowingRequestRepo;

        public UserService(IUserRepo userRepo, IBookBorrowingRequestRepo borrowingRequestRepo)
        {
            _userRepo = userRepo;
            _borrowingRequestRepo = borrowingRequestRepo;
        }
        public async Task<User> FindUserByEmailAsync(string email) => await _userRepo.FindUserByEmailAsync(email);

        public async Task<LoginResponse> LoginAsync(LoginDTO dto) => await _userRepo.LoginAsync(dto);

        public async Task<RegistrationResponse> RegisterAsync(RegisterUserDto dto) => await _userRepo.RegisterAsync(dto);
        public async Task<string> BorrowBooksAsync(Guid userId, string userName, List<Guid> bookIds)
        {
            if (bookIds.Count > 5)
            {
                return "Cannot borrow more than 5 books in one request.";
            }

            var month = DateTime.Now.Month;

            var userRequestsThisMonth = await _borrowingRequestRepo.GetRequestsByUserAndMonth(userId, month);

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
                BookBorrowingRequestDetails = bookIds.Select(bookId => new BookBorrowingRequestDetails
                {
                    BookId = bookId,
                }).ToList()
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
            if (borrowingRequest.Status != Status.Waiting)
            {
                borrowingRequest.Status = status;
                borrowingRequest.ModifiedBy = userName;
                borrowingRequest.ModifiedAt = DateTime.Now;
            }
            _borrowingRequestRepo.UpdateAsync(borrowingRequest);
            return true;
        }
    }
}
