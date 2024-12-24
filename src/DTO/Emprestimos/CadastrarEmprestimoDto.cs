using Library.src.Models;
using System;

namespace Library.src.DTO.Emprestimos
{
    public class CadastrarEmprestimoDto
    {
        public int IdCatalogo { get; set; }
        public DateTime DataEmprestimo { get; set; }

        public Emprestimo ToEmprestimo(int idCliente)
        {
            return new Emprestimo(IdCatalogo, idCliente, DataEmprestimo, DateTime.MinValue);
        }
    }
}
