using Library.src.Models;
using System;

namespace Library.src.DTO.Clientes
{
    public class DetalhesClienteDto
    {
        public int Id { get; }
        public string Nome { get; }
        public string Endereco { get; }
        public string Telefone { get; }
        public string Email { get; }
        public DateTime DataNascimento { get; }
        public string CPF { get; }

        public DetalhesClienteDto(Cliente cliente)
        {
            Id = cliente.Id;
            Nome = cliente.Nome;
            Endereco = cliente.Endereco;
            Telefone = cliente.Telefone;
            Email = cliente.Email;
            DataNascimento = cliente.DataNascimento;
            CPF = cliente.CPF;
        }
    }
}
