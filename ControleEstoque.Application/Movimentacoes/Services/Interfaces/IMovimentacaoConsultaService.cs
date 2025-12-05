using ControleEstoque.Application.Movimentacoes.Response;

namespace ControleEstoque.Application.Movimentacoes.Services.Interfaces;

public interface IMovimentacaoConsultaService
{
    Task<List<MovimentacaoListItemResponse>> ObterPorCodigoProdutoAsync(int codigoProduto);
}
