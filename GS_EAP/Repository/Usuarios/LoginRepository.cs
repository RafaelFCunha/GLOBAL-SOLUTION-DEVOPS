using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using GS_EAP.Data;
using GS_EAP.Models.Base;
using GS_EAP.Models.Usuarios;
using GS_EAP.Repository.Interfaces.Usuarios;

namespace GS_EAP.Repository.Usuarios
{
    public class LoginRepository : ILoginRepository, IDisposable
    {
        protected Context _context;
        Resultado resultado = new Resultado();

        public LoginRepository(Context db)
        {
            _context = db;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool ValidarUsuario(Models.Usuarios.Usuarios usuario)
        {
            throw new NotImplementedException();
        }

        public bool VerificarExistenciaUsuario(Models.Usuarios.Usuarios usuario)
        {
            throw new NotImplementedException();
        }
    }
}
