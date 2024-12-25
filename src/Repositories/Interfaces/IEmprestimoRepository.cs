using Library.src.Models;
using System.Collections.Generic;

namespace Library.src.Repositories.Interfaces
{
    public interface IEmprestimoRepository
    {
        void Adicionar(Emprestimo emprestimo);
        void Atualizar(Emprestimo emprestimo);
        Emprestimo? ObterPorId(int id);
        IEnumerable<Emprestimo> ObterTodos();
    }
}
