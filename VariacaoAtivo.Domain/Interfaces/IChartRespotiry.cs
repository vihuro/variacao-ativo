using VariacaoAtivo.Domain.Entities;

namespace VariacaoAtivo.Domain.Interfaces
{
    public interface IChartRespotiry : IBaseRepository<ChartEntity>
    {
        Task<ChartEntity> GetBySymbol(string symbol);
    }
}
