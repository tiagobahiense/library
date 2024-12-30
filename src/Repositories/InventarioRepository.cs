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
                           .Include(i => i.ItensInventario)
                           .FirstOrDefault(i => i.Id == id) ?? new Inventario();
        }

        public IEnumerable<Inventario> ObterTodos()
        {
            return _context.Inventarios
                           .Include(i => i.ItensInventario)
                           .ToList();
        }

        public void AdicionarCatalogoAoInventario(int idCatalogo, int quantidade)
        {
            var inventario = ObterPorId(1); // Supondo que você tenha apenas um inventário
            if (inventario == null)
            {
                inventario = new Inventario();
                Adicionar(inventario);
            }

            var itemInventario = inventario.ItensInventario.FirstOrDefault(i => i.IdCatalogo == idCatalogo);
            if (itemInventario == null)
            {
                itemInventario = new CatalogoInventario { IdCatalogo = idCatalogo, Quantidade = quantidade, InventarioId = inventario.Id };
                inventario.ItensInventario.Add(itemInventario);
            }
            else
            {
                itemInventario.Quantidade += quantidade;
            }

            Atualizar(inventario);
            _logger.LogInformation($"Catálogo adicionado ao inventário com sucesso! ID do Catálogo: {idCatalogo}, Quantidade: {quantidade}");
        }

        public void RemoverCatalogoDoInventario(int idCatalogo, int quantidade)
        {
            var inventario = ObterPorId(1); // Supondo que você tenha apenas um inventário
            if (inventario == null)
            {
                _logger.LogWarning($"Inventário não encontrado.");
                return;
            }

            var itemInventario = inventario.ItensInventario.FirstOrDefault(i => i.IdCatalogo == idCatalogo);
            if (itemInventario == null)
            {
                _logger.LogWarning($"Catálogo não encontrado no inventário. ID do Catálogo: {idCatalogo}");
                return;
            }

            itemInventario.Quantidade -= quantidade;
            if (itemInventario.Quantidade <= 0)
            {
                inventario.ItensInventario.Remove(itemInventario);
            }

            Atualizar(inventario);
            _logger.LogInformation($"Catálogo removido do inventário com sucesso! ID do Catálogo: {idCatalogo}, Quantidade: {quantidade}");
        }

        public int QuantidadeCatalogoNoInventario(int idCatalogo)
        {
            var inventario = ObterPorId(1); // Supondo que você tenha apenas um inventário
            if (inventario == null)
            {
                _logger.LogWarning($"Inventário não encontrado.");
                return 0;
            }

            var itemInventario = inventario.ItensInventario.FirstOrDefault(i => i.IdCatalogo == idCatalogo);
            if (itemInventario == null)
            {
                _logger.LogWarning($"Catálogo não encontrado no inventário. ID do Catálogo: {idCatalogo}");
                return 0;
            }

            return itemInventario.Quantidade;
        }
    }
}
