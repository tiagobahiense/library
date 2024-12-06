public interface ICatalogoService{
    void AdicionarCatalogo(CatalogoDto catalogoDto);
    void RemoverCatalogo(int catalogoId);
    CatalogoDto BuscarCatalogoPorId(int catalogoId);
    IEnumerable <CatalogoDto> BuscarTodosOsCatalogos();
}