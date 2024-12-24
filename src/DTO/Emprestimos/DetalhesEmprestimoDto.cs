using System;
using Library.src.Models;

namespace Library.src.DTO.Emprestimos
{
    public class DetalhesEmprestimoDto
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public string NomeCatalogo { get; set; }
        public string NomeCliente { get; set; }

        public DetalhesEmprestimoDto(Emprestimo emprestimo)
        {
            Id = emprestimo.Id;
            DataEmprestimo = emprestimo.DataEmprestimo;
            DataDevolucao = emprestimo.DataDevolucao;
            NomeCatalogo = emprestimo.Catalogo != null ? emprestimo.Catalogo.Titulo : "Desconhecido";
            NomeCliente = emprestimo.Cliente != null ? emprestimo.Cliente.Nome : "Desconhecido";
        }
    }
}
