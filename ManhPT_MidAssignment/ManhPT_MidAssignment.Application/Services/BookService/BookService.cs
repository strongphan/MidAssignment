using AutoMapper;
using ManhPT_MidAssignment.Application.Constacts;
using ManhPT_MidAssignment.Application.DTOs.BookDTOs;
using ManhPT_MidAssignment.Application.Service;
using ManhPT_MidAssignment.Core.Entity;

namespace ManhPT_MidAssignment.Application.Services.BookService
{
    public class BookService : BaseService<Book, BookDTO, BookCreateDTO>, IBookService
    {
        public BookService(IBookRepo repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override void ValidateDTO(BookCreateDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
