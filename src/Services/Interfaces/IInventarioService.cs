public interface IInventarioService {
    void AdicionarCatalogoAoInventario (int inventarioId, int catalogoId, int quantidade);
    void RemoverCatalogoDoInventario (int inventarioId, int catalogoId, int quantidade);
    Catalogo BuscaCatalogoPorId (int inventarioId, int catalogoId);
    int QuantidadeCatalogoNoInventario (int inventarioId, int catalogoId);

    
}