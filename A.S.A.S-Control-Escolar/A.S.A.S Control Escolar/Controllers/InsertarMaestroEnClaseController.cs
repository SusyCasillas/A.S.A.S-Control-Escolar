using A.S.A.S_Control_Escolar.Model;
using A.S.A.S_Control_Escolar.Model.Request;
using A.S.A.S_Control_Escolar.Model.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace A.S.A.S_Control_Escolar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InsertarMaestroEnClaseController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromForm] RequestAsignarMaestroClase prms)
        {
            ResponseInsertarMaestroClase response;
            response = new ResponseInsertarMaestroClase();
            using (PaseListaDbContext db = new PaseListaDbContext())
            {
                response = db.SpInsertarMaestroClase.FromSqlRaw("EXECUTE [dbo].[Sp_Insertar_Maestro_En_Clase] @CodigoClase,@NombreProfesor", new SqlParameter[] {
                    new SqlParameter("@CodigoClase", prms.CodigoClase)
                    ,new SqlParameter("@NombreProfesor", prms.NombreProfesor)
                }).ToList()[0];
            }
            return Ok(response);
        }
    }
}
