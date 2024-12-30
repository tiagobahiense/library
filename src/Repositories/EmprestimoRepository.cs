using Library.src.Models;
using Library.src.Data;
using Library.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Library.src.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly LibraryContext _context;
        private readonly ILogger<EmprestimoRepository> _logger;

        public EmprestimoRepository(LibraryContext context, ILogger<EmprestimoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Adicionar(Emprestimo emprestimo)
        {
            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();
            _logger.LogInformation($"Empréstimo adicionado: ID: {emprestimo.Id}");
        }

        public void Atualizar(Emprestimo emprestimo)
        {
            _context.Emprestimos.Update(emprestimo);
            _context.SaveChanges();
            _logger.LogInformation($"Empréstimo atualizado: ID: {emprestimo.Id}");
        }

        public Emprestimo ObterPorId(int id)
        {
            return _context.Emprestimos
                           .Include(e => e.Catalogo)
                           .Include(e => e.Cliente)
                           .Include(e => e.Inventario)
                           .FirstOrDefault(e => e.Id == id) ?? new Emprestimo();
        }

        public IEnumerable<Emprestimo> ObterTodos()
        {
            return _context.Emprestimos
                           .Include(e => e.Catalogo)
                           .Include(e => e.Cliente)
                           .Include(e => e.Inventario)
                           .ToList();
        }

        public IEnumerable<Emprestimo> ObterPorClienteId(int clienteId)
        {
            return _context.Emprestimos
                           .Include(e => e.Catalogo)
                           .Include(e => e.Cliente)
                           .Include(e => e.Inventario)
                           .Where(e => e.IdCliente == clienteId)
                           .ToList();
        }

        public void Remover(int id)
        {
            var emprestimo = ObterPorId(id);
            if (emprestimo != null)
            {
                _context.Emprestimos.Remove(emprestimo);
                _context.SaveChanges();
                _logger.LogInformation($"Empréstimo removido: ID: {id}");
            }
        }
    }
}
