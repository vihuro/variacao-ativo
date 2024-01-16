using VariacaoAtivo.Domain.Entities;
using VariacaoAtivo.Domain.Interfaces;
using VariacaoAtivo.Persistence.Context;

namespace VariacaoAtivo.Persistence.Repository
{
    public class CharRepository : BaseRepository<ChartEntity>, IChartRespotiry
    {
        public CharRepository(AppDbContext context) : base(context)
        { }

        public Task<ChartEntity> GetBySymbol(string symbol)
        {
            throw new NotImplementedException();
        }
    }
}
