using Library.src.Models;
using System.Collections.Generic;

namespace Library.src.Repositories.Interfaces
{
    public interface IInventarioRepository
    {
        void Adicionar(Inventario inventario);
        void Atualizar(Inventario inventario);
        Inventario ObterPorId(int id);
        IEnumerable<Inventario> ObterTodos();
        void Remover(int id);
    }
}
