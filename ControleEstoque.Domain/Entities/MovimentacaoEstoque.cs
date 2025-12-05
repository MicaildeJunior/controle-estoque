using ControleEstoque.Domain.Common;
using ControleEstoque.Domain.Enums;

namespace ControleEstoque.Domain.Entities;

public class MovimentacaoEstoque : BaseEntity
{
    public Guid ProdutoId { get; set; }
    public Produto Produto { get; set; } = null!;
    public TipoMovimentacao Tipo { get; set; }   
    public int Quantidade { get; set; }          
    public string Descricao { get; set; } = null!;
}
