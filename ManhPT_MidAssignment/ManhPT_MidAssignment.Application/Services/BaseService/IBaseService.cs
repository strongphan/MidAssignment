namespace ManhPT_MidAssignment.Application.Service
{
    public interface IBaseService<TEntityDto, TEntityCreateDto>
    {
        Task<IEnumerable<TEntityDto>> GetAllAsync();
        Task<TEntityDto> GetByIdAsync(Guid id);
        Task InsertAsync(TEntityCreateDto entityDto, string name);
        Task UpdateAsync(Guid id, TEntityCreateDto entityDto, string name);
        Task DeleteAsync(Guid id);
        Task ValidateDTO(TEntityCreateDto dto);

    }
}
