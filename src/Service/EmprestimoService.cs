using Library.src.Models;
using Library.src.Repositories.Interfaces;
using Library.src.Service.Interfaces;
using Library.src.DTO.Emprestimos;
using System.Collections.Generic;
using System.Linq;

namespace Library.src.Service
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _repository;

        public EmprestimoService(IEmprestimoRepository repository)
        {
            _repository = repository;
        }

        public void Adicionar(Emprestimo emprestimo)
        {
            _repository.Adicionar(emprestimo);
        }

        public void Atualizar(Emprestimo emprestimo)
        {
            _repository.Atualizar(emprestimo);
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
            return _repository.ObterPorClienteId(clienteId);
        }

        public void Remover(int id)
        {
            _repository.Remover(id);
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
