INSERT INTO Produtos (Id, CodigoProduto, DescricaoProduto, Estoque, Ativo, CriadoEm)
VALUES
(NEWID(), 101, 'Caneta Azul', 150, 1, GETDATE()),
(NEWID(), 102, 'Caderno Universitário', 75, 1, GETDATE()),
(NEWID(), 103, 'Borracha Branca', 200, 1, GETDATE()),
(NEWID(), 104, 'Lápis Preto HB', 320, 1, GETDATE()),
(NEWID(), 105, 'Marcador de Texto Amarelo', 90, 1, GETDATE());

SELECT * FROM PRODUTOS