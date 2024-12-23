using Library.src.Models;

namespace Library.src.DTO.Catalogos
{
    public class CadastrarCatalogoDto
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoLancamento { get; set; }
        public string Genero { get; set; }
        public int NumeroPaginas { get; set; }

        public CadastrarCatalogoDto(string titulo, string autor, int anoLancamento, string genero, int numeroPaginas)
        {
            Titulo = titulo;
            Autor = autor;
            AnoLancamento = anoLancamento;
            Genero = genero;
            NumeroPaginas = numeroPaginas;
        }

        public Catalogo ToCatalogo()
        {
            return new Catalogo(Titulo, Autor, AnoLancamento, Genero, NumeroPaginas);
        }
    }
}
