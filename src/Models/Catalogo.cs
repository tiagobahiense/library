namespace Library.Models
{
    public class Catalogo
    {
        private int _idCatalogo;
        private string _titulo;
        private string _autor;
        private int _anoLancamento;
        private string _genero;
        private int _numeroPaginas;

        public Catalogo(int idCatalogo, string titulo, string autor, int anoLancamento, string genero, int numeroPaginas)
        {
            _idCatalogo = idCatalogo;
            _titulo = titulo;
            _autor = autor;
            _anoLancamento = anoLancamento;
            _genero = genero;
            _numeroPaginas = numeroPaginas;
        }

        public int IdCatalogo
        {
            get { return _idCatalogo; }
            private set { _idCatalogo = value; }
        }

        public string Titulo
        {
            get { return _titulo; }
            private set { _titulo = value; }  
        }

        public string Autor
        {
            get { return _autor; }
            private set { _autor = value; }  
        }

        public int AnoLancamento
        {
            get { return _anoLancamento; }
            private set
            {
                int anoAtual = DateTime.Now.Year;
                if (value > anoAtual)
                {
                    throw new ArgumentException("O ano de lançamento não pode ser um ano futuro.");
                }
                if (value < 1)
                {
                    throw new ArgumentException("O ano de lançamento deve ser um número positivo.");
                }
                _anoLancamento = value;
            }
        }

        public string Genero
        {
            get { return _genero; }
            private set { _genero = value; } 
        }

        public int NumeroPaginas
        {
            get { return _numeroPaginas; }
            private set { _numeroPaginas = value; } 
        }
    }
}