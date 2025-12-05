using ControleEstoque.Application.Movimentacoes.Repository.Interface;
using ControleEstoque.Application.Movimentacoes.Request;
using ControleEstoque.Application.Movimentacoes.Response;
using ControleEstoque.Application.Movimentacoes.Services.Interfaces;
using ControleEstoque.Application.Produtos.Repositories.Interface;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Enums;
using ControleEstoque.Shared;

namespace ControleEstoque.Application.Movimentacoes.Services;

public class MovimentacaoEstoqueService : IMovimentacaoEstoqueService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMovimentacaoEstoqueRepository _movRepository;

    public MovimentacaoEstoqueService(
        IProdutoRepository produtoRepository,
        IMovimentacaoEstoqueRepository movRepository)
    {
        _produtoRepository = produtoRepository;
        _movRepository = movRepository;
    }

    public async Task<Result<MovimentacaoResponse>> RegistrarAsync(RegistrarMovimentacaoRequest request)
    {
        var produto = await _produtoRepository.ObterPorCodigoAsync(request.CodigoProduto);

        if (produto is null || !produto.Ativo)
            return Result<MovimentacaoResponse>.Fail("Produto não encontrado ou inativo.");

        if (request.Quantidade <= 0)
            return Result<MovimentacaoResponse>.Fail("Quantidade deve ser maior que zero.");

        if (request.Tipo == TipoMovimentacao.Saida && produto.Estoque < request.Quantidade)
            return Result<MovimentacaoResponse>.Fail("Estoque insuficiente para saída.");
        
        if (request.Tipo == TipoMovimentacao.Entrada)
            produto.Estoque += request.Quantidade;
        else
            produto.Estoque -= request.Quantidade;

        var movimentacao = new MovimentacaoEstoque
        {
            ProdutoId = produto.Id,
            Tipo = request.Tipo,
            Quantidade = request.Quantidade,
            Descricao = request.Descricao
        };

        await _movRepository.AdicionarAsync(movimentacao);
        await _produtoRepository.AtualizarAsync(produto);

        var response = new MovimentacaoResponse(
            movimentacao.Id,
            produto.CodigoProduto,
            produto.DescricaoProduto,
            request.Tipo,
            request.Quantidade,
            produto.Estoque
        );

        return Result<MovimentacaoResponse>.Ok(response, "Movimentação registrada com sucesso.");
    }
}
