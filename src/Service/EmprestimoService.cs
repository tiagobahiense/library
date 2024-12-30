using Library.src.Models;
using Library.src.Repositories.Interfaces;
using Library.src.Service.Interfaces;
using Library.src.DTO.Emprestimos;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Library.src.Service
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _repository;
        private readonly ILogger<EmprestimoService> _logger;

        public EmprestimoService(IEmprestimoRepository repository, ILogger<EmprestimoService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public void Adicionar(Emprestimo emprestimo)
        {
            _repository.Adicionar(emprestimo);
            _logger.LogInformation($"Empréstimo registrado: ID do Cliente: {emprestimo.IdCliente}, ID do Catálogo: {emprestimo.IdCatalogo}, ID do Inventário: {emprestimo.IdInventario}, Data de Empréstimo: {emprestimo.DataEmprestimo}, Data de Devolução: {emprestimo.DataDevolucao}");
        }

        public void Atualizar(Emprestimo emprestimo)
        {
            _repository.Atualizar(emprestimo);
            _logger.LogInformation($"Empréstimo atualizado: ID: {emprestimo.Id}");
        }

        public Emprestimo ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<Emprestimo> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public IEnumerable<Emprestimo> ObterPorClienteId(int clienteId)
        {
            var emprestimos = _repository.ObterPorClienteId(clienteId);
            _logger.LogInformation($"Obtendo empréstimos do cliente: ID do Cliente: {clienteId}, Quantidade de Empréstimos: {emprestimos.Count()}");
            return emprestimos;
        }

        public void Remover(int id)
        {
            _repository.Remover(id);
            _logger.LogInformation($"Empréstimo removido: ID: {id}");
        }

        public void RegistrarEmprestimo(int clienteId, List<CadastrarEmprestimoDto> emprestimosDto)
        {
            foreach (var emprestimoDto in emprestimosDto)
            {
                var emprestimo = new Emprestimo
                {
                    IdCliente = clienteId,
                    IdCatalogo = emprestimoDto.IdCatalogo,
                    IdInventario = emprestimoDto.IdInventario,
                    DataEmprestimo = emprestimoDto.DataEmprestimo,
                    DataDevolucao = emprestimoDto.DataDevolucao
                };
                Adicionar(emprestimo);
            }
        }

        public void DevolverEmprestimo(int clienteId, List<DevolucaoEmprestimoDto> devolucoesDto)
        {
            foreach (var devolucaoDto in devolucoesDto)
            {
                var emprestimo = ObterPorId(devolucaoDto.EmprestimoId);
                if (emprestimo != null)
                {
                    emprestimo.DataDevolucao = devolucaoDto.DataDevolucao;
                    Atualizar(emprestimo);
                }
            }
        }

        public IEnumerable<Emprestimo> ObterEmprestimosDoCliente(int clienteId)
        {
            return ObterPorClienteId(clienteId);
        }
    }
}
