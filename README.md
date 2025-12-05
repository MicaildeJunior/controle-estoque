# 🏷️ Sistema de Controle de Estoque  
Projeto desenvolvido como solução para um desafio técnico, utilizando **.NET 8**, **Entity Framework Core**, **SQL Server** e **Clean Architecture**.

O objetivo é permitir o controle de estoque de produtos, registrando **entradas** e **saídas**, mantendo um **histórico completo de movimentações**, bem como retornando a **quantidade final** do produto após cada operação.

---

“Modelei o JSON de estoque como uma tabela de Produtos, onde cada produto possui um campo Estoque (quantidade atual). As movimentações de entrada/saída ficam na tabela MovimentacoesEstoque, que registra o histórico e retorna a quantidade final após cada operação.”

---

## 📦 Funcionalidades

### ✔ Produtos
- Listar produtos ativos
- Ativar/Desativar produtos
- Consultar detalhes
- Exibir estoque atual

### ✔ Movimentações de Estoque
Cada movimentação contém:
- Identificador único  
- Tipo da movimentação (Entrada ou Saída)
- Quantidade inserida ou removida
- Descrição da operação
- Retorno da quantidade final do estoque

O sistema mantém um **histórico completo** de movimentações por produto.

---

## 🧱 Arquitetura Utilizada

O projeto segue o padrão **Clean Architecture**, dividido em camadas:

### 🔹 **Domain**
- Entidades
- Enumerações
- Regras de negócio essencial

### 🔹 **Application**
- Services
- DTOs
- Interfaces de repositório
- Regras de caso de uso

### 🔹 **Infrastructure**
- Entity Framework Core
- Repositórios concretos
- Migrations
- Contexto de banco de dados (DbContext)

### 🔹 **API**
- Controllers
- Endpoints de Produtos e Movimentações
- Configuração de DI e Swagger

---

## 🗄️ Banco de Dados (SQL Server)

O banco é criado automaticamente via **migrations**, mas também acompanha um script SQL na pasta **Scripts** para criação manual.

### Estrutura das tabelas principais:

#### 🟦 Produtos
| Campo | Tipo | Descrição |
|-------|------|-----------|
| Id | uniqueidentifier | ID do produto |
| CodigoProduto | int | Código único |
| DescricaoProduto | nvarchar(200) | Nome do produto |
| Estoque | int | Quantidade atual |
| Ativo | bit | Status |
| CriadoEm | datetime2 | Data de criação |

#### 🟦 MovimentacoesEstoque
| Campo | Tipo | Descrição |
|-------|------|-----------|
| Id | uniqueidentifier | ID da movimentação |
| ProdutoId | uniqueidentifier | FK para Produtos |
| Tipo | int | 1 = Entrada, 2 = Saída |
| Quantidade | int | Quantidade movimentada |
| Descricao | nvarchar(max) | Texto descritivo |
| CriadoEm | datetime2 | Data da movimentação |

---

## ▶️ Como Executar o Projeto

### 1️⃣ Clonar o repositório
```bash
git clone https://github.com/MicaildeJunior/controle-estoque.git
