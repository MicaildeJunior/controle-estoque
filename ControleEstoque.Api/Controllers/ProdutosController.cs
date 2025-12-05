using ControleEstoque.Application.Movimentacoes.Request;
using ControleEstoque.Application.Movimentacoes.Response;
using ControleEstoque.Application.Movimentacoes.Services.Interfaces;
using ControleEstoque.Application.Produtos.Repositories.Interface;
using ControleEstoque.Application.Produtos.Request;
using ControleEstoque.Application.Produtos.Response;
using ControleEstoque.Domain.Enums;
using ControleEstoque.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController(IProdutoRepository produtoRepository, IMovimentacaoEstoqueService movimentacaoService, IMovimentacaoConsultaService movimentacaoConsultaService) : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository = produtoRepository;
    private readonly IMovimentacaoEstoqueService _movimentacaoService = movimentacaoService;
    private readonly IMovimentacaoConsultaService _movimentacaoConsultaService = movimentacaoConsultaService;

    [HttpGet]
    public async Task<ActionResult<List<ProdutoResponse>>> Get()
    {
        var produtos = await _produtoRepository.ObterTodosAsync();
        var result = produtos.Select(p => new ProdutoResponse(
            p.Id,
            p.CodigoProduto,
            p.DescricaoProduto,
            p.Estoque,
            p.Ativo
        )).ToList();

        return Ok(result);
    }

    [HttpPatch("{id}/desativar")]
    public async Task<IActionResult> Desativar(Guid id)
    {
        var produto = await _produtoRepository.ObterPorIdAsync(id);
        if (produto is null)
            return NotFound();

        produto.Ativo = false;
        await _produtoRepository.AtualizarAsync(produto);
        return NoContent();
    }

    [HttpPatch("{id}/ativar")]
    public async Task<IActionResult> Ativar(Guid id)
    {
        var produto = await _produtoRepository.ObterPorIdAsync(id);
        if (produto is null)
            return NotFound();

        if (produto.Ativo)
            return BadRequest(new { mensagem = "Produto já está ativo." });

        produto.Ativo = true;
        await _produtoRepository.AtualizarAsync(produto);

        return NoContent();
    }

    [HttpPost("{id}/entrada")]
    public async Task<IActionResult> RegistrarEntrada(Guid id, [FromBody] AjustarEstoqueRequest request)
    {
        var produto = await _produtoRepository.ObterPorIdAsync(id);
        if (produto is null)
            return NotFound(new { mensagem = "Produto não encontrado." });

        if (!produto.Ativo)
            return BadRequest(new { mensagem = "Produto inativo. Não é possível movimentar estoque." });

        var movimentoRequest = new RegistrarMovimentacaoRequest(
            CodigoProduto: produto.CodigoProduto,
            Tipo: TipoMovimentacao.Entrada,
            Quantidade: request.Quantidade,
            Descricao: request.Descricao
        );

        var result = await _movimentacaoService.RegistrarAsync(movimentoRequest);

        if (!result.Sucesso)
            return BadRequest(new { mensagem = result.Mensagem });

        return Ok(result.Dados); 
    }

    [HttpPut("{id}/saida")]
    public async Task<IActionResult> RegistrarSaida(Guid id, [FromBody] AjustarEstoqueRequest request)
    {
        var produto = await _produtoRepository.ObterPorIdAsync(id);
        if (produto is null)
            return NotFound(new { mensagem = "Produto não encontrado." });

        if (!produto.Ativo)
            return BadRequest(new { mensagem = "Produto inativo. Não é possível movimentar estoque." });

        var movimentoRequest = new RegistrarMovimentacaoRequest(
            CodigoProduto: produto.CodigoProduto,
            Tipo: TipoMovimentacao.Saida,
            Quantidade: request.Quantidade,
            Descricao: request.Descricao
        );

        var result = await _movimentacaoService.RegistrarAsync(movimentoRequest);

        if (!result.Sucesso)
            return BadRequest(new { mensagem = result.Mensagem });

        return Ok(result.Dados);
    }

    [HttpGet("{codigoProduto:int}/movimentacoes")]
    public async Task<ActionResult<List<MovimentacaoListItemResponse>>> GetMovimentacoesPorCodigo(int codigoProduto)
    {
        var movs = await _movimentacaoConsultaService.ObterPorCodigoProdutoAsync(codigoProduto);

        if (movs is null || movs.Count == 0)
            return NotFound(new { mensagem = "Nenhuma movimentação encontrada para este produto." });

        return Ok(movs);
    }
}
