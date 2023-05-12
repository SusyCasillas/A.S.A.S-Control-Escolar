using A.S.A.S_Control_Escolar.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace A.S.A.S_Control_Escolar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClasesSinProfesorAsignadoController : ControllerBase
    {
        // GET: api/<ClasesSinProfesorAsignadoController>
        [HttpGet]
        public IEnumerable<VwClasesSinProfesorAsginado> Get()
        {
            List<VwClasesSinProfesorAsginado> dev;
            dev = new List<VwClasesSinProfesorAsginado>();
            using (PaseListaDbContext db = new PaseListaDbContext())
            {
                dev = db.VwClasesSinProfesorAsginados.ToList();
            }
            return dev;
        }
    }
}
