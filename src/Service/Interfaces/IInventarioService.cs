using Library.src.DTO.Catalogos;
using Library.src.DTO.Inventarios;

namespace Library.src.Service.Interfaces
{
    public interface IInventarioService
    {
        void AdicionarCatalogoAoInventario(int inventarioId, CadastrarInventarioDto cadastrarDto);
        void RemoverCatalogoDoInventario(int inventarioId, AtualizarInventarioDto atualizarDto);
        DetalhesCatalogoDto ObterDetalhesCatalogoNoInventario(int catalogoId);
        int QuantidadeCatalogoNoInventario(int inventarioId, int catalogoId);
        DetalhesInventarioDto ObterInventarioPorId(int inventarioId);
    }
}
