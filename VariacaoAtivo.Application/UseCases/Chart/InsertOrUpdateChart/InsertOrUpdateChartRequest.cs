using MediatR;

namespace VariacaoAtivo.Application.UseCases.Chart.InsertOrUpdateChart
{
    public sealed record class InsertOrUpdateChartRequest : IRequest<InsertOrUpdateChartResponse>;
}
