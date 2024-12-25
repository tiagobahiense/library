using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.src.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Endereco { get; set; } = string.Empty;

        [Required]
        public string Telefone { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public DateTime DataNascimento { get; set; } = DateTime.Now;

        [Required]
        public string CPF { get; set; } = string.Empty;

        
        public Cliente()
        {
        }

        
        public Cliente(string nome, string endereco, string telefone, string email, DateTime dataNascimento, string cpf)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            DataNascimento = dataNascimento;
            CPF = cpf;
        }
    }
}
