using A.S.A.S_Control_Escolar.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace A.S.A.S_Control_Escolar.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class VistasPrincipalClaseController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<VwVistasPrincipalClase> list;
            list = new List<VwVistasPrincipalClase>();
            using (var db = new PaseListaDbContext())
            {
                list = db.VwVistasPrincipalClases.ToList();
            }
            return Ok(list);
        }
    }
}
