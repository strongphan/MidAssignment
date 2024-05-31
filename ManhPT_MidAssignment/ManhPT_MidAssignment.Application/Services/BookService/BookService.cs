using AutoMapper;
using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Application.DTOs.BookDTOs;
using ManhPT_MidAssignment.Application.DTOs.Paging;
using ManhPT_MidAssignment.Application.Service;
using ManhPT_MidAssignment.Core.Entity;

namespace ManhPT_MidAssignment.Application.Services.BookService
{
    public class BookService(IBookRepo repository, IMapper mapper) : BaseService<Book, BookDTO, BookCreateDTO>(repository, mapper), IBookService
    {
        private readonly IBookRepo _repository = repository;

        public async Task<PaginationResponse<BookDTO>> GetFilterAsync(FilterRequest request)
        {
            var res = await _repository.GetFilterAsync(request);
            var dtos = _mapper.Map<IEnumerable<BookDTO>>(res.Data);
            return new(dtos, res.TotalCount);

        }

        public override void ValidateDTO(BookCreateDTO dto)
        {
            var a = 1;
        }
    }
}
