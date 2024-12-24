using Library.src.Models;
using System.Collections.Generic;

namespace Library.src.Repositories.Interfaces
{
    public interface ICatalogoRepository
    {
        void Adicionar(Catalogo catalogo);
        void Atualizar(Catalogo catalogo);
        Catalogo ObterPorId(int id);
        IEnumerable<Catalogo> ObterTodos();
        void Remover(int id);
    }
}
