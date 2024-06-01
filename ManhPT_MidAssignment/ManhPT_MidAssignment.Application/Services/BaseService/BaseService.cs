using AutoMapper;
using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Domain.Entity;

namespace ManhPT_MidAssignment.Application.Service
{
    public abstract class BaseService<TEntity, TEntityDto, TEntityCreateDto>(IBaseRepo<TEntity> repository, IMapper mapper) : IBaseService<TEntityDto, TEntityCreateDto> where TEntity : class
    {
        private readonly IBaseRepo<TEntity> _repository = repository;
        protected readonly IMapper _mapper = mapper;

        public async void DeleteAsync(Guid id)
        {
            var enity = await _repository.GetByIdAsync(id);
            if (enity == null)
            {
                throw new Exception("Not Found");
            }
            else
            {
                _repository.DeleteAsync(enity);
            }
        }

        public async Task<IEnumerable<TEntityDto>> GetAllAsync()
        {
            var res = await _repository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<TEntityDto>>(res);
            return dtos;
        }

        public async Task<TEntityDto> GetByIdAsync(Guid Id)
        {
            var entity = await _repository.GetByIdAsync(Id);
            var dto = _mapper.Map<TEntityDto>(entity);
            return dto;

        }

        public void InsertAsync(TEntityCreateDto entityDto, string name)
        {
            ValidateDTO(entityDto);
            var entity = _mapper.Map<TEntity>(entityDto);
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.CreatedAt = DateTime.Now;
                baseEntity.CreatedBy = name;
            }
            _repository.InsertAsync(entity);
        }

        public async void UpdateAsync(Guid id, TEntityCreateDto entityDto, string name)
        {
            ValidateDTO(entityDto);
            var entity = await _repository.GetByIdAsync(id);
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.ModifiedAt = DateTime.Now;
                baseEntity.ModifiedBy = name;
            }
            if (entity == null)
            {
                throw new Exception("Not Found");
            }
            else
            {
                entity = _mapper.Map<TEntity>(entityDto);
                _repository.UpdateAsync(entity);
            }
        }
        public abstract void ValidateDTO(TEntityCreateDto dto);
    }
}
