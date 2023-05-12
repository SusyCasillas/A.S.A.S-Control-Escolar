using A.S.A.S_Control_Escolar.ExternalTools;
using A.S.A.S_Control_Escolar.Model;
using A.S.A.S_Control_Escolar.Model.Request;
using A.S.A.S_Control_Escolar.Model.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace A.S.A.S_Control_Escolar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GetPhotoUserController : ControllerBase
    {
        [HttpPost]
        public IActionResult Get([FromForm] RequestPhotoUser prms)
        {
            string imagePath = string.Empty;
            ResponseGetImageUsuer response = new ResponseGetImageUsuer();
            using (PaseListaDbContext db = new PaseListaDbContext())
            {
                var lst = db.Usuarios.Where(x => (x.Nombres + " " + x.Apellidos).Equals(prms.Nombre+ " "+prms.Apellido)).ToList();
                if(lst.Count > 0)
                {
                    if (lst[0].Foto != null)
                    {
                        response.Nombres = prms.Nombre;
                        response.Apellidos = prms.Apellido;
                        response.Image = FileControl.ConvertImage(lst[0].Foto);
                    }
                    
                }
            }
            //return PhysicalFile(imagePath, "image/png");
            return Ok(response);
        }
    }
}
