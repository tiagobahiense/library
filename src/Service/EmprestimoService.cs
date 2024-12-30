using Library.src.DTO.Emprestimos;
using Library.src.Models;
using Library.src.Repositories.Interfaces;
using Library.src.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Library.src.Service
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly ILogger<EmprestimoService> _logger;

        public EmprestimoService(IEmprestimoRepository emprestimoRepository, ILogger<EmprestimoService> logger)
        {
            _emprestimoRepository = emprestimoRepository;
            _logger = logger;
        }

        public void RegistrarEmprestimo(int clienteId, List<CadastrarEmprestimoDto> emprestimos)
        {
            foreach (var emprestimoDto in emprestimos)
            {
                var emprestimo = emprestimoDto.ToEmprestimo(clienteId);
                _emprestimoRepository.Adicionar(emprestimo);
                _logger.LogInformation($"Empréstimo registrado: ID do Cliente: {clienteId}, ID do Catálogo: {emprestimoDto.IdCatalogo}, ID do Inventário: {emprestimoDto.IdInventario}, Data de Empréstimo: {emprestimoDto.DataEmprestimo}, Data de Devolução: {emprestimoDto.DataDevolucao}");
            }
        }

        public void DevolverEmprestimo(int clienteId, List<DevolucaoEmprestimoDto> devolucoes)
        {
            foreach (var devolucaoDto in devolucoes)
            {
                var emprestimo = _emprestimoRepository.ObterPorId(devolucaoDto.EmprestimoId);
                if (emprestimo != null && emprestimo.IdCliente == clienteId)
                {
                    emprestimo.DataDevolucao = devolucaoDto.DataDevolucao;
                    _emprestimoRepository.Atualizar(emprestimo);
                    _logger.LogInformation($"Empréstimo devolvido: ID do Empréstimo: {devolucaoDto.EmprestimoId}, Data de Devolução: {devolucaoDto.DataDevolucao}");
                }
            }
        }

        public IEnumerable<DetalhesEmprestimoDto> ObterEmprestimosDoCliente(int clienteId)
        {
            var emprestimos = _emprestimoRepository.ObterTodos()
                                                     .Where(e => e.IdCliente == clienteId)
                                                     .Select(e => new DetalhesEmprestimoDto(e));
            _logger.LogInformation($"Obtendo empréstimos do cliente: ID do Cliente: {clienteId}, Quantidade de Empréstimos: {emprestimos.Count()}");

            foreach (var emprestimo in emprestimos)
            {
                _logger.LogInformation($"Empréstimo obtido: ID: {emprestimo.Id}, Nome do Cliente: {emprestimo.NomeCliente}, Nome do Catálogo: {emprestimo.NomeCatalogo}, Data de Empréstimo: {emprestimo.DataEmprestimo}, Data de Devolução: {emprestimo.DataDevolucao}");
            }

            return emprestimos.ToList();
        }
    }
}
