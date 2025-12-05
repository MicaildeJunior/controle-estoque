using ControleEstoque.Domain.Enums;

namespace ControleEstoque.Application.Movimentacoes.Request;

public sealed record RegistrarMovimentacaoRequest(
    int CodigoProduto,
    TipoMovimentacao Tipo,
    int Quantidade,
    string Descricao
);
