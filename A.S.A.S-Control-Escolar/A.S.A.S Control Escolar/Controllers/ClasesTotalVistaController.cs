using A.S.A.S_Control_Escolar.Model;
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
    public class ClasesTotalVistaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List< ResponserClasesTotalVista> response;
            using (PaseListaDbContext db = new PaseListaDbContext())
            {
                response = db.SpVistaClaseTotal.FromSqlRaw("EXEC [dbo].[Sp_Clases_Total_Vista]", new SqlParameter[]{}).ToList();
            }
            return Ok(response);
        }
    }
}
