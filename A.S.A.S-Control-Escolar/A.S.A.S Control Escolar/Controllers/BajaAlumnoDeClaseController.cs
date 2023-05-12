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
    public class BajaAlumnoDeClaseController : ControllerBase
    {
        [HttpPost]
        public IActionResult Get([FromForm] RequestBajaAlumnoClase prms)
        {
            ResponseProcedureUniversal dev;
            using (PaseListaDbContext db = new PaseListaDbContext())
            {
                dev= db.SpBajaClaseAlumno.FromSqlRaw("exec [dbo].[Sp_Baja_Alumno_De_Clase] @NombreAlumno, @CodigoClase, @RazonBaja", new SqlParameter[] {
                    new SqlParameter("@NombreAlumno", prms.NombreAlumno),
                    new SqlParameter("@CodigoClase", prms.CodigoAlumno),
                    new SqlParameter("@RazonBaja", prms.RazonBaja)
                }).ToList()[0];
            }
            return Ok(dev);
        }
    }
}
