using Library.src.DTO.Catalogo;

namespace Library.src.Service.Interfaces{
        public interface IInventarioService {
        void AdicionarCatalogoAoInventario (int inventarioId, int catalogoId, int quantidade);
        void RemoverCatalogoDoInventario (int inventarioId, int catalogoId, int quantidade);
        DetalhesCatalogoDto ObterDetalhesCatalogoNoInventario(int catalogoId);
        int QuantidadeCatalogoNoInventario (int inventarioId, int catalogoId);

        
    }
}
