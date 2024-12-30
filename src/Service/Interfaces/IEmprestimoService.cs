using Library.src.Models;
using Library.src.DTO.Emprestimos;
using System.Collections.Generic;

namespace Library.src.Service.Interfaces
{
    public interface IEmprestimoService
    {
        void Adicionar(Emprestimo emprestimo);
        void Atualizar(Emprestimo emprestimo);
        Emprestimo ObterPorId(int id);
        IEnumerable<Emprestimo> ObterTodos();
        IEnumerable<Emprestimo> ObterPorClienteId(int clienteId);
        void Remover(int id);
        void RegistrarEmprestimo(int clienteId, List<CadastrarEmprestimoDto> emprestimosDto);
        void DevolverEmprestimo(int clienteId, List<DevolucaoEmprestimoDto> devolucoesDto);
        IEnumerable<Emprestimo> ObterEmprestimosDoCliente(int clienteId);
    }
}
