using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.src.Models
{
    public class Inventario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("catalogo_id")]
        public int CatalogoId { get; set; }

        [Column("quantidade_disponivel")]
        public int QuantidadeDisponivel { get; set; }

        [ForeignKey("CatalogoId")]
        public Catalogo Catalogo { get; set; } = null!; // Inicializando a propriedade como não nula
    }
}
