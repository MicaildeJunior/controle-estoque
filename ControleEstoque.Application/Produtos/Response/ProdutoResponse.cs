namespace ControleEstoque.Application.Produtos.Response;

public sealed record ProdutoResponse(
    Guid Id,
    int CodigoProduto,
    string DescricaoProduto,
    int Estoque,
    bool Ativo
);
