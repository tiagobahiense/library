public class Catalogo {
    private int _Id;
    private string _Titulo;
    private string _Autor;
    private int _AnoLancamento;
    private string _Genero;
    private int _NumeroPaginas;

    public Catalogo (int id, string titulo, string autor, int anoLancamento, string genero, int numeroPaginas){
        Id = id;
        Titulo = titulo;
        Autor = autor;
        AnoLancamento = anoLancamento;
        Genero = genero;
        NumeroPaginas = numeroPaginas;
    }

    public int Id{
        get {return _Id;}
        private set {_Id = value;}
    }

    public string Titulo{
        get {return _Titulo;}
        set {_Titulo = value;}
    }

    public string Autor{
        get {return _Autor;}
        set {_Autor = value;}
    }

    public int AnoLancamento{
        get {return _AnoLancamento;}
        set {
            int anoAtual = Datetime.Now.Year;
            if (value > anoAtual){
                throw new ArgumentException("O ano de lançamento não pode ser um ano futuro.")
            }
            if (value < 1){
                throw new ArgumentException("O ano de lançamento deve ser um número positivo.")
            }
            _AnoLancamento = value;
        }
    }

    public string Genero{
        get {return _Genero;}
        set {_Genero = value;}
    }

    public int NumeroPaginas{
        get {return _NumeroPaginas;}
        set {_NumeroPaginas = value;}
    }

}