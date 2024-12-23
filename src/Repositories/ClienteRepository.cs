using Library.src.DTO.Clientes;
using Library.src.Models;
using Library.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.src.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbContext _context;

        public ClienteRepository(DbContext context)
        {
            _context = context;
        }

        public DetalhesClienteDto ObterPorId(int id)
        {
            var cliente = _context.Set<Cliente>().Find(id);
            if (cliente != null)
            {
                return new DetalhesClienteDto(cliente);
            }
            throw new KeyNotFoundException($"Cliente com ID {id} não encontrado.");
        }

        public IEnumerable<DetalhesClienteDto> ObterTodos()
        {
            return _context.Set<Cliente>().Select(c => new DetalhesClienteDto(c)).ToList();
        }

        public void Adicionar(CadastrarClienteDto clienteDto)
        {
            var cliente = clienteDto.ToCliente(0);
            _context.Set<Cliente>().Add(cliente);
            _context.SaveChanges();
        }

        public void Atualizar(AtualizarClienteDto clienteDto, int id)
        {
            var cliente = _context.Set<Cliente>().Find(id);
            if (cliente != null)
            {
                cliente.Nome = clienteDto.Nome;
                cliente.Email = clienteDto.Email;
                cliente.Endereco = clienteDto.Endereco;
                cliente.Telefone = clienteDto.Telefone;
                cliente.CPF = clienteDto.CPF;
                _context.Set<Cliente>().Update(cliente);
                _context.SaveChanges();
            }
        }

        public void Remover(int id)
        {
            var cliente = _context.Set<Cliente>().Find(id);
            if (cliente != null)
            {
                _context.Set<Cliente>().Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}
