using ControleEstoque.Application.Movimentacoes.Repository.Interface;
using ControleEstoque.Application.Movimentacoes.Response;
using ControleEstoque.Application.Movimentacoes.Services.Interfaces;

namespace ControleEstoque.Application.Movimentacoes.Services;

public class MovimentacaoConsultaService(IMovimentacaoEstoqueRepository repo) : IMovimentacaoConsultaService
{
    private readonly IMovimentacaoEstoqueRepository _repo = repo;

    public async Task<List<MovimentacaoListItemResponse>> ObterPorCodigoProdutoAsync(int codigoProduto)
    {
        var movs = await _repo.ObterPorCodigoProdutoAsync(codigoProduto);

        return movs
            .Select(m => new MovimentacaoListItemResponse(
                m.Id,
                m.Produto.CodigoProduto,
                m.Produto.DescricaoProduto,
                m.Tipo,
                m.Quantidade,
                m.CriadoEm
            ))
            .ToList();
    }
}
