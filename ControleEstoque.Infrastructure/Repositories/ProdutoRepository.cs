using ControleEstoque.Application.Produtos.Repositories.Interface;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly ControleEstoqueContext _context;

    public ProdutoRepository(ControleEstoqueContext context)
    {
        _context = context;
    }

    public async Task<Produto?> ObterPorIdAsync(Guid id)
        => await _context.Produtos.FindAsync(id);

    public async Task<Produto?> ObterPorCodigoAsync(int codigoProduto)
        => await _context.Produtos.FirstOrDefaultAsync(p => p.CodigoProduto == codigoProduto);

    public async Task<List<Produto>> ObterTodosAsync()
    {        
        return await _context.Produtos
                         .Where(p => p.Ativo)
                         .AsNoTracking()
                         .ToListAsync();
    }

    public async Task AdicionarAsync(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Produto produto)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
    }
}
