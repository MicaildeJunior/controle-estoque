using ControleEstoque.Domain.Enums;

namespace ControleEstoque.Application.Movimentacoes.Response;

public sealed record MovimentacaoResponse(
    Guid Id,
    int CodigoProduto,
    string DescricaoProduto,
    TipoMovimentacao Tipo,
    int Quantidade,
    int EstoqueFinal
);
