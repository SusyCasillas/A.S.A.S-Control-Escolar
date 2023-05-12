using A.S.A.S_Control_Escolar.Model;
using A.S.A.S_Control_Escolar.Model.Request;
using A.S.A.S_Control_Escolar.Model.Response;
using A.S.A.S_Control_Escolar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace A.S.A.S_Control_Escolar.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult Login([FromForm] RequestLogin credentials)
        {
            
            using (StreamWriter sw = new StreamWriter("log.txt", false))
            {
                try
                {
                    var respuestaLogin = _usuarioService.Autenticacion(credentials);
                    return Ok(respuestaLogin);
                }
                catch (Exception ex)
                {
                    sw.WriteLine(ex.ToString());
                    sw.Close();
                    return BadRequest();
                }
                
            }
        }
        
    }
}
