using A.S.A.S_Control_Escolar.Model.Request;
using A.S.A.S_Control_Escolar.Model.Response;

namespace A.S.A.S_Control_Escolar.Services
{
    public interface IUsuarioService
    {
        LoginResponse Autenticacion(RequestLogin l);
    }
}
