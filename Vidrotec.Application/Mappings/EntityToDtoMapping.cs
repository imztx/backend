using System;
using System.Collections.Generic;
using System.Linq;
using Vidrotec.Application.DTOs;
using Vidrotec.Domain.Entities;
using Vidrotec.Domain.Enums;

namespace Vidrotec.Application.Mappings
{
    public static class EntityToDtoMapping
    {
        public static ClienteDto ToDto(this Cliente entity) => new()
        {
            Id = entity.Id,
            Nome = entity.Nome,
            Telefone = entity.Telefone,
            Endereco = entity.Endereco,
            DataCadastro = entity.DataCadastro
        };

        public static ProdutoDto ToDto(this Produto entity) => new()
        {
            Id = entity.Id,
            Nome = entity.Nome,
            Codigo = entity.Codigo,
            Cor = entity.Cor,
            Quantidade = entity.Quantidade,
            QuantidadeMinima = entity.QuantidadeMinima,
            ValorUnitario = entity.ValorUnitario,
            ValorTotal = entity.ValorTotal,
            StatusEstoque = entity.StatusEstoque.ToString(),
            DataCadastro = entity.DataCadastro
        };

        public static OrcamentoDto ToDto(this Orcamento entity) => new()
        {
            Id = entity.Id,
            NomeCliente = entity.NomeCliente,
            Subtotal = entity.Subtotal,
            Desconto = entity.Desconto,
            ValorFinal = entity.ValorFinal,
            DataCadastro = entity.DataCadastro,
            Itens = entity.Itens.Select(i => i.ToDto()).ToList()
        };

        public static OrcamentoItemDto ToDto(this OrcamentoItem entity) => new()
        {
            Id = entity.Id,
            Descricao = entity.Descricao,
            PrecoUnitario = entity.PrecoUnitario,
            ValorTotal = entity.ValorTotal,
            Largura = entity.Largura,
            Altura = entity.Altura,
            Quantidade = entity.Quantidade,
            TipoVidro = entity.TipoVidro,
            NumeroFolhas = entity.NumeroFolhas,
            Abertura = entity.Abertura,
            Fechadura = entity.Fechadura,
            Mola = entity.Mola
        };

        public static AgendaServicoDto ToDto(this AgendaServico entity) => new()
        {
            Id = entity.Id,
            DataServico = entity.DataServico,
            Turno = entity.Turno.ToString(),
            Cliente = entity.Cliente,
            Descricao = entity.Descricao,
            Endereco = entity.Endereco,
            Responsavel = entity.Responsavel,
            Status = entity.Status.ToString(),
            DataCadastro = entity.DataCadastro
        };
    }
}
