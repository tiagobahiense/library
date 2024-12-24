using Library.src.Models;

namespace Library.src.DTO.Catalogos
{
    public class DetalhesCatalogoDto
    {
        public int IdCatalogo { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int AnoLancamento { get; set; }
        public string Genero { get; set; } = string.Empty;
        public int NumeroPaginas { get; set; }

        public static DetalhesCatalogoDto FromCatalogo(Catalogo catalogo)
        {
            return new DetalhesCatalogoDto
            {
                IdCatalogo = catalogo.IdCatalogo,
                Titulo = catalogo.Titulo,
                Autor = catalogo.Autor,
                AnoLancamento = catalogo.AnoLancamento,
                Genero = catalogo.Genero,
                NumeroPaginas = catalogo.NumeroPaginas
            };
        }
    }
}
