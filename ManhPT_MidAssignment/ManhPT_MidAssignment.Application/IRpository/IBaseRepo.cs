namespace ManhPT_MidAssignment.Application.IRepository
{
    public interface IBaseRepo<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid Id);
        void InsertAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        void DeleteAsync(TEntity entity);
        void Save();
    }
}