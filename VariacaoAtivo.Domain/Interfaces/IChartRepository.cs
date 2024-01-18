using VariacaoAtivo.Domain.Entities;

namespace VariacaoAtivo.Domain.Interfaces
{
    public interface IChartRepository : IBaseRepository<ChartEntity>
    {
        /// <summary>
        /// Para 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ChartEntity> GetBySymbol(string symbol, CancellationToken cancellationToken);
        /// <summary>
        /// Busca os dados, prontos para um gráfico, com apenas o 30 últimos valores de abertura.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<ChartEntity>> GetByBI(CancellationToken cancellationToken);
    }
}
