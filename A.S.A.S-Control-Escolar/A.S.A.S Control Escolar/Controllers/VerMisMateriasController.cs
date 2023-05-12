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
    public class VerMisMateriasController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromForm] RequestVerMisMaterias data)
        {
            List<ResponseVerMisMaterias> misMaterias;
            using (var db = new PaseListaDbContext())
            {
                misMaterias = db.SpVerMisMaterias.FromSqlRaw("EXEC [dbo].[Sp_View_Mis_Materias] @Nombre",
                        new SqlParameter[] { 
                            new SqlParameter("@Nombre", data.NombreAlumno)
                        }
                    ).ToList();
            }
            return Ok(misMaterias);
        }
    }
}
