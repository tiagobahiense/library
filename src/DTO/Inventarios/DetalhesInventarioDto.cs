using Library.src.Models;

namespace Library.src.DTO.Inventarios
{
    public class DetalhesInventarioDto
    {
        public Dictionary<int, int> Itens { get; }

        public DetalhesInventarioDto(Inventario inventario)
        {
            Itens = inventario.Itens;
        }

        public Inventario ToInventario(int id)
        {
            return new Inventario(id, Itens);
        }
    }
}
