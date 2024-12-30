using Library.src.DTO.Inventarios;
using Library.src.Models;
using Library.src.Repositories.Interfaces;
using Library.src.Service.Interfaces;

namespace Library.src.Service
{
    public class InventarioService : IInventarioService
    {
        private readonly IInventarioRepository _inventarioRepository;

        public InventarioService(IInventarioRepository inventarioRepository)
        {
            _inventarioRepository = inventarioRepository;
        }

        public void AdicionarCatalogoAoInventario(int idCatalogo, int quantidade)
        {
            _inventarioRepository.AdicionarCatalogoAoInventario(idCatalogo, quantidade);
        }

        public void RemoverCatalogoDoInventario(int idCatalogo, int quantidade)
        {
            _inventarioRepository.RemoverCatalogoDoInventario(idCatalogo, quantidade);
        }

        public int QuantidadeCatalogoNoInventario(int idCatalogo)
        {
            return _inventarioRepository.QuantidadeCatalogoNoInventario(idCatalogo);
        }
    }
}
