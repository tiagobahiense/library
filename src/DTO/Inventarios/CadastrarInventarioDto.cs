using System.Collections.Generic;
using Library.src.Models;

namespace Library.src.DTO.Inventarios
{
    public class CadastrarInventarioDto
    {
        public Dictionary<int, int> Itens { get; set; } = new Dictionary<int, int>();

        public Inventario ToInventario()
        {
            return new Inventario(0, Itens);
        }
    }
}
