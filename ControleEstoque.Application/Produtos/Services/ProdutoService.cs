using ControleEstoque.Application.Produtos.Repositories.Interface;
using ControleEstoque.Application.Produtos.Response;
using ControleEstoque.Application.Produtos.Services.Interface;

namespace ControleEstoque.Application.Produtos.Services;

public class ProdutoService(IProdutoRepository produtoRepository) : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository = produtoRepository;

    public async Task<List<ProdutoResponse>> ObterTodosAsync()
    {
        var produtos = await _produtoRepository.ObterTodosAsync();

        return produtos
            .Select(p => new ProdutoResponse(
                p.Id,
                p.CodigoProduto,
                p.DescricaoProduto,
                p.Estoque,
                p.Ativo
            )).ToList();
    }

    public async Task<ProdutoResponse?> ObterPorIdAsync(Guid id)
    {
        var p = await _produtoRepository.ObterPorIdAsync(id);
        if (p is null) return null;

        return new ProdutoResponse(
            p.Id,
            p.CodigoProduto,
            p.DescricaoProduto,
            p.Estoque,
            p.Ativo
        );
    }

    public async Task DesativarAsync(Guid id)
    {
        var p = await _produtoRepository.ObterPorIdAsync(id);
        if (p is null)
            throw new InvalidOperationException("Produto não encontrado.");

        p.Ativo = false;
        await _produtoRepository.AtualizarAsync(p);
    }
}
