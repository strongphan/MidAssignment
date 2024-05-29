namespace ManhPT_MidAssignment.Application.Service
{
    public interface IBaseService<TEntityDto, TEntityCreateDto>
    {
        Task<IEnumerable<TEntityDto>> GetAllAsync();
        Task<TEntityDto> GetByIdAsync(Guid Id);
        void InsertAsync(TEntityCreateDto entityDto);
        void UpdateAsync(Guid id, TEntityCreateDto entityDto);
        void DeleteAsync(Guid id);
        void ValidateDTO(TEntityCreateDto dto);

    }
}
