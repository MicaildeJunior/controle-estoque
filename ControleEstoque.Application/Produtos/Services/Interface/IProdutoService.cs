using ControleEstoque.Application.Produtos.Response;

namespace ControleEstoque.Application.Produtos.Services.Interface;

public interface IProdutoService
{
    Task<List<ProdutoResponse>> ObterTodosAsync();
    Task<ProdutoResponse?> ObterPorIdAsync(Guid id);
    Task DesativarAsync(Guid id);
}
