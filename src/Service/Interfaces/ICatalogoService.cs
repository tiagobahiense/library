using Library.src.DTO.Catalogos;
using System.Collections.Generic;

namespace Library.src.Service.Interfaces
{
    public interface ICatalogoService
    {
        void Adicionar(CadastrarCatalogoDto catalogoDto);
        void Atualizar(AtualizarCatalogoDto catalogoDto, int id);
        DetalhesCatalogoDto ObterPorId(int id);
        IEnumerable<DetalhesCatalogoDto> ObterTodos();
        void Remover(int id);
    }
}
