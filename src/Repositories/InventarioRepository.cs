using Library.src.Data;
using Library.src.Models;
using Library.src.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Library.src.Repositories
{
    public class InventarioRepository : IInventarioRepository
    {
        private readonly LibraryContext _context;

        public InventarioRepository(LibraryContext context)
        {
            _context = context;
        }

        public void Adicionar(Inventario inventario)
        {
            _context.Set<Inventario>().Add(inventario);
            _context.SaveChanges();
        }

        public void Atualizar(Inventario inventario)
        {
            _context.Set<Inventario>().Update(inventario);
            _context.SaveChanges();
        }

        public Inventario ObterPorId(int id)
        {
            return _context.Set<Inventario>().Find(id) ?? new Inventario();
        }

        public IEnumerable<Inventario> ObterTodos()
        {
            return _context.Set<Inventario>().ToList();
        }

        public void Remover(int id)
        {
            var inventario = ObterPorId(id);
            if (inventario != null)
            {
                _context.Set<Inventario>().Remove(inventario);
                _context.SaveChanges();
            }
        }
    }
}
