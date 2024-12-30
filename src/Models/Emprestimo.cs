using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.src.Models
{
    public class Emprestimo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime DataEmprestimo { get; set; }

        [Required]
        public DateTime DataDevolucao { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public int IdCatalogo { get; set; }

        [Required]
        public int IdInventario { get; set; }

        [ForeignKey("IdCatalogo")]
        public Catalogo Catalogo { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }

        [ForeignKey("IdInventario")]
        public Inventario Inventario { get; set; }

        [NotMapped]
        public string NomeCliente => Cliente?.Nome;

        [NotMapped]
        public string NomeCatalogo => Catalogo?.Titulo;
    }
}
