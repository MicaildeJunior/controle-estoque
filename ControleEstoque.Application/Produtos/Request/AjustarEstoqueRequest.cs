namespace ControleEstoque.Application.Produtos.Request;

public sealed record AjustarEstoqueRequest(
    int Quantidade,
    string Descricao
);
