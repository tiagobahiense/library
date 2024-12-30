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

        [Column("IdCatalogo")]
        public int IdCatalogo { get; set; }

        public int IdCliente { get; set; }

        [Column("IdInventario")]
        public int IdInventario { get; set; }

        public DateTime DataEmprestimo { get; set; }

        public DateTime DataDevolucao { get; set; }

        [ForeignKey("IdCatalogo")]
        public virtual Catalogo? Catalogo { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente? Cliente { get; set; }

        [ForeignKey("IdInventario")]
        public virtual Inventario? Inventario { get; set; }
    }
}
