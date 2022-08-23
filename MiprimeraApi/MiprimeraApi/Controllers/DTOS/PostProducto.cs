using System.ComponentModel.DataAnnotations;

namespace MiprimeraApi.Controllers.DTOS
{
    public class PostProducto
    {
        [Required]
        public string Descripciones { get; set; }
        [Range(0,999)]
        public double Costo { get; set; }
        [Range(0, 999)]
        public double PrecioVenta { get; set; }
        [Range(0, 999)]
        public int Stock { get; set; }
        [Range(0, 999)]
        public int IdUsuario { get; set; }
    }
}
