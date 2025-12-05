using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Application.Produtos.Repositories.Interface;

public interface IProdutoRepository
{
    Task<Produto?> ObterPorIdAsync(Guid id);
    Task<Produto?> ObterPorCodigoAsync(int codigoProduto);
    Task<List<Produto>> ObterTodosAsync();
    Task AdicionarAsync(Produto produto);
    Task AtualizarAsync(Produto produto);
}
