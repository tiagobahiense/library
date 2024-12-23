using Library.src.Models;

namespace Library.src.DTO.Catalogos
{
    public class CadastrarCatalogoDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int AnoLancamento { get; set; }
        public string Genero { get; set; } = string.Empty;
        public int NumeroPaginas { get; set; }

        public Catalogo ToCatalogo(int idCatalogo)
        {
            return new Catalogo(idCatalogo, Titulo, Autor, AnoLancamento, Genero, NumeroPaginas);
        }
    }
}
