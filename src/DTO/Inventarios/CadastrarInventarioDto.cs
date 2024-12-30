using System.Collections.Generic;
using Library.src.Models;

namespace Library.src.DTO.Inventarios
{
    public class CadastrarInventarioDto
    {
        public Dictionary<int, int> Itens { get; set; } = new Dictionary<int, int>();

        public Inventario ToInventario()
        {
            var inventario = new Inventario();

            foreach (var item in Itens)
            {
                inventario.ItensInventario.Add(new CatalogoInventario
                {
                    IdCatalogo = item.Key,
                    Quantidade = item.Value,
                    InventarioId = inventario.Id
                });
            }

            return inventario;
        }
    }
}
