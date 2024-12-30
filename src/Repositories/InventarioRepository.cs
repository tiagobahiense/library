using Library.src.Models;
using Library.src.Data;
using Library.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Library.src.Repositories
{
    public class InventarioRepository : IInventarioRepository
    {
        private readonly LibraryContext _context;
        private readonly ILogger<InventarioRepository> _logger;

        public InventarioRepository(LibraryContext context, ILogger<InventarioRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Adicionar(Inventario inventario)
        {
            _context.Inventarios.Add(inventario);
            _context.SaveChanges();
            _logger.LogInformation($"Inventário adicionado: ID: {inventario.Id}");
        }

        public void Atualizar(Inventario inventario)
        {
            _context.Inventarios.Update(inventario);
            _context.SaveChanges();
            _logger.LogInformation($"Inventário atualizado: ID: {inventario.Id}");
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
            _logger.LogInformation($"Catálogo adicionado ao inventário com sucesso! ID do Catálogo: {catalogoId}, Quantidade: {quantidade}");
        }

        public void RemoverCatalogoDoInventario(int catalogoId, int quantidade)
        {
            var inventario = _context.Inventarios.FirstOrDefault(i => i.CatalogoId == catalogoId);
            if (inventario == null)
            {
                _logger.LogWarning($"Inventário não encontrado.");
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
            _logger.LogInformation($"Catálogo removido do inventário com sucesso! ID do Catálogo: {catalogoId}, Quantidade: {quantidade}");
        }

        public int QuantidadeCatalogoNoInventario(int catalogoId)
        {
            var inventario = _context.Inventarios.FirstOrDefault(i => i.CatalogoId == catalogoId);
            if (inventario == null)
            {
                _logger.LogWarning($"Catálogo não encontrado no inventário. ID do Catálogo: {catalogoId}");
                return 0;
            }
            return inventario.QuantidadeDisponivel;
        }
    }
}
