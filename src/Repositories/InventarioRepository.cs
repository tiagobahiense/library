using Library.src.Models;
using Library.src.Data;
using Library.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public void AdicionarCatalogoAoInventario(int catalogoId, int quantidade)
        {
            var inventario = ObterPorId(catalogoId);
            if (inventario == null)
            {
                inventario = new Inventario { Id = catalogoId, Itens = new Dictionary<int, int> { { catalogoId, quantidade } } };
                _context.Inventarios.Add(inventario);
            }
            else
            {
                if (inventario.Itens.ContainsKey(catalogoId))
                {
                    inventario.Itens[catalogoId] += quantidade;
                }
                else
                {
                    inventario.Itens.Add(catalogoId, quantidade);
                }
            }
            _context.SaveChanges();
        }

        public void RemoverCatalogoDoInventario(int catalogoId, int quantidade)
        {
            var inventario = ObterPorId(catalogoId);
            if (inventario != null && inventario.Itens.ContainsKey(catalogoId))
            {
                inventario.Itens[catalogoId] -= quantidade;
                if (inventario.Itens[catalogoId] <= 0)
                {
                    inventario.Itens.Remove(catalogoId);
                }
                _context.SaveChanges();
            }
        }

        public Inventario? ObterPorId(int id)
        {
            return _context.Inventarios.Find(id);
        }

        public int QuantidadeCatalogoNoInventario(int catalogoId)
        {
            var inventario = ObterPorId(catalogoId);
            return inventario?.Itens.ContainsKey(catalogoId) == true ? inventario.Itens[catalogoId] : 0;
        }

        public IEnumerable<Inventario> ObterTodos()
        {
            return _context.Inventarios.ToList();
        }
    }
}
