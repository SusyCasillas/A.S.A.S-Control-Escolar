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
    public class InsertarProfesorController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromForm] RequestInsertarProfesor prms)
        {
            ResponseInsertarProfesor response;
            using (PaseListaDbContext db = new PaseListaDbContext())
            {
                response = db.SpInsertarProfesor.FromSqlRaw("EXECUTE [dbo].[Sp_Insertar_Profesor] @Nombres,@Apellidos,@Edad,@Especialidad", new SqlParameter[] {
                    new SqlParameter("@Nombres", prms.Nombre)
                    ,new SqlParameter("@Apellidos", prms.Apellidos)
                    ,new SqlParameter("@Edad", prms.Edad)
                    ,new SqlParameter("@Especialidad", prms.Especialidad)
                }).ToList()[0];
            }
            return Ok(response);
        }
    }
}
