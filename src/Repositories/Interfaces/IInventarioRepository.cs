using Library.src.DTO.Inventarios;
using Library.src.Models;
using System.Collections.Generic;

namespace Library.src.Repositories.Interfaces
{
    public interface IInventarioRepository
    {
        DetalhesInventarioDto ObterPorId(int id);
        IEnumerable<DetalhesInventarioDto> ObterTodos();
        void Adicionar(CadastrarInventarioDto inventarioDto);
        void Atualizar(Inventario inventario);
        void Remover(int id);
    }
}
