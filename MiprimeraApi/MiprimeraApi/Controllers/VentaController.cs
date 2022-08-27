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
        public bool CargarVenta([FromBody] List<ProductoVendido> productoVendidos , int id)
        {
            return VentaHandler.CargarVenta(productoVendidos, id);

        }




    }
}
