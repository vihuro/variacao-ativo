using MediatR;
using Microsoft.AspNetCore.Mvc;
using VariacaoAtivo.Application.UseCases.Chart.GetAllChart;
using VariacaoAtivo.Application.UseCases.Chart.InsertOrUpdateChart;
using VariacaoAtivo.Application.UseCases.Extenal;

namespace VariacaoAtivo.Api_.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class ChartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChartController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Busca a cotação de ação, direto na API do yahoo.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("external")]
        public async Task<ActionResult<GetChartResponse>> GetChartExternal(CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new GetChartRequest(), cancellationToken);

            return Ok(result);

        }
        /// <summary>
        /// Busca as cotações, com a variação de cotação, para um gráfico.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<GetChartForBIRequest>> GetForBI(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetChartForBIRequest(), cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Atualiza a ação para o banco de dados local.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<InsertOrUpdateChartResponse>> UpdateList(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new InsertOrUpdateChartRequest(), cancellationToken);

            return Ok(result);

        }
    }
}
