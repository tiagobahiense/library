using Library.src.DTO.Emprestimos;
using Library.src.Models;
using Library.src.Repositories.Interfaces;
using Library.src.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Library.src.Service
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;

        public EmprestimoService(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }

        public void RegistrarEmprestimo(int clienteId, List<CadastrarEmprestimoDto> emprestimos)
        {
            foreach (var emprestimoDto in emprestimos)
            {
                var emprestimo = emprestimoDto.ToEmprestimo(clienteId);
                _emprestimoRepository.Adicionar(emprestimo);
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
                }
            }
        }

        public IEnumerable<DetalhesEmprestimoDto> ObterEmprestimosDoCliente(int clienteId)
        {
            return _emprestimoRepository.ObterTodos()
                                         .Where(e => e.IdCliente == clienteId)
                                         .Select(e => new DetalhesEmprestimoDto(e));
        }
    }
}
