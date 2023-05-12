using A.S.A.S_Control_Escolar.ExternalTools;
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
    public class InsertarAsistenciaController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromForm] RequestInsertarAsistencia data)
        {
            ResponseInsertarAsistencia response;
            List<ResponseVistaAlumnosAsistenciaCodigoClase> responseVistaAlumnos;
            using (var db = new PaseListaDbContext())
            {
                response = db.SpInsertarAsistencia.FromSqlRaw("EXEC [dbo].[Sp_Insertar_Asistencia] @CodigoClase, @NombreAlumno",
                        new SqlParameter[] {
                            new SqlParameter("@CodigoClase", data.CodigoClase),
                            new SqlParameter("@NombreAlumno", data.NombreAlumno)
                        }
                    ).ToList()[0];
                responseVistaAlumnos = db.SpVistaAlumnosCodigoClase.FromSqlRaw("EXEC [dbo].[Sp_Vista_Alumnos_Asistencia_Codigo_Clase] @CodigoClase", new SqlParameter[] {
                            new SqlParameter("@CodigoClase", data.CodigoClase)
                        }).ToList();
                
            }
            ExternalRequest.PostRequest(responseVistaAlumnos).Wait();
            return Ok(response);
        }
    }
}
