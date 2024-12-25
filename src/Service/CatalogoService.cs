using Library.src.DTO.Catalogos;
using Library.src.Models;
using Library.src.Repositories.Interfaces;
using Library.src.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
            var catalogo = new Catalogo(catalogoDto.Titulo, catalogoDto.Autor, catalogoDto.AnoLancamento, catalogoDto.Genero, catalogoDto.NumeroPaginas);
            _catalogoRepository.Adicionar(catalogo);
        }

        public void RemoverCatalogo(int catalogoId)
        {
            _catalogoRepository.Remover(catalogoId);
        }

        public DetalhesCatalogoDto? BuscarCatalogoPorId(int idCatalogo)
        {
            var catalogo = _catalogoRepository.ObterPorId(idCatalogo);
            return catalogo != null ? DetalhesCatalogoDto.FromCatalogo(catalogo) : null;
        }

        public IEnumerable<DetalhesCatalogoDto> ObterTodosCatalogos()
        {
            var catalogos = _catalogoRepository.ObterTodos();
            return catalogos.Select(c => DetalhesCatalogoDto.FromCatalogo(c)).ToList();
        }
    }
}
