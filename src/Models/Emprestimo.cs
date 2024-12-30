using System;
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
        public int IdCatalogo { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public int IdInventario { get; set; }

        [ForeignKey("IdCatalogo")]
        [Required]
        public Catalogo Catalogo { get; set; } = null!; 

        [ForeignKey("IdCliente")]
        [Required]
        public Cliente Cliente { get; set; } = null!; 

        [ForeignKey("IdInventario")]
        [Required]
        public Inventario Inventario { get; set; } = null!; 

        [NotMapped]
        public string NomeCliente => Cliente?.Nome ?? string.Empty;

        [NotMapped]
        public string NomeCatalogo => Catalogo?.Titulo ?? string.Empty;
    }
}
