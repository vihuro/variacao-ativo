using Microsoft.EntityFrameworkCore;
using VariacaoAtivo.Domain.Entities;
using VariacaoAtivo.Domain.Interfaces;
using VariacaoAtivo.Persistence.Context;

namespace VariacaoAtivo.Persistence.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext Context;

        public BaseRepository(AppDbContext context)
        {
            Context = context;
        }

        public void Create(T entity)
        {
            entity.DateCreated = DateTime.UtcNow;
            Context.Add(entity);
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            var listEntity = await Context.Set<T>().ToListAsync(cancellationToken);

            return listEntity;
        }

        public async Task<T> GetById(int id, CancellationToken cancellationToken)
        {
            var entity = await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return entity;
        }

        public void Update(T entity)
        {
            entity.DateUpdated = DateTime.UtcNow;
            Context.Update(entity);
        }
    }
}
