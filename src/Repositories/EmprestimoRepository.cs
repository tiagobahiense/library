using Library.src.Models;
using Library.src.Data;
using Library.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.src.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly LibraryContext _context;

        public EmprestimoRepository(LibraryContext context)
        {
            _context = context;
        }

        public void Adicionar(Emprestimo emprestimo)
        {
            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();
        }

        public void Atualizar(Emprestimo emprestimo)
        {
            _context.Emprestimos.Update(emprestimo);
            _context.SaveChanges();
        }

        public Emprestimo? ObterPorId(int id)
        {
            return _context.Emprestimos
                            .Include(e => e.Catalogo)
                            .Include(e => e.Cliente)
                            .FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Emprestimo> ObterTodos()
        {
            return _context.Emprestimos
                            .Include(e => e.Catalogo)
                            .Include(e => e.Cliente)
                            .ToList();
        }
    }
}
