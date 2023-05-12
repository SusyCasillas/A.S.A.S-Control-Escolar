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
    public class RegistrarAlumnoClaseController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public IActionResult PostAction([FromForm] RequestRegistrarAlumno registrar)
        {
            List<ResponseRegistrarAlumno> response;
            response = new List<ResponseRegistrarAlumno>();
            using (var db = new PaseListaDbContext())
            {
                response = db.SpRegistrarAlumnoClase.FromSqlRaw("EXECUTE [dbo].[Sp_Registrar_Alumno_en_Clase] @CodigoClase,@NombreAlumno",
                    new SqlParameter[] 
                    { 
                        new SqlParameter("@CodigoClase", registrar.CodigoClase),
                        new SqlParameter("@NombreAlumno", registrar.NombreAlumno)
                    }
                    ).ToList();
            }
            return Ok(response);
        }
    }
}
