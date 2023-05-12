using A.S.A.S_Control_Escolar.ExternalTools;
using A.S.A.S_Control_Escolar.Model;
using A.S.A.S_Control_Escolar.Model.Common;
using A.S.A.S_Control_Escolar.Model.Request;
using A.S.A.S_Control_Escolar.Model.Response;
using Azure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace A.S.A.S_Control_Escolar.Services
{
    public class UsuarioService : IUsuarioService
    {
        private AppSettings _appSettings;

        public UsuarioService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public LoginResponse Autenticacion(RequestLogin l)
        {
            LoginResponse res = new LoginResponse();
            using (var dg = new PaseListaDbContext())
            {
                res = dg.SpLogin.FromSqlRaw("EXECUTE [dbo].[Login] @Username,@PasswordEncrypted",
                new SqlParameter[] {
                    new SqlParameter("@Username", l.Username),
                    new SqlParameter("@PasswordEncrypted", l.Password)
                }
                ).ToList()[0];
                if (res!=null)
                {
                    if (res.Rsp == 0)
                    {
                        res.Token = GetToken(res);
                        if(res.Imagen != null && res.Imagen.Length> 0)
                            res.Imagen = FileControl.ConvertImage(res.Imagen);
                        else
                            res.Imagen = FileControl.ConvertImage();
                    }
                        
                }
            }
            return res;
        }
        private string GetToken(LoginResponse model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Email, model.Username)
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
         
    }
}
