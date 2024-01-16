using Microsoft.EntityFrameworkCore;
using VariacaoAtivo.Domain.Entities;

namespace VariacaoAtivo.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<ChartEntity> Charts { get; set; }
    }
}
