using ControleEstoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infrastructure.Data;

public class ControleEstoqueContext(DbContextOptions<ControleEstoqueContext> options) : DbContext(options) 
{ 
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<MovimentacaoEstoque> MovimentacoesEstoque { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Produto>(e =>
        {
            e.HasKey(p => p.Id);
            e.HasIndex(p => p.CodigoProduto).IsUnique();
            e.Property(p => p.DescricaoProduto).HasMaxLength(200).IsRequired();
        });
    }

}