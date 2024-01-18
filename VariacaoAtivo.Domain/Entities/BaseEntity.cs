namespace VariacaoAtivo.Domain.Entities
{
    /// <summary>
    /// Classe abstrata que contem: 
    /// <para>
    /// DateCreated
    /// </para>
    /// <para>
    /// DateCreated
    /// </para>
    /// E os métodos:
    /// <para>
    /// Create
    /// </para>
    /// <para>
    /// Update
    /// </para>
    /// <para>
    /// GetById
    /// </para>
    /// <para>
    /// GetAll
    /// </para>
    /// </summary>
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
