# VidrotecERP Backend

## Visão Geral

Este repositório contém o backend completo do VidrotecERP, construído com:

- ASP.NET Core Web API
- .NET 9
- Entity Framework Core
- SQL Server
- Clean Architecture
- Repository Pattern
- DTOs, Services e Controllers
- JWT Authentication
- Swagger e CORS

## Estrutura de Pastas

- `Vidrotec.API` - apresentação e configuração da API
- `Vidrotec.Application` - serviços, DTOs, validações e interfaces
- `Vidrotec.Domain` - entidades, enums, exceptions e value objects
- `Vidrotec.Infrastructure` - DbContext, EF Configurations, repositories e migrations

## Funcionalidades Implementadas

### Clientes

- CRUD completo de clientes
- Importação CSV preparada para dados no formato `Nome;Telefone;Endereco;Mercadoria1|Mercadoria2|Mercadoria3`
- Conversão automática de mercadorias em orçamentos e itens separados para cada cliente

### Produtos

- Listagem de produtos
- Reposição de estoque para produtos com `Quantidade <= QuantidadeMinima`
- Criação, edição e exclusão soft delete
- Movimentação de estoque registrada em alterações de quantidade / preço
- Cálculo de `ValorTotal` e `StatusEstoque`

### Orçamentos

- Listar orçamentos ativos
- Criar orçamentos com itens
- Exclusão soft delete

### Agenda

- Listar agenda completa
- Listar agenda por mês: `GET /api/agenda/{ano}/{mes}`
- Criar serviços com data real e status

### Autenticação

- JWT básico implementado em `AuthController`
- Endpoint de login: `POST /api/auth/login`

## Requisitos

- .NET SDK 10.0.x (compatível com .NET 9 runtime)
- SQL Server disponível

## Configuração

1. Ajuste a string de conexão em `Vidrotec.API/appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=VidrotecERP;User Id=sa;Password=Your_password123;TrustServerCertificate=True;"
}
```

2. Se desejar, atualize a chave JWT em `Vidrotec.API/appsettings.json`.

## Executando localmente

```bash
cd /workspaces/backend
dotnet restore
dotnet build Vidrotec.sln
cd Vidrotec.API
dotnet run
```

A API estará disponível em `http://localhost:5000` ou `https://localhost:5001` conforme a configuração.

## Swagger

Com o aplicativo em execução, acesse:

```
http://localhost:5000/swagger
```

## Migrations

As migrations do EF Core já foram geradas em `Vidrotec.Infrastructure/Migrations`.

Se quiser recriar as migrations:

```bash
dotnet ef migrations remove -p Vidrotec.Infrastructure -s Vidrotec.API
dotnet ef migrations add InitialCreate -p Vidrotec.Infrastructure -s Vidrotec.API -o Vidrotec.Infrastructure/Migrations
```

## Estrutura de banco de dados

O `AppDbContext` contém os DbSets:

- `Clientes`
- `Produtos`
- `MovimentacoesEstoque`
- `Orcamentos`
- `OrcamentoItens`
- `ProdutosOrcamento`
- `AgendaServicos`

## Notas

- A arquitetura foi construída para manter separação clara de responsabilidades entre camadas.
- Não foi criada entidade `Pedido`, conforme requisito.
- Soft delete aplicado em todas as entidades principais.

## Contato

Para dúvidas ou ajustes, modifique os serviços em `Vidrotec.Application` e os repositórios em `Vidrotec.Infrastructure`.
