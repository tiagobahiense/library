using Library.src.DTO.Catalogos;
using Library.src.Repositories.Interfaces;
using Library.src.Service.Interfaces;
using System.Collections.Generic;

namespace Library.src.Service
{
    public class CatalogoService : ICatalogoService
    {
        private readonly ICatalogoRepository _catalogoRepository;

        public CatalogoService(ICatalogoRepository catalogoRepository)
        {
            _catalogoRepository = catalogoRepository;
        }

        public void AdicionarCatalogo(CadastrarCatalogoDto catalogoDto)
        {
            _catalogoRepository.Adicionar(catalogoDto);
        }

        public void RemoverCatalogo(int catalogoId)
        {
            _catalogoRepository.Remover(catalogoId);
        }

        public DetalhesCatalogoDto BuscarCatalogoPorId(int catalogoId)
        {
            return _catalogoRepository.ObterPorId(catalogoId);
        }

        public IEnumerable<DetalhesCatalogoDto> BuscarTodosOsCatalogos()
        {
            return _catalogoRepository.ObterTodos();
        }
    }
}
