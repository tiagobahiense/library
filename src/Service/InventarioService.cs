using Library.src.DTO.Catalogos;
using Library.src.DTO.Inventarios;
using Library.src.Models;
using Library.src.Repositories.Interfaces;
using Library.src.Service.Interfaces;
using System.Linq;

namespace Library.src.Service
{
    public class InventarioService : IInventarioService
    {
        private readonly IInventarioRepository _inventarioRepository;
        private readonly ICatalogoRepository _catalogoRepository;

        public InventarioService(IInventarioRepository inventarioRepository, ICatalogoRepository catalogoRepository)
        {
            _inventarioRepository = inventarioRepository;
            _catalogoRepository = catalogoRepository;
        }

        public void AdicionarCatalogoAoInventario(int inventarioId, CadastrarInventarioDto cadastrarDto)
        {
            var inventario = _inventarioRepository.ObterPorId(inventarioId);
            if (inventario != null)
            {
                foreach (var item in cadastrarDto.Itens)
                {
                    if (inventario.Itens.ContainsKey(item.Key))
                    {
                        inventario.Itens[item.Key] += item.Value;
                    }
                    else
                    {
                        inventario.Itens[item.Key] = item.Value;
                    }
                }
                _inventarioRepository.Atualizar(inventario.ToInventario());
            }
        }

        public void RemoverCatalogoDoInventario(int inventarioId, AtualizarInventarioDto atualizarDto)
        {
            var inventario = _inventarioRepository.ObterPorId(inventarioId);
            if (inventario != null)
            {
                foreach (var item in atualizarDto.Itens)
                {
                    if (inventario.Itens.ContainsKey(item.Key))
                    {
                        if (inventario.Itens[item.Key] > item.Value)
                        {
                            inventario.Itens[item.Key] -= item.Value;
                        }
                        else
                        {
                            inventario.Itens.Remove(item.Key);
                        }
                    }
                }
                _inventarioRepository.Atualizar(inventario.ToInventario());
            }
        }

        public DetalhesCatalogoDto ObterDetalhesCatalogoNoInventario(int catalogoId)
        {
            return _catalogoRepository.ObterPorId(catalogoId);
        }

        public int QuantidadeCatalogoNoInventario(int inventarioId, int catalogoId)
        {
            var inventario = _inventarioRepository.ObterPorId(inventarioId);
            return inventario != null && inventario.Itens.ContainsKey(catalogoId) ? inventario.Itens[catalogoId] : 0;
        }

        public DetalhesInventarioDto ObterInventarioPorId(int inventarioId)
        {
            return _inventarioRepository.ObterPorId(inventarioId);
        }
    }
}
