using Library.src.DTO.Inventarios;
using Library.src.Repositories.Interfaces;

namespace Library.src.Service.Interfaces
{
    public interface IInventarioService
    {
        void AdicionarCatalogoAoInventario(int idCatalogo, int quantidade);
        void RemoverCatalogoDoInventario(int idCatalogo, int quantidade);
        int QuantidadeCatalogoNoInventario(int idCatalogo);
    }
}
