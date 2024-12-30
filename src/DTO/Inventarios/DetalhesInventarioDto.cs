using System.Collections.Generic;
using Library.src.Models;

namespace Library.src.DTO.Inventarios
{
    public class DetalhesInventarioDto
    {
        public int Id { get; set; }
        public ICollection<CatalogoInventarioDto> ItensInventario { get; set; }

        public DetalhesInventarioDto()
        {
            ItensInventario = new List<CatalogoInventarioDto>();
        }

        public static DetalhesInventarioDto FromInventario(Inventario inventario)
        {
            var detalhesInventarioDto = new DetalhesInventarioDto
            {
                Id = inventario.Id
            };

            foreach (var item in inventario.ItensInventario)
            {
                detalhesInventarioDto.ItensInventario.Add(new CatalogoInventarioDto
                {
                    IdCatalogo = item.IdCatalogo,
                    Quantidade = item.Quantidade
                });
            }

            return detalhesInventarioDto;
        }
    }

    public class CatalogoInventarioDto
    {
        public int IdCatalogo { get; set; }
        public int Quantidade { get; set; }
    }
}
