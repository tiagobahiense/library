using Library.src.DTO.Inventarios;
using System.Collections.Generic;

namespace Library.src.Service.Interfaces
{
    public interface IInventarioService
    {
        void AdicionarCatalogoAoInventario(int catalogoId, int quantidade);
        void RemoverCatalogoDoInventario(int catalogoId, int quantidade);
        int QuantidadeCatalogoNoInventario(int catalogoId);
        IEnumerable<DetalhesInventarioDto> ObterTodos();
    }
}
