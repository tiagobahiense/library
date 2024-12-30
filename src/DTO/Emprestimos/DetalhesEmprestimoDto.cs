using Library.src.Models;
using System;

namespace Library.src.DTO.Emprestimos
{
    public class DetalhesEmprestimoDto
    {
        public int Id { get; set; }
        public string NomeCatalogo { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }

        public DetalhesEmprestimoDto(Emprestimo emprestimo)
        {
            Id = emprestimo.Id;
            NomeCatalogo = emprestimo.Catalogo.Titulo;
            NomeCliente = emprestimo.Cliente.Nome;
            DataEmprestimo = emprestimo.DataEmprestimo;
            DataDevolucao = emprestimo.DataDevolucao;
        }
    }
}
