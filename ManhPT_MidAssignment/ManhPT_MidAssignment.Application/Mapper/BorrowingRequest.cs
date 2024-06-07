using AutoMapper;
using ManhPT_MidAssignment.Application.DTOs.BorrowingRequest;
using ManhPT_MidAssignment.Domain.Entity;

namespace ManhPT_MidAssignment.Application.Mapper
{
    public class BorrowingRequest : Profile
    {
        public BorrowingRequest()
        {
            CreateMap<BookBorrowingRequest, BorrowingRequestDTO>();
            CreateMap<BookBorrowingRequestDetails, BorrowingRequestDetailDTO>();
        }
    }
}
