using Library.src.DTO.Catalogos;
using Library.src.Models;
using System.Collections.Generic;

namespace Library.src.Repositories.Interfaces
{
    public interface ICatalogoRepository
    {
        DetalhesCatalogoDto ObterPorId(int id);
        IEnumerable<DetalhesCatalogoDto> ObterTodos();
        void Adicionar(CadastrarCatalogoDto catalogoDto);
        void Atualizar(AtualizarCatalogoDto catalogoDto, int id);
        void Remover(int id);
    }
}
