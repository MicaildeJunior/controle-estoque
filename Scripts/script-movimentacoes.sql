
SELECT * FROM MovimentacoesEstoque

-- Script de Movimentações
SELECT 
	mov.ID AS MovimentacaoId,
	pro.DescricaoProduto AS Produto,
	pro.CodigoProduto AS CodigoProduto,
	mov.Descricao AS Descricao,
	CASE 
		WHEN mov.Tipo = 1 THEN 'Entrada'
		WHEN mov.Tipo = 2 THEN 'Saída'
    ELSE 'Desconhecido'
END AS TipoMovimentacao,
	mov.Quantidade AS Quantidade
 FROM MovimentacoesEstoque mov
INNER JOIN Produtos pro ON mov.ProdutoId = pro.Id
Where pro.Ativo = 1
