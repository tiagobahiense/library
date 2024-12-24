using Library.src.Data; 
using Library.src.DTO.Clientes;
using Library.src.Models;
using Library.src.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Library.src.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly LibraryContext _context;

        public ClienteRepository(LibraryContext context)
        {
            _context = context;
        }

        public void Adicionar(CadastrarClienteDto clienteDto)
        {
            var cliente = clienteDto.ToCliente();
            _context.Set<Cliente>().Add(cliente);
            _context.SaveChanges();
        }

        public void Atualizar(AtualizarClienteDto clienteDto, int id)
        {
            var cliente = ObterPorId(id);
            if (cliente != null)
            {
                cliente.Nome = clienteDto.Nome;
                cliente.Endereco = clienteDto.Endereco;
                cliente.Telefone = clienteDto.Telefone;
                cliente.Email = clienteDto.Email;
                cliente.DataNascimento = clienteDto.DataNascimento;
                cliente.CPF = clienteDto.CPF;
                _context.Set<Cliente>().Update(cliente);
                _context.SaveChanges();
            }
        }

        public Cliente ObterPorId(int id)
        {
            return _context.Set<Cliente>().Find(id) ?? new Cliente();
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _context.Set<Cliente>().ToList();
        }

        public void Remover(int id)
        {
            var cliente = ObterPorId(id);
            if (cliente != null)
            {
                _context.Set<Cliente>().Remove(cliente);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Emprestimo> ObterEmprestimosDoCliente(int clienteId)
        {
            return _context.Set<Emprestimo>().Where(e => e.IdCliente == clienteId).ToList();
        }
    }
}
