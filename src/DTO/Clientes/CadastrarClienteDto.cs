using Library.src.Models;
using System;

namespace Library.src.DTO.Clientes
{
    public class CadastrarClienteDto
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }

        public CadastrarClienteDto(string nome, string endereco, string telefone, string email, DateTime dataNascimento, string cpf)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            DataNascimento = dataNascimento;
            CPF = cpf;
        }

        public Cliente ToCliente()
        {
            return new Cliente(Nome, Endereco, Telefone, Email, DataNascimento, CPF);
        }
    }
}
