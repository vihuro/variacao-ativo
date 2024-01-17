using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VariacaoAtivo.Application.UseCases.Chart.InsertOrUpdateChart;

namespace VariacaoAtivo.Application
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMediator _mediator;
        private IServiceProvider _services;

        public Worker(ILogger<Worker> logger,
                      IServiceProvider services)
        {
            _logger = logger;
            _services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _services.CreateScope())
                    {
                        var mediator = scope.ServiceProvider.GetService<IMediator>();

                        await mediator.Send(new InsertOrUpdateChartRequest(), stoppingToken);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                _logger.LogInformation("Banco de dados atualizado!");
                await Task.Delay(20000, stoppingToken);
            }
        }
    }
}
