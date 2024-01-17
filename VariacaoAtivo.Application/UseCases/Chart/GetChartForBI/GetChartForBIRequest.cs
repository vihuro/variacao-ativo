using MediatR;
using VariacaoAtivo.Application.UseCases.Chart.GetChartForBI;

namespace VariacaoAtivo.Application.UseCases.Chart.GetAllChart
{
    public sealed record class GetChartForBIRequest : IRequest<List<GetChartForBIResponse>>;
}
