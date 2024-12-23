using Library.src.Models;
using System;

namespace Library.src.DTO.Emprestimos
{
    public class DetalhesEmprestimoDto
    {
        public int Id { get; }
        public int IdInventario { get; }
        public int IdCliente { get; }
        public DateTime DataEmprestimo { get; }
        public DateTime DataDevolucao { get; }

        public DetalhesEmprestimoDto(Emprestimo emprestimo)
        {
            Id = emprestimo.Id;
            IdInventario = emprestimo.IdInventario;
            IdCliente = emprestimo.IdCliente;
            DataEmprestimo = emprestimo.DataEmprestimo;
            DataDevolucao = emprestimo.DataDevolucao;
        }
    }
}

