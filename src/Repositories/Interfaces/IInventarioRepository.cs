using Library.src.Models;
using System.Collections.Generic;

namespace Library.src.Repositories.Interfaces
{
    public interface IInventarioRepository
    {
        void AdicionarCatalogoAoInventario(int catalogoId, int quantidade);
        void RemoverCatalogoDoInventario(int catalogoId, int quantidade);
        Inventario? ObterPorId(int id);
        int QuantidadeCatalogoNoInventario(int catalogoId);
        IEnumerable<Inventario> ObterTodos();
    }
}
