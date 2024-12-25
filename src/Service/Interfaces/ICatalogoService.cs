using Library.src.DTO.Catalogos;
using System.Collections.Generic;

namespace Library.src.Service.Interfaces
{
    public interface ICatalogoService
    {
        void AdicionarCatalogo(CadastrarCatalogoDto catalogoDto);
        void RemoverCatalogo(int catalogoId);
        DetalhesCatalogoDto? BuscarCatalogoPorId(int catalogoId);
        IEnumerable<DetalhesCatalogoDto> ObterTodosCatalogos();
    }
}

