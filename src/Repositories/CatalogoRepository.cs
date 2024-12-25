using Library.src.Models;
using Library.src.Data;
using Library.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.src.Repositories
{
    public class CatalogoRepository : ICatalogoRepository
    {
        private readonly LibraryContext _context;

        public CatalogoRepository(LibraryContext context)
        {
            _context = context;
        }

        public void Adicionar(Catalogo catalogo)
        {
            _context.Catalogos.Add(catalogo);
            _context.SaveChanges();
        }

        public void Remover(int catalogoId)
        {
            var catalogo = ObterPorId(catalogoId);
            if (catalogo != null)
            {
                _context.Catalogos.Remove(catalogo);
                _context.SaveChanges();
            }
        }

        public Catalogo? ObterPorId(int id)
        {
            return _context.Catalogos.Find(id);
        }

        public IEnumerable<Catalogo> ObterTodos()
        {
            return _context.Catalogos.ToList();
        }
    }
}

