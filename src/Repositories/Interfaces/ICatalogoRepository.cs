using Library.src.Models;
using System.Collections.Generic;

namespace Library.src.Repositories.Interfaces
{
    public interface ICatalogoRepository
    {
        void Adicionar(Catalogo catalogo);
        void Remover(int catalogoId);
        Catalogo? ObterPorId(int id);
        IEnumerable<Catalogo> ObterTodos();
    }
}

