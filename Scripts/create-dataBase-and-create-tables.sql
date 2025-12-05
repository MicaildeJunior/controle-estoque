
-- Cria o banco
CREATE DATABASE ControleEstoqueDb;
GO

USE ControleEstoqueDb;
GO

-- Cria a tabela Produtos
CREATE TABLE Produtos
(
    Id UNIQUEIDENTIFIER NOT NULL,
    CodigoProduto INT NOT NULL,
    DescricaoProduto NVARCHAR(200) NOT NULL,
    Estoque INT NOT NULL,
    Ativo BIT NOT NULL,
    CriadoEm DATETIME2 NOT NULL,

    CONSTRAINT PK_Produtos PRIMARY KEY (Id),
    CONSTRAINT UQ_Produtos_CodigoProduto UNIQUE (CodigoProduto)
);
GO

-- Cria a tabela MovimentacoesEstoque
CREATE TABLE MovimentacoesEstoque
(
    Id UNIQUEIDENTIFIER NOT NULL,
    ProdutoId UNIQUEIDENTIFIER NOT NULL,
    Tipo INT NOT NULL,
    Quantidade INT NOT NULL,
    Descricao NVARCHAR(MAX) NOT NULL,
    CriadoEm DATETIME2 NOT NULL,

    CONSTRAINT PK_MovimentacoesEstoque PRIMARY KEY (Id),

    CONSTRAINT FK_MovimentacoesEstoque_Produtos
        FOREIGN KEY (ProdutoId)
        REFERENCES Produtos (Id)
        ON DELETE CASCADE
);
GO
