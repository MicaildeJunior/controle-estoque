using ControleEstoque.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ControleEstoque.Infrastructure.Persistence;

public class ControleEstoqueContextFactory : IDesignTimeDbContextFactory<ControleEstoqueContext>
{
    public ControleEstoqueContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ControleEstoqueContext>();
        
        optionsBuilder.UseSqlServer(
            "Data Source=LAPTOP-563RGJKO\\SQLEXPRESS;Initial Catalog=ControleEstoqueDb;Integrated Security=True;TrustServerCertificate=True;");

        return new ControleEstoqueContext(optionsBuilder.Options);
    }
}
