using A.S.A.S_Control_Escolar.Model;
using A.S.A.S_Control_Escolar.Model.Request;
using A.S.A.S_Control_Escolar.Model.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace A.S.A.S_Control_Escolar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsertarAsistenciaProfesorController : Controller
    {
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromForm] RequestInsertarAsistenciaProfesor prms)
        {
            ResponseProcedureUniversal response;
            using (PaseListaDbContext db = new PaseListaDbContext())
            {
                response = db.SpInsertarAsistencioaProfesor.FromSqlRaw("EXEC [dbo].[Sp_Insertar_Asistencia_Profesor] @CodigoClase, @NombreProfesor", new SqlParameter[]
                {
                    new SqlParameter("@CodigoClase", prms.CodigoClase),
                    new SqlParameter("@NombreProfesor", prms.NombreProfesor),
                }).ToList()[0];
            }
            return Ok(response);
        }
    }
}
