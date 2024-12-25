using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.src.Models
{
    public class Inventario
    {
        private int _id;
        private Dictionary<int, int> _itens;

        public Inventario()
        {
            _itens = new Dictionary<int, int>();
        }

        public Inventario(int id, Dictionary<int, int> itens)
        {
            Id = id; // Use o setter público
            _itens = itens ?? new Dictionary<int, int>(); // Inicializa se for nulo
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return _id; }
            set { _id = value; } // Adicione o setter público
        }

        [NotMapped]
        public Dictionary<int, int> Itens
        {
            get { return _itens; }
            set { _itens = value ?? new Dictionary<int, int>(); } // Inicializa se for nulo
        }
    }
}
