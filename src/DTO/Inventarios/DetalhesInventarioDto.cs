using System.Collections.Generic;
using Library.src.Models;

namespace Library.src.DTO.Inventarios
{
    public class DetalhesInventarioDto
    {
        public int Id { get; set; }
        public Dictionary<int, int> Itens { get; set; }

        public DetalhesInventarioDto()
        {
            Itens = new Dictionary<int, int>();
        }

        public static DetalhesInventarioDto FromInventario(Inventario inventario)
        {
            return new DetalhesInventarioDto
            {
                Id = inventario.Id,
                Itens = inventario.Itens
            };
        }
    }
}
