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
    public class VistaAlumnosAsistenciaCodigoClaseController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromForm] RequestAlumnosAsistenciaCodigoClase prms)
        {
            List<ResponseVistaAlumnosAsistenciaCodigoClase> dev;
            dev = new List<ResponseVistaAlumnosAsistenciaCodigoClase>();
            using (PaseListaDbContext db = new PaseListaDbContext())
            {
                dev = db.SpVistaAlumnosCodigoClase.FromSqlRaw("EXEC [dbo].[Sp_Vista_Alumnos_Asistencia_Codigo_Clase] @CodigoClase", new SqlParameter[] {
                    new SqlParameter("@CodigoClase", prms.CodigoClase)
                }).ToList();
            }
            for (int i = 0; i < dev.Count; i++)
            {
                dev[i].HoraLlegada = Convert.ToDateTime(Convert.ToDateTime(dev[i].HoraLlegada).ToString("hh:mm:ss tt"));
            }
            return Ok(dev);
        }
    }
}
