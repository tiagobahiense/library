using Library.src.DTO.Inventarios;
using Library.src.Models;
using Library.src.Repositories.Interfaces;
using Library.src.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace Library.src.Service
{
    public class InventarioService : IInventarioService
    {
        private readonly IInventarioRepository _inventarioRepository;
        private readonly ILogger<InventarioService> _logger;

        public InventarioService(IInventarioRepository inventarioRepository, ILogger<InventarioService> logger)
        {
            _inventarioRepository = inventarioRepository;
            _logger = logger;
        }

        public void AdicionarCatalogoAoInventario(int idCatalogo, int quantidade)
        {
            _inventarioRepository.AdicionarCatalogoAoInventario(idCatalogo, quantidade);
            _logger.LogInformation($"Catálogo adicionado ao inventário com sucesso! ID do Catálogo: {idCatalogo}, Quantidade: {quantidade}");
        }

        public void RemoverCatalogoDoInventario(int idCatalogo, int quantidade)
        {
            _inventarioRepository.RemoverCatalogoDoInventario(idCatalogo, quantidade);
            _logger.LogInformation($"Catálogo removido do inventário com sucesso! ID do Catálogo: {idCatalogo}, Quantidade: {quantidade}");
        }

        public int QuantidadeCatalogoNoInventario(int idCatalogo)
        {
            return _inventarioRepository.QuantidadeCatalogoNoInventario(idCatalogo);
        }
    }
}
