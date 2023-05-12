using A.S.A.S_Control_Escolar.Model;
using A.S.A.S_Control_Escolar.Model.Request;
using A.S.A.S_Control_Escolar.Model.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace A.S.A.S_Control_Escolar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesactivarAulaController : ControllerBase
    {
        [HttpPost]
        public IActionResult post([FromForm] RequestDesactivarClase prms)
        {
            ResponseProcedureUniversal procedureUniversal;
            procedureUniversal = new ResponseProcedureUniversal();
            using (PaseListaDbContext db = new PaseListaDbContext())
            {
                var listAula = db.Aulas.Where(x=>x.Nombre.Equals(prms.NombreAula) && x.Active == true).ToList();
                if (listAula.Count > 0)
                {
                    var aula = listAula[0];
                    aula.Active = false;
                    db.Aulas.Update(aula);
                    db.SaveChanges();
                    procedureUniversal = new ResponseProcedureUniversal()
                    {
                        Rsp = 0,
                        Msg = "se desactivó correctamente la clase: \"" + prms.NombreAula + "\"."
                    };
                }
                else
                {
                    procedureUniversal = new ResponseProcedureUniversal()
                    {
                        Rsp = -1,
                        Msg = "No hay una clase activa con el nombre: \"" + prms.NombreAula+"\""
                    };
                }
            }

            return Ok(procedureUniversal);
        }
    }
}
