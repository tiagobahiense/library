public class Cliente {
    private int _Id;
    private string _Nome;
    private string _Endereco;
    private string _Telefone;
    private string _Email;
    private DateTime _DataNascimento;

    public Cliente(int id, string nome, string endereco, string telefone, string email, DateTime dataNascimento) {
        Id = id;
        Nome = nome;
        Endereco = endereco;
        Telefone = telefone;
        Email = email;
        DataNascimento = dataNascimento;
    }

    public int Id{
        get => _Id;
        private set => _Id = value;
    }
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
                throw new ArgumentException("Data não pode ser Futura.");
            }
            _DataNascimento = value;
        }
    }
}

