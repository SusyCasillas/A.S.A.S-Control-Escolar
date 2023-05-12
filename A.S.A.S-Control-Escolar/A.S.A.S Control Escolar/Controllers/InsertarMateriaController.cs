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
    public class InsertarMateriaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromForm] RequestInsertarMateria prms)
        {
            ResponseInsertarMateria response;
            using (PaseListaDbContext db = new PaseListaDbContext())
            {
                response = db.SpInsertarMateria.FromSqlRaw("EXECUTE [dbo].[Sp_Insertar_Materia] @Nombre,@NombreGrado", new SqlParameter[] {
                    new SqlParameter("@Nombre", prms.Nombre)
                    ,new SqlParameter("@NombreGrado", prms.NombreGrado)

                }).ToList()[0];
            }
            return Ok(response);
        }
    }
}
