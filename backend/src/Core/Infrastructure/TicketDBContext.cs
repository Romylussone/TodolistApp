using Microsoft.EntityFrameworkCore;
using TodolistApi.core.Domain.model;

namespace TodolistApi.core.Infrastructure
{
    public class TicketDBContext : DbContext
    {
        public DbSet<Ticket>  Tickets { get; set; }
        public string ConnectionString { get; private set; }

        public TicketDBContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            ConnectionString = Path.Join(path, "ticketDB.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={ConnectionString}");
    }
}
