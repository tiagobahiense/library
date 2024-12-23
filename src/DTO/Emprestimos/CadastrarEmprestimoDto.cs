using Library.src.Models;

namespace Library.src.DTO.Emprestimos
{
    public class CadastrarEmprestimoDto
    {
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }

        public Emprestimo ToEmprestimo(int idInventario, int idCliente)
        {
            return new Emprestimo(idInventario, idCliente, DataEmprestimo, DataDevolucao);
        }
    }
}
