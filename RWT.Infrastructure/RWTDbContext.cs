using Microsoft.EntityFrameworkCore;

using RWT.Domain.Clients;

using RWT.Domain.Models;
using RWT.Domain.User;

namespace RWT.Infrastructure {
    public class RWTDbContext : DbContext {

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<TimeEntry> TimeEntries { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Todo> Todos { get; set; } = null!;
        
        public RWTDbContext(DbContextOptions<RWTDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RWTDbContext).Assembly);
        }
    }
}