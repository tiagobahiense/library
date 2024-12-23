using Library.src.DTO.Emprestimos;
using System.Collections.Generic;

namespace Library.src.Repositories.Interfaces
{
    public interface IEmprestimoRepository
    {
        DetalhesEmprestimoDto ObterPorId(int id);
        IEnumerable<DetalhesEmprestimoDto> ObterTodos();
        void Adicionar(CadastrarEmprestimoDto emprestimoDto);
        void Atualizar(CadastrarEmprestimoDto emprestimoDto, int id);
        void Remover(int id);
    }
}
