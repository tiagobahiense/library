using System.Collections.Generic;
using Library.src.Models;

namespace Library.src.DTO.Inventarios
{
    public class AtualizarInventarioDto
    {
        public Dictionary<int, int> Itens { get; set; } = new Dictionary<int, int>();

        public Inventario ToInventario(int id)
        {
            return new Inventario(id, Itens);
        }
    }
}
