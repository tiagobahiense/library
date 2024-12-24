using Library.src.DTO.Inventarios;
using System.Collections.Generic;

namespace Library.src.Service.Interfaces
{
    public interface IInventarioService
    {
        void Adicionar(CadastrarInventarioDto inventarioDto);
        void Atualizar(AtualizarInventarioDto inventarioDto, int id);
        DetalhesInventarioDto ObterPorId(int id);
        IEnumerable<DetalhesInventarioDto> ObterTodos();
        void Remover(int id);
    }
}

