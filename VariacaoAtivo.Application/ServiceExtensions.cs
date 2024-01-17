using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Transactions;
using VariacaoAtivo.Application.UseCases.Chart.InsertOrUpdateChart;

namespace VariacaoAtivo.Application
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// <para>
        /// Configuração de serviços da biblioteca Application como:
        /// </para>
        /// <para>
        ///  AutoMapper
        /// </para>
        /// <para>
        /// Mediator 
        /// </para>
        /// <para>
        /// WorkerService
        /// </para>
        ///
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureApplicationApp(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            services.AddMediatR(md =>
                        md.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddHostedService<Worker>();
            /*services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));*/
        }
    }
}
