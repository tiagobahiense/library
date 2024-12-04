public class Catalogo {
    private int _idCatalogo;
    private string _titulo;
    private string _autor;
    private int _anoLancamento;
    private string _genero;
    private int _numeroPaginas;

    public Catalogo (int idCatalogo, string titulo, string autor, int anoLancamento, string genero, int numeroPaginas){
        IdCatalogo = idCatalogo;
        Titulo = titulo;
        Autor = autor;
        AnoLancamento = anoLancamento;
        Genero = genero;
        NumeroPaginas = numeroPaginas;
    }

    public int IdCatalogo{
        get {return _idCatalogo;}
        private set {_idCatalogo = value;}
    }

    public string Titulo{
        get {return _titulo;}
        set {_titulo = value;}
    }

    public string Autor{
        get {return _autor;}
        set {_autor = value;}
    }

    public int AnoLancamento{
        get {return _anoLancamento;}
        set {
            int anoAtual = DateTime.Now.Year;
            if (value > anoAtual){
                throw new ArgumentException("O ano de lançamento não pode ser um ano futuro.");
            }
            if (value < 1){
                throw new ArgumentException("O ano de lançamento deve ser um número positivo.");
            }
        _anoLancamento = value;
        }
    }

    public string Genero{
        get {return _genero;}
        set {_genero = value;}
    }

    public int NumeroPaginas{
        get {return _numeroPaginas;}
        set {_numeroPaginas = value;}
    }

}