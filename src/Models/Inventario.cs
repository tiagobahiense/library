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
            _id = id;
            _itens = itens;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        [NotMapped]
        public Dictionary<int, int> Itens
        {
            get { return _itens; }
            set { _itens = value; }
        }
    }
}
