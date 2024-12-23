using Library.src.Models;
using System;

namespace Library.src.DTO.Emprestimos
{
    public class CadastrarEmprestimoDto
    {
        public int IdInventario { get; set; }
        public DateTime DataEmprestimo { get; set; }

        public Emprestimo ToEmprestimo(int idCliente)
        {
            return new Emprestimo(IdInventario, idCliente, DataEmprestimo, DateTime.MinValue);
        }
    }
}
