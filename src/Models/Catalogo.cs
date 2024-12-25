using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.src.Models
{
    public class Catalogo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public string Autor { get; set; } = string.Empty;

        [Required]
        public int AnoLancamento { get; set; }

        [Required]
        public string Genero { get; set; } = string.Empty;

        [Required]
        public int NumeroPaginas { get; set; }

        
        public Catalogo()
        {
        }

        
        public Catalogo(string titulo, string autor, int anoLancamento, string genero, int numeroPaginas)
        {
            Titulo = titulo;
            Autor = autor;
            AnoLancamento = anoLancamento;
            Genero = genero;
            NumeroPaginas = numeroPaginas;
        }
    }
}
