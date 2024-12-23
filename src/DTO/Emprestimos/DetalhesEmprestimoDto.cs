using Library.src.Models;

namespace Library.src.DTO.Emprestimos
{
    public class DetalhesEmprestimoDto
    {
        public int IdInventario { get; }
        public int IdCliente { get; }
        public DateTime DataEmprestimo { get; }
        public DateTime DataDevolucao { get; }

        public DetalhesEmprestimoDto(Emprestimo emprestimo)
        {
            IdInventario = emprestimo.IdInventario;
            IdCliente = emprestimo.IdCliente;
            DataEmprestimo = emprestimo.DataEmprestimo;
            DataDevolucao = emprestimo.DataDevolucao;
        }

        public Emprestimo ToEmprestimo()
        {
            return new Emprestimo(IdInventario, IdCliente, DataEmprestimo, DataDevolucao);
        }
    }
}
