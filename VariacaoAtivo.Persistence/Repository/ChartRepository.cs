using Microsoft.EntityFrameworkCore;
using VariacaoAtivo.Domain.Entities;
using VariacaoAtivo.Domain.Interfaces;
using VariacaoAtivo.Persistence.Context;

namespace VariacaoAtivo.Persistence.Repository
{
    public class ChartRepository : BaseRepository<ChartEntity>, IChartRepository
    {
        public ChartRepository(AppDbContext context) : base(context)
        { }

        public async Task<ChartEntity> GetBySymbol(string symbol, CancellationToken cancellationToken)
        {
            var entity = await Context.Charts
                                .SingleOrDefaultAsync(x =>
                                    x.Symbol == symbol.ToUpper(), 
                                    cancellationToken);

            return entity;
        }
    }
}
