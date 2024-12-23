using Library.src.DTO.Inventarios;
using System.Collections.Generic;

namespace Library.src.Repositories.Interfaces
{
    public interface IInventarioRepository
    {
        DetalhesInventarioDto ObterPorId(int id);
        IEnumerable<DetalhesInventarioDto> ObterTodos();
        void Adicionar(CadastrarInventarioDto inventarioDto);
        void Atualizar(AtualizarInventarioDto inventarioDto, int id);
        void Remover(int id);
    }
}


