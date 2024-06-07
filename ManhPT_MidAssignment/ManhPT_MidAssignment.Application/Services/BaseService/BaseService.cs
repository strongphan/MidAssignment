using AutoMapper;
using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Domain.Entity;
using ManhPT_MidAssignment.Domain.Exceptions;

namespace ManhPT_MidAssignment.Application.Service
{
    public abstract class BaseService<TEntity, TEntityDto, TEntityCreateDto>(IBaseRepo<TEntity> repository, IMapper mapper) : IBaseService<TEntityDto, TEntityCreateDto> where TEntity : class
    {
        private readonly IBaseRepo<TEntity> _repository = repository;
        protected readonly IMapper _mapper = mapper;

        public virtual async Task DeleteAsync(Guid id)
        {
            var enity = await _repository.GetByIdAsync(id);
            if (enity == null)
            {
                throw new NotFoundException();
            }
            else
            {
                await _repository.DeleteAsync(enity);
            }
        }

        public async Task<IEnumerable<TEntityDto>> GetAllAsync()
        {
            var res = await _repository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<TEntityDto>>(res);
            return dtos;
        }

        public async Task<TEntityDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new NotFoundException();
            }
            var dto = _mapper.Map<TEntityDto>(entity);
            return dto;

        }

        public async Task InsertAsync(TEntityCreateDto entityDto, string name)
        {
            await ValidateDTO(entityDto);
            var entity = _mapper.Map<TEntity>(entityDto);
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.CreatedAt = DateTime.Now;
                baseEntity.CreatedBy = name;
            }
            await _repository.InsertAsync(entity);
        }

        public async Task UpdateAsync(Guid id, TEntityCreateDto entityDto, string name)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new NotFoundException();
            }
            else
            {
                entity = _mapper.Map<TEntity>(entityDto);
                if (entity is BaseEntity baseEntity)
                {
                    baseEntity.Id = id;
                    baseEntity.ModifiedAt = DateTime.Now;
                    baseEntity.ModifiedBy = name;
                }
                await _repository.UpdateAsync(entity);
            }
        }
        public abstract Task ValidateDTO(TEntityCreateDto dto);
    }
}
