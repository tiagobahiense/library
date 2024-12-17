namespace Library.Repositories.Interfaces
{
    public interface IEmprestimoRepository
    {
        Emprestimo ObterPorId(int id);
        IEnumerable<Emprestimo> ObterTodos();
        void Adicionar(Emprestimo emprestimo);
        void Atualizar(Emprestimo emprestimo);
        void Remover(int id);
    }
}

