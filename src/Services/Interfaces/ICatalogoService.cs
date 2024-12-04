public interface ICatalogoService{
    void AdicionarCatalogo(Catalogo catalogo);
    void RemoverCatalogo(int idCatalogo);
    Catalogo BuscarCatalogoPorId(int idCatalogo);
    IEnumerable <Catalogo> BuscarTodosOsCatalogos();
}