using System;

namespace GS_EAP.Repository.Interfaces.Usuarios
{
    public interface ILoginRepository : IDisposable
    {
        bool ValidarUsuario(Models.Usuarios.Usuarios usuario);
        bool VerificarExistenciaUsuario(Models.Usuarios.Usuarios usuario);
    }
}
