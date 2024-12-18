using Livraria.Dtos.Emprestimo;
using Livraria.Dtos.Cliente;
public interface IClienteService {
    void CadastrarCliente(CadastrarClienteDto clienteDto);
    void AtualizarCliente(int clienteId, AtualizarClienteDto clienteDto);
    DetalhesClienteDto ObterClientePorId(int clienteId);
    IEnumerable<DetalhesEmprestimoDto> ObterEmprestimosDoCliente(int clienteId);
}