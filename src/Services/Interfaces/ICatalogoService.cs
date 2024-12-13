using Livraria.Dtos.Catalogo;
public interface ICatalogoService{
    void AdicionarCatalogo(CadastrarCatalogoDto catalogoDto);
    void RemoverCatalogo(int catalogoId);
    DetalhesCatalogoDto BuscarCatalogoPorId(int catalogoId);
    IEnumerable <DetalhesCatalogoDto> BuscarTodosOsCatalogos();
}