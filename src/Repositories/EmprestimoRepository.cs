using Library.src.Data;
using Library.src.Models;
using Library.src.Repositories.Interfaces;
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
            _context.Set<Emprestimo>().Add(emprestimo);
            _context.SaveChanges();
        }

        public void Atualizar(Emprestimo emprestimo)
        {
            _context.Set<Emprestimo>().Update(emprestimo);
            _context.SaveChanges();
        }

        public Emprestimo ObterPorId(int id)
        {
            return _context.Set<Emprestimo>().Find(id) ?? new Emprestimo(0, 0, DateTime.Now, DateTime.Now);
        }

        public IEnumerable<Emprestimo> ObterTodos()
        {
            return _context.Set<Emprestimo>().ToList();
        }

        public void Remover(int id)
        {
            var emprestimo = ObterPorId(id);
            if (emprestimo != null)
            {
                _context.Set<Emprestimo>().Remove(emprestimo);
                _context.SaveChanges();
            }
        }
    }
}
