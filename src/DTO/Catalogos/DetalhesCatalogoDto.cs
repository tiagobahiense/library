using Library.src.Models;

namespace Library.src.DTO.Catalogos
{
    public class DetalhesCatalogoDto
    {
        public int IdCatalogo { get; }
        public string Titulo { get; }
        public string Autor { get; }
        public int AnoLancamento { get; }
        public string Genero { get; }
        public int NumeroPaginas { get; }

        public DetalhesCatalogoDto(Catalogo catalogo)
        {
            IdCatalogo = catalogo.IdCatalogo;
            Titulo = catalogo.Titulo;
            Autor = catalogo.Autor;
            AnoLancamento = catalogo.AnoLancamento;
            Genero = catalogo.Genero;
            NumeroPaginas = catalogo.NumeroPaginas;
        }

        public Catalogo ToCatalogo()
        {
            return new Catalogo(Titulo, Autor, AnoLancamento, Genero, NumeroPaginas)
            {
                IdCatalogo = IdCatalogo
            };
        }
    }
}