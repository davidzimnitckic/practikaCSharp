using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data
{
    public class CinemaDbContext
        : DbContext
    {
        public DbSet<MovieSession>
            Sessions
        { get; set; }

        public DbSet<TicketModel>
            Tickets
        { get; set; }

        public DbSet<MovieModel>
            Movies
        { get; set; }

        public CinemaDbContext()
        {

            Database.EnsureCreated();
        }

        protected override void
            OnConfiguring(
                DbContextOptionsBuilder
                optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=cinema.db");
        }
    }
}