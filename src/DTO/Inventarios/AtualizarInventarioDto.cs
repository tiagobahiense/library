using System.Collections.Generic;
using Library.src.Models;

namespace Library.src.DTO.Inventarios
{
    public class AtualizarInventarioDto
    {
        public Dictionary<int, int> Itens { get; set; } = new Dictionary<int, int>();

        public Inventario ToInventario(int id)
        {
            var inventario = new Inventario { Id = id };

            foreach (var item in Itens)
            {
                var catalogoInventario = inventario.ItensInventario.FirstOrDefault(i => i.IdCatalogo == item.Key);
                if (catalogoInventario != null)
                {
                    catalogoInventario.Quantidade = item.Value;
                }
                else
                {
                    inventario.ItensInventario.Add(new CatalogoInventario
                    {
                        IdCatalogo = item.Key,
                        Quantidade = item.Value,
                        InventarioId = id
                    });
                }
            }

            return inventario;
        }
    }
}

