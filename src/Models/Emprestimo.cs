using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.src.Models
{
    public class Emprestimo
    {
        private int _id;
        private int _idCatalogo;
        private int _idCliente;
        private DateTime _dataEmprestimo;
        private DateTime _dataDevolucao;

        public Emprestimo(int idCatalogo, int idCliente, DateTime dataEmprestimo, DateTime dataDevolucao)
        {
            _idCatalogo = idCatalogo;
            _idCliente = idCliente;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        public int IdCatalogo
        {
            get { return _idCatalogo; }
            private set { _idCatalogo = value; }
        }

        public int IdCliente
        {
            get { return _idCliente; }
            private set { _idCliente = value; }
        }

        public DateTime DataEmprestimo
        {
            get { return _dataEmprestimo; }
            set { _dataEmprestimo = value; }
        }

        public DateTime DataDevolucao
        {
            get { return _dataDevolucao; }
            set { _dataDevolucao = value; }
        }

        public virtual Catalogo? Catalogo { get; set; }
        public virtual Cliente? Cliente { get; set; }
    }
}
