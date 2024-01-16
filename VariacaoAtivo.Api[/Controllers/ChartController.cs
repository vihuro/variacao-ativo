using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public async Task<ActionResult<GetChartResponse>> GetChart(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new GetChartRequest(), cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
