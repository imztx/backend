using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidrotec.Application.DTOs;
using Vidrotec.Application.Interfaces;
using Vidrotec.Application.Mappings;
using Vidrotec.Application.Services.Interfaces;
using Vidrotec.Domain.Entities;
using Vidrotec.Domain.Enums;

namespace Vidrotec.Application.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteDto> CreateAsync(CreateClienteDto request)
        {
            var cliente = new Cliente(request.Nome, request.Telefone, request.Endereco);
            await _clienteRepository.AddAsync(cliente);
            return cliente.ToDto();
        }

        public async Task DeleteAsync(Guid id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente is null) return;
            cliente.SetExcluido();
            _clienteRepository.Update(cliente);
        }

        public async Task<IEnumerable<ClienteDto>> GetAllAsync()
        {
            var clientes = await _clienteRepository.GetAllActiveAsync();
            return clientes.Select(c => c.ToDto());
        }

        public async Task<ClienteDto?> GetByIdAsync(Guid id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente is null || cliente.Excluido) return null;
            return cliente.ToDto();
        }

        public async Task<ClienteDto?> UpdateAsync(Guid id, UpdateClienteDto request)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente is null || cliente.Excluido) return null;
            cliente.Update(request.Nome, request.Telefone, request.Endereco);
            _clienteRepository.Update(cliente);
            return cliente.ToDto();
        }

        public async Task<ClienteImportResultDto> ImportCsvAsync(ImportClienteCsvDto request)
        {
            var lines = request.CsvContent.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var totalClientes = 0;
            var totalOrcamentos = 0;
            var totalItens = 0;

            foreach (var line in lines)
            {
                var columns = line.Split(';');
                if (columns.Length < 4) continue;

                var nome = columns[0].Trim();
                var telefone = columns[1].Trim();
                var endereco = columns[2].Trim();
                var mercadorias = columns[3].Split('|', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

                var cliente = new Cliente(nome, telefone, endereco);
                var orcamento = new Orcamento(nome, 0m);
                foreach (var descricao in mercadorias)
                {
                    var item = new OrcamentoItem(orcamento.Id, descricao, 0m, 1, 0m, 0m, descricao, 1, string.Empty, string.Empty, string.Empty);
                    orcamento.AddItem(item);
                    totalItens++;
                }

                cliente.AddOrcamento(orcamento);
                await _clienteRepository.AddAsync(cliente);
                totalClientes++;
                totalOrcamentos++;
            }

            return new ClienteImportResultDto
            {
                TotalClientes = totalClientes,
                TotalOrcamentos = totalOrcamentos,
                TotalItens = totalItens
            };
        }
    }

    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMovimentacaoEstoqueRepository _movimentacaoRepository;

        public ProdutoService(IProdutoRepository produtoRepository, IMovimentacaoEstoqueRepository movimentacaoRepository)
        {
            _produtoRepository = produtoRepository;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public async Task<ProdutoDto> CreateAsync(CreateProdutoDto request)
        {
            var produto = new Produto(request.Nome, request.Codigo, request.Cor, request.Quantidade, request.QuantidadeMinima, request.ValorUnitario);
            await _produtoRepository.AddAsync(produto);
            return produto.ToDto();
        }

        public async Task DeleteAsync(Guid id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto is null) return;
            produto.SetExcluido();
            _produtoRepository.Update(produto);
        }

        public async Task<IEnumerable<ProdutoDto>> GetAllAsync()
        {
            var produtos = await _produtoRepository.GetAllActiveAsync();
            return produtos.Select(p => p.ToDto());
        }

        public async Task<IEnumerable<ProdutoDto>> GetReposicaoAsync()
        {
            var produtos = await _produtoRepository.GetReposicaoAsync();
            return produtos.Select(p => p.ToDto());
        }

        public async Task<ProdutoDto?> UpdateAsync(Guid id, UpdateProdutoDto request)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto is null || produto.Excluido) return null;

            var quantidadeAnterior = produto.Quantidade;
            var valorAnterior = produto.ValorUnitario;

            produto.Update(request.Nome, request.Codigo, request.Cor, request.Quantidade, request.QuantidadeMinima, request.ValorUnitario);
            _produtoRepository.Update(produto);

            if (quantidadeAnterior != request.Quantidade || valorAnterior != request.ValorUnitario)
            {
                var tipo = MovimentacaoTipo.Ajuste;
                if (request.Quantidade > quantidadeAnterior) tipo = MovimentacaoTipo.Entrada;
                else if (request.Quantidade < quantidadeAnterior) tipo = MovimentacaoTipo.Saida;

                var movimentacao = new MovimentacaoEstoque(produto.Id, tipo, quantidadeAnterior, request.Quantidade, valorAnterior, request.ValorUnitario);
                await _movimentacaoRepository.AddAsync(movimentacao);
                produto.AddMovimentacao(movimentacao);
            }

            return produto.ToDto();
        }
    }

    public class OrcamentoService : IOrcamentoService
    {
        private readonly IOrcamentoRepository _orcamentoRepository;

        public OrcamentoService(IOrcamentoRepository orcamentoRepository)
        {
            _orcamentoRepository = orcamentoRepository;
        }

        public async Task<OrcamentoDto> CreateAsync(CreateOrcamentoDto request)
        {
            var orcamento = new Orcamento(request.NomeCliente, request.Desconto);
            foreach (var itemDto in request.Itens)
            {
                var item = new OrcamentoItem(orcamento.Id, itemDto.Descricao, itemDto.PrecoUnitario, itemDto.Quantidade, itemDto.Largura, itemDto.Altura, itemDto.TipoVidro, itemDto.NumeroFolhas, itemDto.Abertura, itemDto.Fechadura, itemDto.Mola);
                orcamento.AddItem(item);
            }
            orcamento.Recalculate();
            await _orcamentoRepository.AddAsync(orcamento);
            return orcamento.ToDto();
        }

        public async Task DeleteAsync(Guid id)
        {
            var orcamento = await _orcamentoRepository.GetByIdAsync(id);
            if (orcamento is null) return;
            orcamento.SetExcluido();
            _orcamentoRepository.Update(orcamento);
        }

        public async Task<IEnumerable<OrcamentoDto>> GetAllAsync()
        {
            var orcamentos = await _orcamentoRepository.GetAllActiveWithItensAsync();
            return orcamentos.Select(o => o.ToDto());
        }
    }

    public class AgendaServicoService : IAgendaServicoService
    {
        private readonly IAgendaServicoRepository _agendaServicoRepository;

        public AgendaServicoService(IAgendaServicoRepository agendaServicoRepository)
        {
            _agendaServicoRepository = agendaServicoRepository;
        }

        public async Task<AgendaServicoDto> CreateAsync(CreateAgendaServicoDto request)
        {
            Enum.TryParse(request.Turno, true, out Turno turno);
            Enum.TryParse(request.Status, true, out AgendaStatus status);
            var agenda = new AgendaServico(request.DataServico, turno, request.Cliente, request.Descricao, request.Endereco, request.Responsavel, status);
            await _agendaServicoRepository.AddAsync(agenda);
            return agenda.ToDto();
        }

        public async Task<IEnumerable<AgendaServicoDto>> GetAllAsync()
        {
            var agenda = await _agendaServicoRepository.GetAllActiveAsync();
            return agenda.Select(a => a.ToDto());
        }

        public async Task<IEnumerable<AgendaServicoDto>> GetByMonthAsync(int ano, int mes)
        {
            var agenda = await _agendaServicoRepository.GetByMonthAsync(ano, mes);
            return agenda.Select(a => a.ToDto());
        }
    }
}
