using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.src.Models
{
    public class Cliente
    {
        private int _id;
        private string _nome;
        private string _endereco;
        private string _telefone;
        private string _email;
        private DateTime _dataNascimento;
        private string _cpf;

        public Cliente(string nome, string endereco, string telefone, string email, DateTime dataNascimento, string cpf)
        {
            _nome = nome;
            _endereco = endereco;
            _telefone = telefone;
            _email = email;
            _dataNascimento = dataNascimento;
            _cpf = cpf;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }

        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public DateTime DataNascimento
        {
            get { return _dataNascimento; }
            set { _dataNascimento = value; }
        }

        public string CPF
        {
            get { return _cpf; }
            set { _cpf = value; }
        }
    }
}
