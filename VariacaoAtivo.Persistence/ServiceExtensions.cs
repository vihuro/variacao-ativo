using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VariacaoAtivo.Domain.Interfaces;
using VariacaoAtivo.Persistence.Context;
using VariacaoAtivo.Persistence.Repository;

namespace VariacaoAtivo.Persistence
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configuração de conexeão com banco de dados e configuração de interfaces.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigurePersistenceApp(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("variacao-ativo");

            services.AddDbContext<AppDbContext>(op => op.UseNpgsql(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IChartRepository, ChartRepository>();
        }
    }
}
