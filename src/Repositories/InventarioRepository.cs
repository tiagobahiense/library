using Library.src.Models;
using Library.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.src.Repositories{
        public class InventarioRepository : IInventarioRepository
    {
        private readonly DbContext _context;

        public InventarioRepository(DbContext context)
        {
            _context = context;
        }

        public Inventario ObterPorId(int id)
        {
            return _context.Set<Inventario>().Find(id);
        }

        public IEnumerable<Inventario> ObterTodos()
        {
            return _context.Set<Inventario>().ToList();
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

