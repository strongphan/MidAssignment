using AutoMapper;
using ManhPT_MidAssignment.Application.DTOs.BookDTOs;
using ManhPT_MidAssignment.Core.Entity;

namespace ManhPT_MidAssignment.Application.Mapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookCreateDTO, Book>();
        }
    }
}
