namespace ControleEstoque.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}
