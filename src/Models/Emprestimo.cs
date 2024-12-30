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
        private int _idInventario;
        private DateTime _dataEmprestimo;
        private DateTime _dataDevolucao;

        public Emprestimo(int idCatalogo, int idCliente, int idInventario, DateTime dataEmprestimo, DateTime dataDevolucao)
        {
            _idCatalogo = idCatalogo;
            _idCliente = idCliente;
            _idInventario = idInventario; 
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
            Catalogo = new Catalogo(); 
            Cliente = new Cliente(); 
            Inventario = new Inventario();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        [Column("IdCatalogo")]
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

        [Column("IdInventario")]
        public int IdInventario
        {
            get { return _idInventario; }
            private set { _idInventario = value; }
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

        
        [ForeignKey("IdCatalogo")]
        public virtual Catalogo Catalogo { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("IdInventario")]
        public virtual Inventario Inventario { get; set; }
    }
}
