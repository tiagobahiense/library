using Library.src.Models;
using System.Collections.Generic;

namespace Library.src.DTO.Inventarios
{
    public class DetalhesInventarioDto
    {
        public int Id { get; }
        public Dictionary<int, int> Itens { get; }

        public DetalhesInventarioDto(Inventario inventario)
        {
            Id = inventario.Id;
            Itens = inventario.Itens;
        }

        public Inventario ToInventario()
        {
            return new Inventario(Id, Itens);
        }
    }
}
