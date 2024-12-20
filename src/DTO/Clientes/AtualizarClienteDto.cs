using Library.src.Models;

namespace Library.src.DTO.Clientes
{
    public class AtualizarClienteDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty; 

        public Cliente ToCliente(int id, DateTime dataNascimento)
        {
            return new Cliente(id, Nome, Endereco, Telefone, Email, dataNascimento, CPF);
        }
    }
}
