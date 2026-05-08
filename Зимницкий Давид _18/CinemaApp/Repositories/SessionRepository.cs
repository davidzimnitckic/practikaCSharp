using CinemaApp.Data;
using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Repositories
{
    public class SessionRepository
        : IRepository<MovieSession>
    {
        private readonly CinemaDbContext
            context;

        public SessionRepository()
        {
            context =
                new CinemaDbContext();
        }

        public async Task<List<MovieSession>>
            GetAllAsync()
        {
            return await context
                .Sessions
                .Include(s => s.Movie)
                .ToListAsync();
        }

        public async Task AddAsync(
            MovieSession entity)
        {
            await context
                .Sessions
                .AddAsync(entity);
        }

        public async Task DeleteAsync(
            MovieSession entity)
        {
            context
                .Sessions
                .Remove(entity);

            await Task.CompletedTask;
        }

        public async Task SaveAsync()
        {
            await context
                .SaveChangesAsync();
        }
    }
}