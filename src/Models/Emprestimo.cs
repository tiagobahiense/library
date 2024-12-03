public class Emprestimo {
    private Guid _IdInventario;
    private Guid _IdCliente;
    private DateTime _DataEmprestimo;
    private DateTime _DataDevolucao;

    public Emprestimo (int idInventario, int idCliente, DateTime dataEmprestimo, DateTime dataDevolucao){
        IdInventario = idInventario;
        IdCliente = idCliente;
        DataEmprestimo = dataEmprestimo;
        DataDevolucao = dataDevolucao;
    }

    public Guid IdInventario{
        get {return _IdInventario;}
        private set {_IdInventario = value;}
    }

    public Guid IdCliente{
        get {return _IdCliente;}
        private set {_IdCliente = value;}
    }

    public DateTime DataEmprestimo{
        get {return _DataEmprestimo;}
        set{
            DateTime dataAtual = DateTime.Now;
            if( value < dataAtual){
                throw new ArgumentException("A data não pode ser anterior a data atual.")
            }
            _DataEmprestimo = value;
        }
    }

    public DateTime DataDevolucao{
        get {return _DataDevolucao;}
        set {
            DateTime dataAtual = DateTime.Now;
            if(value <= dataAtual){
                throw new ArgumentException("A data de devolução não pode ser menor ou igual a data atual.")
            }
            _DataDevolucao = value;
        }
    }
}