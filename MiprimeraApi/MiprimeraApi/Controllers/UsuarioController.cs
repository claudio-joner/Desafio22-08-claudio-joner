using Microsoft.AspNetCore.Mvc;
using MiprimeraApi.Controllers.DTOS;
using MiprimeraApi.Model;
using MiprimeraApi.Repository;

namespace MiprimeraApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuarios")]
        public List<Usuario> GetUsuarios()
        {
            return  UsuarioHandler.GetUsuarios();
        }

        [HttpPost]
        public bool CrearUsuarios([FromBody] PostUsuario usuario)
        {
            return UsuarioHandler.CrearUsuario(new Usuario
            {
                Apellido = usuario.Apellido,
                Contraseña = usuario.Contraseña,
                Mail = usuario.Mail,
                Nombre = usuario.Nombre,
                NombreUsuario = usuario.NombreUsuario

            });

        }

        [HttpPut]
        public bool ModificarNombreUsuario([FromBody] PutUsuario usuario)
        {
            return UsuarioHandler.ModificarUsuario(new Usuario
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                NombreUsuario = usuario.NombreUsuario,
                Contraseña = usuario.Contraseña,
                Mail = usuario.Mail
            });
        }

        [HttpDelete]
        public bool EliminarUsuario([FromBody] int id)
        {
            return UsuarioHandler.EliminarUsuario(id);
        }

        


    }
}
