using Library.src.Models;
using System.Collections.Generic;

namespace Library.src.DTO.Inventarios
{
    public class AtualizarInventarioDto
    {
        public Dictionary<int, int> Itens { get; set; } = new Dictionary<int, int>();

        public AtualizarInventarioDto(Dictionary<int, int> itens)
        {
            Itens = itens;
        }

        public Inventario ToInventario(int id)
        {
            return new Inventario(id, Itens);
        }
    }
}