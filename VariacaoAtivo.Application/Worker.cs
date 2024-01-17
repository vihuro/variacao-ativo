using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VariacaoAtivo.Application.UseCases.Extenal;

namespace VariacaoAtivo.Application
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMediator _mediator;

        public Worker(ILogger<Worker> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var result = await _mediator.Send(new GetChartRequest(), stoppingToken);

                var teste = JsonConvert.SerializeObject(result, Formatting.Indented);

                _logger.LogInformation("Result of the API ", teste);
                await Task.Delay(20000, stoppingToken);
            }
        }
    }
}
