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
    public class RegistrarHorarioEnMateriaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromForm] RequestRegistrarHorarioEnMateria prms)
        {
            ResponseRegistrarHorarioEnMateria response;
            using (PaseListaDbContext db = new PaseListaDbContext())
            {
                response = db.SpRegistrarHorarioEnMateria.FromSqlRaw("EXECUTE [dbo].[Sp_Registrar_Horario_Materia] @NombreMateria,@NombreHorario,@NombreAula,@NombreDia,@LimiteCupo", new SqlParameter[]
                {
                    new SqlParameter("@NombreMateria", prms.NombreMateria)
                    ,new SqlParameter("@NombreHorario", prms.NombreHorario)
                    ,new SqlParameter("@NombreAula", prms.NombreAula)
                    ,new SqlParameter("@NombreDia", prms.NombreDia)
                    ,new SqlParameter("@LimiteCupo", prms.LimiteCupo)
                }).ToList()[0];
            }
            return Ok(response);
        }
    }
}
