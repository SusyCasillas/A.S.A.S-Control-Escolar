using A.S.A.S_Control_Escolar.ExternalTools;
using A.S.A.S_Control_Escolar.Model;
using A.S.A.S_Control_Escolar.Model.Request;
using A.S.A.S_Control_Escolar.Model.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace A.S.A.S_Control_Escolar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InsertarAlumnoController : ControllerBase
    {
        private  IWebHostEnvironment Environment { get; set; }

        public InsertarAlumnoController(IWebHostEnvironment environment)
        {
            Environment = environment;
        }

        [HttpPost]
        public IActionResult Post([FromForm] RequestForInsertarAlumno prms)
        {
            ResponseInsertarAlumno response;
            response= new ResponseInsertarAlumno();
            string fileName;
            if (prms.Foto != null)
                fileName = new FileControl().SaveFile(Environment, prms.Foto, prms.Nombres + "_" + prms.Apellidos);
            else
                fileName = prms.Nombres + "_" + prms.Apellidos;
            
            using (PaseListaDbContext db = new PaseListaDbContext())
            {
                response = db.SpInsertarAlumno.FromSqlRaw("EXECUTE [dbo].[Sp_Insertar_Alumno] @Nombres,@Apellidos,@Edad,@Foto", new SqlParameter[]
                {
                    new SqlParameter("@Nombres", prms.Nombres)
                    ,new SqlParameter("@Apellidos", prms.Apellidos)
                    ,new SqlParameter("@Edad", prms.Edad)
                    ,new SqlParameter("@Foto", fileName)
                }).ToList()[0];
            }
            return Ok(response);
        }
    }
}
