using A.S.A.S_Control_Escolar.Model;
using A.S.A.S_Control_Escolar.Model.Request;
using A.S.A.S_Control_Escolar.Model.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace A.S.A.S_Control_Escolar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ActivarAulaController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromForm] RequestDesactivarClase prms)
        {
            ResponseProcedureUniversal response;
            response = new ResponseProcedureUniversal();
            using (PaseListaDbContext db = new PaseListaDbContext())
            {
                var listAula = db.Aulas.Where(x => x.Nombre.Equals(prms.NombreAula) && x.Active == false).ToList();
                if (listAula.Count > 0)
                {
                    var aula = listAula[0];
                    aula.Active = true;
                    db.Aulas.Update(aula);
                    db.SaveChanges();
                    response = new ResponseProcedureUniversal()
                    {
                        Rsp = 0,
                        Msg = "se activó correctamente la clase: \"" + prms.NombreAula + "\"."
                    };
                }
                else
                {
                    response = new ResponseProcedureUniversal()
                    {
                        Rsp = -1,
                        Msg = "No hay ninguna clase inactiva con el nombre: \"" + prms.NombreAula + "\""
                    };
                }
            }

            return Ok(response);
        }
    }
}
