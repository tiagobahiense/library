using Library.src.Models;

namespace Library.src.Repositories.Interfaces
{
    public interface IInventarioRepository
    {
        void Adicionar(Inventario inventario);
        void Atualizar(Inventario inventario);
        Inventario ObterPorId(int id);
        IEnumerable<Inventario> ObterTodos();
        void AdicionarCatalogoAoInventario(int idCatalogo, int quantidade);
        void RemoverCatalogoDoInventario(int idCatalogo, int quantidade);
        int QuantidadeCatalogoNoInventario(int idCatalogo);
    }
}

