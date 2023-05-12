using A.S.A.S_Control_Escolar.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace A.S.A.S_Control_Escolar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VisorAulasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Aula> list = new List<Aula>();
            using (PaseListaDbContext db = new PaseListaDbContext())
            {
                list = db.Aulas.ToList();
            }
            return Ok(list);
        }
    }
}
