using ControleEstoque.Application.Movimentacoes.Repository.Interface;
using ControleEstoque.Application.Movimentacoes.Services;
using ControleEstoque.Application.Movimentacoes.Services.Interfaces;
using ControleEstoque.Application.Produtos.Repositories.Interface;
using ControleEstoque.Infrastructure.Data;
using ControleEstoque.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("ControleEstoqueConnection");

builder.Services.AddDbContext<ControleEstoqueContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IMovimentacaoEstoqueRepository, MovimentacaoEstoqueRepository>();

builder.Services.AddScoped<IMovimentacaoEstoqueService, MovimentacaoEstoqueService>();
builder.Services.AddScoped<IMovimentacaoConsultaService, MovimentacaoConsultaService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
