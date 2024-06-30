namespace API.Data.Repository
{
    public interface IRepository<T>
    {
        Task CreateEntityAsync(T entity);
        Task<IEnumerable<T>> GetEntitiesAsync();
        Task<T> GetEntityAsync(int id);
        Task UpdateEntityAsync(T entity);
        Task DeleteEntityAsync(int id);
        
    }
}
