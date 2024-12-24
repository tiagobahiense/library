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

        public void Adicionar(CadastrarInventarioDto inventarioDto)
        {
            var inventario = inventarioDto.ToInventario();
            _inventarioRepository.Adicionar(inventario);
        }

        public void Atualizar(AtualizarInventarioDto inventarioDto, int id)
        {
            var inventario = inventarioDto.ToInventario(id);
            _inventarioRepository.Atualizar(inventario);
        }

        public DetalhesInventarioDto ObterPorId(int id)
        {
            var inventario = _inventarioRepository.ObterPorId(id);
            return DetalhesInventarioDto.FromInventario(inventario);
        }

        public IEnumerable<DetalhesInventarioDto> ObterTodos()
        {
            var inventarios = _inventarioRepository.ObterTodos();
            return inventarios.Select(i => DetalhesInventarioDto.FromInventario(i)).ToList();
        }

        public void Remover(int id)
        {
            _inventarioRepository.Remover(id);
        }

        public void AdicionarCatalogoAoInventario(int catalogoId, int quantidade)
        {
            var inventario = _inventarioRepository.ObterPorId(catalogoId);
            if (inventario != null)
            {
                if (inventario.Itens.ContainsKey(catalogoId))
                {
                    inventario.Itens[catalogoId] += quantidade;
                }
                else
                {
                    inventario.Itens.Add(catalogoId, quantidade);
                }
                _inventarioRepository.Atualizar(inventario);
            }
        }

        public void RemoverCatalogoDoInventario(int catalogoId, int quantidade)
        {
            var inventario = _inventarioRepository.ObterPorId(catalogoId);
            if (inventario != null && inventario.Itens.ContainsKey(catalogoId))
            {
                if (inventario.Itens[catalogoId] > quantidade)
                {
                    inventario.Itens[catalogoId] -= quantidade;
                }
                else
                {
                    inventario.Itens.Remove(catalogoId);
                }
                _inventarioRepository.Atualizar(inventario);
            }
        }

        public int QuantidadeCatalogoNoInventario(int catalogoId)
        {
            var inventario = _inventarioRepository.ObterPorId(catalogoId);
            if (inventario != null && inventario.Itens.ContainsKey(catalogoId))
            {
                return inventario.Itens[catalogoId];
            }
            return 0;
        }
    }
}
