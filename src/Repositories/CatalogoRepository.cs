using Library.src.Models;
using Library.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.src.Repositories{
    public class CatalogoRepository : ICatalogoRepository
    {
        private readonly DbContext _context;

        public CatalogoRepository(DbContext context)
        {
            _context = context;
        }

        public Catalogo ObterPorId(int id)
        {
            return _context.Set<Catalogo>().Find(id);
        }

        public IEnumerable<Catalogo> ObterTodos()
        {
            return _context.Set<Catalogo>().ToList();
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

