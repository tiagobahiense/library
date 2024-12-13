namespace Livraria.Models.Emprestimo;
public class Emprestimo {
    private int _idInventario;
    private int _idCliente;
    private DateTime _dataEmprestimo;
    private DateTime _dataDevolucao;

    public Emprestimo (int idInventario, int idCliente, DateTime dataEmprestimo, DateTime dataDevolucao){
        IdInventario = idInventario;
        IdCliente = idCliente;
        DataEmprestimo = dataEmprestimo;
        DataDevolucao = dataDevolucao;
    }

    public int IdInventario{
        get {return _idInventario;}
        private set {_idInventario = value;}
    }

    public int IdCliente{
        get {return _idCliente;}
        private set {_idCliente = value;}
    }

    public DateTime DataEmprestimo{
        get {return _dataEmprestimo;}
        set{
            DateTime dataAtual = DateTime.Now;
            if( value < dataAtual){
                throw new ArgumentException("A data não pode ser anterior a data atual.");
            }
            _dataEmprestimo = value;
        }
    }

    public DateTime DataDevolucao{
        get {return _dataDevolucao;}
        set {
            DateTime dataAtual = DateTime.Now;
            if(value <= dataAtual){
                throw new ArgumentException("A data de devolução não pode ser menor ou igual a data atual.");
                }
            _dataDevolucao = value;
        }
    }
}