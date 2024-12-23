using Library.src.Models;

namespace Library.src.DTO.Catalogos
{
    public class DetalhesCatalogoDto
    {
        public int Id { get; }
        public string Titulo { get; }
        public string Autor { get; }
        public int AnoLancamento { get; }
        public string Genero { get; }
        public int NumeroPaginas { get; }

        public DetalhesCatalogoDto(Catalogo catalogo)
        {
            Id = catalogo.Id;
            Titulo = catalogo.Titulo;
            Autor = catalogo.Autor;
            AnoLancamento = catalogo.AnoLancamento;
            Genero = catalogo.Genero;
            NumeroPaginas = catalogo.NumeroPaginas;
        }
    }
}
