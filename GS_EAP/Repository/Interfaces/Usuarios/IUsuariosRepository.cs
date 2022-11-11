using System;
using System.Collections.Generic;
using GS_EAP.Models.Base;

namespace GS_EAP.Repository.Interfaces.Usuarios
{
    public interface IUsuariosRepository : IDisposable
    {
        List<Models.Usuarios.Usuarios> ListarUsuarios();
        Resultado CriarUsuario(Models.Usuarios.Usuarios usuario);
        Resultado EditarUsuario(Models.Usuarios.Usuarios usuario);
        Resultado DeletarUsuario(Models.Usuarios.Usuarios usuario);
        Models.Usuarios.Usuarios BuscarUsuario(int IdUsuario);

    }
}
