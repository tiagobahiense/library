using Library.src.DTO.Catalogos;
using Library.src.Models;
using Library.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.src.Repositories
{
    public class CatalogoRepository : ICatalogoRepository
    {
        private readonly DbContext _context;

        public CatalogoRepository(DbContext context)
        {
            _context = context;
        }

        public void Adicionar(CadastrarCatalogoDto catalogoDto)
        {
            var catalogo = catalogoDto.ToCatalogo();
            _context.Set<Catalogo>().Add(catalogo);
            _context.SaveChanges();
        }

        public void Atualizar(AtualizarCatalogoDto catalogoDto, int id)
        {
            var catalogo = ObterPorId(id)?.ToCatalogo();
            if (catalogo != null)
            {
                catalogo.Titulo = catalogoDto.Titulo;
                catalogo.Autor = catalogoDto.Autor;
                catalogo.AnoLancamento = catalogoDto.AnoLancamento;
                catalogo.Genero = catalogoDto.Genero;
                catalogo.NumeroPaginas = catalogoDto.NumeroPaginas;
                _context.Set<Catalogo>().Update(catalogo);
                _context.SaveChanges();
            }
        }

        public DetalhesCatalogoDto ObterPorId(int id)
        {
            var catalogo = _context.Set<Catalogo>().Find(id);
            return catalogo != null ? new DetalhesCatalogoDto(catalogo) : null;
        }

        public IEnumerable<DetalhesCatalogoDto> ObterTodos()
        {
            var catalogos = _context.Set<Catalogo>().ToList();
            return catalogos.Select(c => new DetalhesCatalogoDto(c));
        }

        public void Remover(int id)
        {
            var catalogo = ObterPorId(id)?.ToCatalogo();
            if (catalogo != null)
            {
                _context.Set<Catalogo>().Remove(catalogo);
                _context.SaveChanges();
            }
        }
    }
}
