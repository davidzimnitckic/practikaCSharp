namespace CinemaApp.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();

        Task AddAsync(T entity);

        Task DeleteAsync(T entity);

        Task SaveAsync();
    }
}