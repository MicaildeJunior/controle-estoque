using ControleEstoque.Domain.Common;

namespace ControleEstoque.Domain.Entities;

public class Produto : BaseEntity
{
    public int CodigoProduto { get; set; }        
    public string DescricaoProduto { get; set; } = null!;
    public int Estoque { get; set; }              
    public bool Ativo { get; set; } = true;

    public ICollection<MovimentacaoEstoque> Movimentacoes { get; set; } = new List<MovimentacaoEstoque>();
}
