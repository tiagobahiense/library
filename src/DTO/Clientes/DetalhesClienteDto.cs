using Library.src.Models;

namespace Library.src.DTO.Clientes
{
    public class DetalhesClienteDto
    {
        public int Id { get; }
        public string Nome { get; } = string.Empty;
        public string Email { get; } = string.Empty;
        public string Endereco { get; } = string.Empty;
        public string CPF { get; } = string.Empty;
        public DateTime DataNascimento { get; }
        public string Telefone { get; } = string.Empty;

        public DetalhesClienteDto(Cliente cliente)
        {
            Id = cliente.Id;
            Nome = cliente.Nome;
            Email = cliente.Email;
            Endereco = cliente.Endereco;
            CPF = cliente.CPF;
            DataNascimento = cliente.DataNascimento;
            Telefone = cliente.Telefone;
        }

        public Cliente ToCliente()
        {
            return new Cliente(Id, Nome, Endereco, Telefone, Email, DataNascimento, CPF);
        }
    }
}
