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
            return inventario.ToDetalhesInventarioDto();
        }

        public IEnumerable<DetalhesInventarioDto> ObterTodos()
        {
            var inventarios = _inventarioRepository.ObterTodos();
            return inventarios.Select(i => i.ToDetalhesInventarioDto()).ToList();
        }

        public void Remover(int id)
        {
            _inventarioRepository.Remover(id);
        }
    }
}
