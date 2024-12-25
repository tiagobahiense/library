using Library.src.DTO.Inventarios;
using Library.src.Models;
using Library.src.Repositories.Interfaces;
using Library.src.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Library.src.Service
{
    public class InventarioService : IInventarioService
    {
        private readonly IInventarioRepository _inventarioRepository;

        public InventarioService(IInventarioRepository inventarioRepository)
        {
            _inventarioRepository = inventarioRepository;
        }

        public void AdicionarCatalogoAoInventario(int catalogoId, int quantidade)
        {
            _inventarioRepository.AdicionarCatalogoAoInventario(catalogoId, quantidade);
        }

        public void RemoverCatalogoDoInventario(int catalogoId, int quantidade)
        {
            _inventarioRepository.RemoverCatalogoDoInventario(catalogoId, quantidade);
        }

        public int QuantidadeCatalogoNoInventario(int catalogoId)
        {
            return _inventarioRepository.QuantidadeCatalogoNoInventario(catalogoId);
        }

        public IEnumerable<DetalhesInventarioDto> ObterTodos()
        {
            var inventarios = _inventarioRepository.ObterTodos();
            return inventarios.Select(i => DetalhesInventarioDto.FromInventario(i)).ToList();
        }
    }
}
