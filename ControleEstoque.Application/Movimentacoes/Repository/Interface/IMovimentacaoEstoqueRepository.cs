using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Application.Movimentacoes.Repository.Interface;

public interface IMovimentacaoEstoqueRepository
{
    Task AdicionarAsync(MovimentacaoEstoque movimentacao);

    Task<List<MovimentacaoEstoque>> ObterPorCodigoProdutoAsync(int codigoProduto);
}
