using Library.src.DTO.Inventarios;
using Library.src.Models;
using Library.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.src.Repositories
{
    public class InventarioRepository : IInventarioRepository
    {
        private readonly DbContext _context;

        public InventarioRepository(DbContext context)
        {
            _context = context;
        }

        public DetalhesInventarioDto ObterPorId(int id)
        {
            var inventario = _context.Set<Inventario>().Find(id);
            if (inventario != null)
            {
                return new DetalhesInventarioDto(inventario);
            }
            throw new KeyNotFoundException($"Inventario com ID {id} não encontrado.");
        }

        public IEnumerable<DetalhesInventarioDto> ObterTodos()
        {
            return _context.Set<Inventario>().Select(i => new DetalhesInventarioDto(i)).ToList();
        }

        public void Adicionar(CadastrarInventarioDto inventarioDto)
        {
            var inventario = inventarioDto.ToInventario(0); // Assumindo que o ID será gerado automaticamente
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
            var inventario = _context.Set<Inventario>().Find(id);
            if (inventario != null)
            {
                _context.Set<Inventario>().Remove(inventario);
                _context.SaveChanges();
            }
        }
    }
}
