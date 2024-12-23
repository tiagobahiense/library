using Library.src.DTO.Clientes;
using System.Collections.Generic;

namespace Library.src.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        DetalhesClienteDto ObterPorId(int id);
        IEnumerable<DetalhesClienteDto> ObterTodos();
        void Adicionar(CadastrarClienteDto clienteDto);
        void Atualizar(AtualizarClienteDto clienteDto, int id);
        void Remover(int id);
    }
}
