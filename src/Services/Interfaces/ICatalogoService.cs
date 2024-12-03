public interface ICatalogoService{
    void AdicionarCatalogo(Catalogo catalogo);
    void RemoverCatalogo(Guid idCatalogo);
    Catalogo BuscarCatalogoPorId(Guid idCatalogo);
    IEnumerable<Catalogo> BuscarTodosOsCatalogos();
}