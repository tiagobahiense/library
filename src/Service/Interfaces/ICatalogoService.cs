using Library.src.DTO.Catalogo;

namespace Library.src.Service.Interfaces{
        public interface ICatalogoService{
        void AdicionarCatalogo(CadastrarCatalogoDto catalogoDto);
        void RemoverCatalogo(int catalogoId);
        DetalhesCatalogoDto BuscarCatalogoPorId(int catalogoId);
        IEnumerable <DetalhesCatalogoDto> BuscarTodosOsCatalogos();
    }
}
