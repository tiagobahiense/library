using Library.src.DTO.Clientes;
using Library.src.Models;
using System.Collections.Generic;

namespace Library.src.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Cliente ObterPorId(int id);
        IEnumerable<Cliente> ObterTodos();
        void Adicionar(CadastrarClienteDto clienteDto);
        void Atualizar(AtualizarClienteDto clienteDto, int id);
        void Remover(int id);
        IEnumerable<Emprestimo> ObterEmprestimosDoCliente(int clienteId);
    }
}
