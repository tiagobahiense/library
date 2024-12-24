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

        public void Adicionar(CadastrarCatalogoDto catalogoDto)
        {
            var catalogo = catalogoDto.ToCatalogo();
            _catalogoRepository.Adicionar(catalogo);
        }

        public void Atualizar(AtualizarCatalogoDto catalogoDto, int id)
        {
            var catalogo = catalogoDto.ToCatalogo();
            catalogo.IdCatalogo = id;
            _catalogoRepository.Atualizar(catalogo);
        }

        public DetalhesCatalogoDto ObterPorId(int id)
        {
            var catalogo = _catalogoRepository.ObterPorId(id);
            return catalogo.ToDetalhesCatalogoDto();
        }

        public IEnumerable<DetalhesCatalogoDto> ObterTodos()
        {
            var catalogos = _catalogoRepository.ObterTodos();
            return catalogos.Select(c => c.ToDetalhesCatalogoDto()).ToList();
        }

        public void Remover(int id)
        {
            _catalogoRepository.Remover(id);
        }
    }
}
