using ControleEstoque.Application.Movimentacoes.Repository.Interface;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infrastructure.Repositories;

public class MovimentacaoEstoqueRepository : IMovimentacaoEstoqueRepository
{
    private readonly ControleEstoqueContext _context;

    public MovimentacaoEstoqueRepository(ControleEstoqueContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(MovimentacaoEstoque movimentacao)
    {
        _context.MovimentacoesEstoque.Add(movimentacao);
        await _context.SaveChangesAsync();
    }

    public async Task<List<MovimentacaoEstoque>> ObterPorCodigoProdutoAsync(int codigoProduto)
    {
        return await _context.MovimentacoesEstoque
            .Include(m => m.Produto)
            .Where(m => m.Produto.CodigoProduto == codigoProduto)
            .OrderByDescending(m => m.CriadoEm)
            .ToListAsync();
    }
}
