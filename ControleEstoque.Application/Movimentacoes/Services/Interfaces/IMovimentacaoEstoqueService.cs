using ControleEstoque.Application.Movimentacoes.Request;
using ControleEstoque.Application.Movimentacoes.Response;
using ControleEstoque.Shared;

namespace ControleEstoque.Application.Movimentacoes.Services.Interfaces;

public interface IMovimentacaoEstoqueService
{
    Task<Result<MovimentacaoResponse>> RegistrarAsync(RegistrarMovimentacaoRequest request);
}
