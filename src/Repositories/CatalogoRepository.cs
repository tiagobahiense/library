using Library.src.Data;
using Library.src.Models;
using Library.src.Repositories.Interfaces;
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
            _context.Set<Catalogo>().Add(catalogo);
            _context.SaveChanges();
        }

        public void Atualizar(Catalogo catalogo)
        {
            _context.Set<Catalogo>().Update(catalogo);
            _context.SaveChanges();
        }

        public Catalogo ObterPorId(int id)
        {
            return _context.Set<Catalogo>().Find(id) ?? new Catalogo("", "", 0, "", 0);
        }

        public IEnumerable<Catalogo> ObterTodos()
        {
            return _context.Set<Catalogo>().ToList();
        }

        public void Remover(int id)
        {
            var catalogo = ObterPorId(id);
            if (catalogo != null)
            {
                _context.Set<Catalogo>().Remove(catalogo);
                _context.SaveChanges();
            }
        }
    }
}
