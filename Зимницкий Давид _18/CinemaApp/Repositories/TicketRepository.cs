using CinemaApp.Data;
using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Repositories
{
    public class TicketRepository
        : IRepository<TicketModel>
    {
        private readonly CinemaDbContext
            context;

        public TicketRepository()
        {
            context =
                new CinemaDbContext();
        }

        public async Task<List<TicketModel>>
            GetAllAsync()
        {
            return await context
                .Tickets
                .ToListAsync();
        }

        public async Task AddAsync(
            TicketModel entity)
        {
            await context
                .Tickets
                .AddAsync(entity);
        }

        public async Task DeleteAsync(
            TicketModel entity)
        {
            context
                .Tickets
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