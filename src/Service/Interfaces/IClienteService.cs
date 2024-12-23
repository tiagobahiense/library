using Library.src.DTO.Clientes;
using Library.src.DTO.Emprestimos;
using System.Collections.Generic;

namespace Library.src.Service.Interfaces
{
    public interface IClienteService
    {
        void CadastrarCliente(CadastrarClienteDto clienteDto);
        void AtualizarCliente(int clienteId, AtualizarClienteDto clienteDto);
        DetalhesClienteDto ObterClientePorId(int clienteId);
        IEnumerable<DetalhesEmprestimoDto> ObterEmprestimosDoCliente(int clienteId);
    }
}
