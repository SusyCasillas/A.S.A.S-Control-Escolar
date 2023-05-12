using A.S.A.S_Control_Escolar.ExternalTools;
using A.S.A.S_Control_Escolar.Model;
using A.S.A.S_Control_Escolar.Model.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace A.S.A.S_Control_Escolar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConsultarClasesAulaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery] RequestConsultarAulasClases prms)
        {
            List<VwClasesDiaVistum> clases;
            clases = new List<VwClasesDiaVistum>();
            using (PaseListaDbContext db = new PaseListaDbContext())
            {
                clases = db.VwClasesDiaVista.Where(x=>x.Aula.Equals(prms.Aula)).ToList();
            }
            ExternalRequest.PostRequest(clases, prms.Aula).Wait();
            return Ok(clases);
        }
    }
}
