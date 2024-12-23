using Library.src.Models;

namespace Library.src.DTO.Emprestimos
{
    public class DevolucaoEmprestimoDto
    {
        public int CatalogoId { get; set; }
        public int QuantidadeDevolvida { get; set; }
        public DateTime DataDevolucao { get; set; }

        public Emprestimo ToEmprestimo(int idCliente, DateTime dataEmprestimo)
        {
            return new Emprestimo(CatalogoId, idCliente, dataEmprestimo, DataDevolucao);
        }
    }
}
