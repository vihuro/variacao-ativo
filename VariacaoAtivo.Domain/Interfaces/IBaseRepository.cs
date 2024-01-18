using VariacaoAtivo.Domain.Entities;

namespace VariacaoAtivo.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Cria uma nova entidade que use o classe abstratua BaseEntity.
        /// </summary>
        /// <param name="entity"></param>
        void Create(T entity);
        /// <summary>
        /// Cria uma nova entidade que use o classe abstratua BaseEntity.
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
        /// <summary>
        /// Busca uma única entidade que represente ao ID selecionado.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        Task<T> GetById(int id, CancellationToken cancellationToken);
        /// <summary>
        /// Busca todas entidades.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        Task<List<T>> GetAll(CancellationToken cancellationToken);
    }
}
