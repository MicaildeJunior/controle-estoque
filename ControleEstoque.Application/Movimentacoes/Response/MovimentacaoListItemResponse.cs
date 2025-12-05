using ControleEstoque.Domain.Enums;

namespace ControleEstoque.Application.Movimentacoes.Response;

public record MovimentacaoListItemResponse(
    Guid Id,
    int CodigoProduto,
    string DescricaoProduto,
    TipoMovimentacao Tipo,
    int Quantidade,
    DateTime Data
);
