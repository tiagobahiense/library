using Library.src.Models;

namespace Library.src.DTO.Catalogos
{
    public class DetalhesCatalogoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty; 
        public int AnoLancamento { get; set; }
        public string Genero { get; set; } = string.Empty; 
        public int NumeroPaginas { get; set; }

        public DetalhesCatalogoDto()
        {
        }

        public static DetalhesCatalogoDto FromCatalogo(Catalogo catalogo)
        {
            return new DetalhesCatalogoDto
            {
                Id = catalogo.Id,
                Titulo = catalogo.Titulo,
                Autor = catalogo.Autor,
                AnoLancamento = catalogo.AnoLancamento,
                Genero = catalogo.Genero,
                NumeroPaginas = catalogo.NumeroPaginas
            };
        }
    }
}

