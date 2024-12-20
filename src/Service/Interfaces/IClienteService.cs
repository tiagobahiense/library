using Library.src.DTO.Emprestimo;
using Library.src.DTO.Cliente;

namespace Library.src.Service.Interfaces{
        public interface IClienteService {
        void CadastrarCliente(CadastrarClienteDto clienteDto);
        void AtualizarCliente(int clienteId, AtualizarClienteDto clienteDto);
        DetalhesClienteDto ObterClientePorId(int clienteId);
        IEnumerable<DetalhesEmprestimoDto> ObterEmprestimosDoCliente(int clienteId);
    }
}
