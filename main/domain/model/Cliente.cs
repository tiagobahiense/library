public class Cliente {
    public int _Id;
    public string _Nome;
    public string _Endereco;
    public string _Telefone;
    public string _Email;
    public DateTime _DataNascimento;

    public Cliente(int Id, string Nome, string Endereco, string Telefone, string Email, DateTime DataNascimento) {
        _Id = Id;
        _Nome = Nome;
        _Endereco = Endereco;
        _Telefone = Telefone;
        _Email = Email;
        _DataNascimento = DataNascimento;
    }

    public int Id{get; set;}
    public string Nome {get; set;}
    public string Endereco {get; set;}

    public string Telefone{
        get{ return _Telefone;}
        set{
            if(value.Length != 11 || !value.All(char.IsDigit)){
                throw new ArgumentException("Número de telefone inválido.");
            }
            _Telefone = value;
        }
    }

    public string Email{
        get{ return _Email;}
        set{
            if(!value.Contains("@")) {
                throw new ArgumentException("Endereço de email inválido.");
            }
            _Email = value;
        }
    }

    public DateTime DataNascimento{
        get{ return _DataNascimento;}
        set{
            if(value > DateTime.Now){
                throw new ArgumentException("Data não pode ser Futura.")
            }
            _DataNascimento = value;
        }
    }
}

