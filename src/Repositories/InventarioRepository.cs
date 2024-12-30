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
            InicializarInventario();
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
                           .FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Inventario> ObterTodos()
        {
            return _context.Inventarios
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

            if (inventario.Itens.ContainsKey(idCatalogo))
            {
                inventario.Itens[idCatalogo] += quantidade;
            }
            else
            {
                inventario.Itens[idCatalogo] = quantidade;
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

            if (inventario.Itens.ContainsKey(idCatalogo))
            {
                inventario.Itens[idCatalogo] -= quantidade;
                if (inventario.Itens[idCatalogo] <= 0)
                {
                    inventario.Itens.Remove(idCatalogo);
                }
            }
            else
            {
                _logger.LogWarning($"Catálogo não encontrado no inventário. ID do Catálogo: {idCatalogo}");
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

            if (inventario.Itens.ContainsKey(idCatalogo))
            {
                return inventario.Itens[idCatalogo];
            }
            else
            {
                _logger.LogWarning($"Catálogo não encontrado no inventário. ID do Catálogo: {idCatalogo}");
                return 0;
            }
        }

        private void InicializarInventario()
        {
            var inventario = ObterPorId(1);
            if (inventario == null)
            {
                inventario = new Inventario();
                Adicionar(inventario);
            }
        }
    }
}
