using A.S.A.S_Control_Escolar.Model;
using A.S.A.S_Control_Escolar.Model.Request;
using A.S.A.S_Control_Escolar.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace A.S.A.S_Control_Escolar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulaController : ControllerBase
    {
        [HttpPost]
        public IActionResult post([FromForm] RequestDesactivarClase prms)
        {
            ResponseProcedureUniversal response = new ResponseProcedureUniversal();

            using (PaseListaDbContext db = new PaseListaDbContext())
            {
                var existClass = db.Aulas.Where(x=>x.Nombre.ToLower().Equals(prms.NombreAula.ToLower())).ToList().Count > 0;
                if (!existClass)
                {
                    Aula newAula = new Aula()
                    {
                        Nombre = prms.NombreAula,
                        FechaInsercion = DateTime.Now,
                        Active = true
                    };
                    db.Aulas.Add(newAula);
                    db.SaveChanges();
                    response.Rsp = 0;
                    response.Msg = " La clase \"" + prms.NombreAula + "\" se registró correctamente.";
                }
                else
                {
                    response.Rsp = -1;
                    response.Msg = "No se puede insertar la clase. La clase \"" + prms.NombreAula + "\" ya está registrada.";
                }
            }

            return Ok(response);
        }
    }
}
