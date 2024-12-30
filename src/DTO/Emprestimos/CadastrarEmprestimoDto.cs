using Library.src.Models;
using System;

namespace Library.src.DTO.Emprestimos
{
    public class CadastrarEmprestimoDto
    {
        public int IdCatalogo { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; } 

        public Emprestimo ToEmprestimo(int idCliente, int idInventario)
        {
            return new Emprestimo(IdCatalogo, idCliente, idInventario, DataEmprestimo, DataDevolucao);
        }
    }
}
