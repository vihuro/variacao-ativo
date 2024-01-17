
using Microsoft.EntityFrameworkCore.Storage;
using VariacaoAtivo.Domain.Interfaces;
using VariacaoAtivo.Persistence.Context;

namespace VariacaoAtivo.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();

        }

        public async Task Commit(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
