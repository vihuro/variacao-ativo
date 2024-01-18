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

        public async Task<List<ChartEntity>> GetByBI(CancellationToken cancellationToken)
        {
            var entity = await Context.Charts
                                      .Select(c => new ChartEntity
                                      {
                                          Id = c.Id,
                                          ChartPreviousClose = c.ChartPreviousClose,
                                          ExchangeTimeZone = c.ExchangeTimeZone,
                                          Currency = c.Currency,
                                          DateCreated = c.DateCreated,
                                          DateUpdated = c.DateUpdated,
                                          ExachangeName = c.ExachangeName,
                                          PreviousClose = c.PreviousClose,
                                          Symbol = c.Symbol,
                                          RegularMarketPrice = c.RegularMarketPrice,
                                          QuoteOpen = c.QuoteOpen.Skip(Math.Max(0, c.QuoteOpen.Count - 30)).ToList(),
                                      })
                                      .ToListAsync(cancellationToken);

            return entity;
        }
    }
}
