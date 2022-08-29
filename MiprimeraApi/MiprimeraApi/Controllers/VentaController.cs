using Microsoft.AspNetCore.Mvc;
using MiprimeraApi.Controllers.DTOS;
using MiprimeraApi.Model;
using MiprimeraApi.Repository;

namespace MiprimeraApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {
        [HttpPost]
        public bool AgregarVenta([FromBody] List<PostProducto> postProducto)
        {
            
            return VentaHandler.CargarVenta(postProducto);

        }

        [HttpPost]
        public bool CrearVenta([FromBody] PostVenta venta)
        {
            return VentaHandler.CrearVenta(new Venta
            {
                Comentarios = venta.Comentarios
            });

        }

        [HttpPut]
        public bool ModificarVenta([FromBody] PutVenta venta)
        {
            return VentaHandler.ModificarVenta(new Venta
            {
                Comentarios = venta.Comentarios
            });
        }

        [HttpDelete]
        public bool EliminarVenta([FromBody] int id)
        {
            return VentaHandler.EliminarVenta(id);
        }



    }
}
