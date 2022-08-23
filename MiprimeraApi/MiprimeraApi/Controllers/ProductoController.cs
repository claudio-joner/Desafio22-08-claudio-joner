using Microsoft.AspNetCore.Mvc;
using MiprimeraApi.Controllers.DTOS;
using MiprimeraApi.Model;
using MiprimeraApi.Repository;

namespace MiprimeraApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]
        public List<Producto> GetProductos()
        {
            return ProductoHandler.GetProductos();
        }

        [HttpPost]
        public bool CrearProductos([FromBody] PostProducto producto)
        {
            return ProductoHandler.CrearProducto(new Producto
            {
                Descripciones = producto.Descripciones,
                Costo = producto.Costo,
                PrecioVenta = producto.Stock,
                Stock = producto.Stock,
                IdUsuario = producto.IdUsuario

            });

        }


        [HttpPut]
        public bool ModificarProductos([FromBody] PutProducto producto)
        {
            return ProductoHandler.ModificarProducto(new Producto 
            {
                Id = producto.Id,
                Descripciones = producto.Descripciones,
                Costo = producto.Costo,
                PrecioVenta = producto.Stock,
                Stock = producto.Stock,
                IdUsuario = producto.IdUsuario

            });      
        }

        [HttpDelete]
        public bool EliminarProducto([FromBody] int id)
        {
            return ProductoHandler.EliminarProducto(id);
        }
    }
}
