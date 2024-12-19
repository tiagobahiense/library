using Library.src.Models;

namespace Library.src.DTO.Catalogo
{
    public class DetalhesCatalogoDto
    {
        public int CatalogoId{get;}
        public string Titulo{get;}
        public string Autor{get;}
        public int AnoLancamento{get;}
        public string Genero{get;}
        public int NumeroPaginas{get;}

        public DetalhesCatalogoDto(Catalogo catalogo)
        {
            CatalogoId = catalogo.IdCatalogo;
            Titulo = catalogo.Titulo;
            Autor = catalogo.Autor;
            AnoLancamento = catalogo.AnoLancamento;
            Genero = catalogo.Genero;
            NumeroPaginas = catalogo.NumeroPaginas;
        }
    }
}
