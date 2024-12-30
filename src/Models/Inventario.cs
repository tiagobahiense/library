using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.src.Models
{
    public class Inventario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual ICollection<CatalogoInventario> ItensInventario { get; set; } = new List<CatalogoInventario>();
    }

    public class CatalogoInventario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("IdCatalogo")]
        public int IdCatalogo { get; set; }

        public int Quantidade { get; set; }

        [ForeignKey("IdCatalogo")]
        public virtual Catalogo? Catalogo { get; set; }

        [ForeignKey("InventarioId")]
        public int InventarioId { get; set; }

        [ForeignKey("InventarioId")]
        public virtual Inventario? Inventario { get; set; }
    }
}
