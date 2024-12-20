namespace Library.src.Models
{
    public class Cliente
    {
        private int _id;
        private string _nome;
        private string _endereco;
        private string _telefone;
        private string _email;
        private DateTime _dataNascimento;

        public Cliente(int id, string nome, string endereco, string telefone, string email, DateTime dataNascimento)
        {
            _id = id;
            _nome = nome;
            _endereco = endereco;
            _telefone = telefone; 
            _email = email; 
            _dataNascimento = dataNascimento;
        }

        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }

        public string Telefone
        {
            get { return _telefone; }
            set
            {
                if (value.Length != 11 || !value.All(char.IsDigit))
                {
                    throw new ArgumentException("Número de telefone inválido.");
                }
                _telefone = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (!value.Contains("@"))
                {
                    throw new ArgumentException("Endereço de email inválido.");
                }
                _email = value;
            }
        }

        public DateTime DataNascimento
        {
            get { return _dataNascimento; }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Data não pode ser futura.");
                }
                _dataNascimento = value;
            }
        }
    }
}