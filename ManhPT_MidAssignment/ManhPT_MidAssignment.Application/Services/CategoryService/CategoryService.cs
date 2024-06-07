using AutoMapper;
using ManhPT_MidAssignment.Application.DTOs.CategoryDTOs;
using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Application.Service;
using ManhPT_MidAssignment.Domain.Entity;
using ManhPT_MidAssignment.Domain.Exceptions;

namespace ManhPT_MidAssignment.Application.Services.CategoryService
{
    public class CategoryService(ICategoryRepo repository, IMapper mapper, IBookRepo bookRepo) : BaseService<Category, CategoryDTO, CategoryCreateDTO>(repository, mapper), ICategoryService
    {
        private readonly IBookRepo _bookRepo = bookRepo;

        public override async Task DeleteAsync(Guid id)
        {
            var books = await _bookRepo.GetByCategoryAsync(id);
            if (books == null)
            {
                await base.DeleteAsync(id);
            }
            else
            {
                throw new DataInvalidException("Category have books, please remove book from category");
            }
        }
        public override async Task ValidateDTO(CategoryCreateDTO dto)
        {
            var a = 1;
        }
    }
}
