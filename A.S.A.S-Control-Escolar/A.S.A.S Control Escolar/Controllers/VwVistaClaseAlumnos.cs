using A.S.A.S_Control_Escolar.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace A.S.A.S_Control_Escolar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VwVistaClaseAlumnos : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            List<VwVistaClaseParaAlumno> list;
            list = new List<VwVistaClaseParaAlumno>();
            using (var db = new PaseListaDbContext())
            {
                list = db.VwVistaClaseParaAlumnos.ToList();
            }
            return Ok(list);
        }
    }
}
