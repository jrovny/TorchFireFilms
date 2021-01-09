using Microsoft.EntityFrameworkCore;
using TorchFireFilms.Api.Films.Data.Models;
using TorchFireFilms.Api.Values;

namespace TorchFireFilms
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConnectionService _connectionService;

        public DbSet<Value> Values { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmI18n> FilmTranslations { get; set; }

        public ApplicationDbContext(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(_connectionService.GetDefaultConnectionString());
        }
    }
}
