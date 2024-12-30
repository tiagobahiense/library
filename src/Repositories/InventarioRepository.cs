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

        public void Adicionar(Inventario inventario)
        {
            _context.Inventarios.Add(inventario);
            _context.SaveChanges();
        }

        public void Atualizar(Inventario inventario)
        {
            _context.Inventarios.Update(inventario);
            _context.SaveChanges();
        }

        public Inventario ObterPorId(int id)
        {
            return _context.Inventarios
                           .Include(i => i.Catalogo)
                           .FirstOrDefault(i => i.Id == id) ?? new Inventario();
        }

        public IEnumerable<Inventario> ObterTodos()
        {
            return _context.Inventarios
                           .Include(i => i.Catalogo)
                           .ToList();
        }

        public void AdicionarCatalogoAoInventario(int catalogoId, int quantidade)
        {
            var inventario = _context.Inventarios.FirstOrDefault(i => i.CatalogoId == catalogoId);
            if (inventario == null)
            {
                inventario = new Inventario
                {
                    CatalogoId = catalogoId,
                    QuantidadeDisponivel = quantidade
                };
                Adicionar(inventario);
            }
            else
            {
                inventario.QuantidadeDisponivel += quantidade;
                Atualizar(inventario);
            }
        }

        public void RemoverCatalogoDoInventario(int catalogoId, int quantidade)
        {
            var inventario = _context.Inventarios.FirstOrDefault(i => i.CatalogoId == catalogoId);
            if (inventario == null)
            {
                return;
            }

            inventario.QuantidadeDisponivel -= quantidade;
            if (inventario.QuantidadeDisponivel <= 0)
            {
                _context.Inventarios.Remove(inventario);
            }
            else
            {
                Atualizar(inventario);
            }
        }

        public int QuantidadeCatalogoNoInventario(int catalogoId)
        {
            var inventario = _context.Inventarios.FirstOrDefault(i => i.CatalogoId == catalogoId);
            if (inventario == null)
            {
                return 0;
            }
            return inventario.QuantidadeDisponivel;
        }
    }
}
