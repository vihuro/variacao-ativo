using VariacaoAtivo.Domain.Entities;

namespace VariacaoAtivo.Domain.Interfaces
{
    public interface IChartRepository : IBaseRepository<ChartEntity>
    {
        Task<ChartEntity> GetBySymbol(string symbol, CancellationToken cancellationToken);
    }
}
