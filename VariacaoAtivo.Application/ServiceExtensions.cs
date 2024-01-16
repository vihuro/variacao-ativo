using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace VariacaoAtivo.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplicationApp(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(md =>
                        md.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            /*services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));*/
        }
    }
}
