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
    public class UsuariosRepository : IUsuariosRepository, IDisposable
    {
        protected Context _context;
        Resultado resultado = new Resultado();

        public UsuariosRepository(Context db)
        {
            _context = db;
        }

        public List<Models.Usuarios.Usuarios> ListarUsuarios()
        {
            List<Models.Usuarios.Usuarios> usuarios = _context.Usuarios.OrderBy(x => x.NomUsuario).ToList();
            return usuarios;
        }

        public Resultado CriarUsuario(Models.Usuarios.Usuarios usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                resultado.IndResultado = true;
                resultado.NomMensagem = "Sucesso ao incluir um usuário";
            }
            catch (System.Exception ex)
            {
                resultado.IndResultado = false;
                resultado.NomException = ex;
                resultado.NomMensagem = "Erro ao incluir um usuário";
            }

            return resultado;
        }

        public Resultado EditarUsuario(Models.Usuarios.Usuarios usuario)
        {
            try
            {
                _context.Entry(usuario).State = EntityState.Modified;
                _context.SaveChanges();
                resultado.IndResultado = true;
                resultado.NomMensagem = "Sucesso ao editar o usuário";

            }
            catch (System.Exception ex)
            {
                resultado.IndResultado = false;
                resultado.NomException = ex;
                resultado.NomMensagem = "Erro ao editar o usuário";
            }
            return resultado;
        }

        public Resultado DeletarUsuario(Models.Usuarios.Usuarios usuario)
        {
            try
            {
                _context.Entry(usuario).State = EntityState.Deleted;
                _context.SaveChanges();
                resultado.IndResultado = true;
                resultado.NomMensagem = "Sucesso ao deletar o usuário";

            }
            catch (System.Exception ex)
            {
                resultado.IndResultado = false;
                resultado.NomException = ex;
                resultado.NomMensagem = "Erro ao deletar o usuário";
            }
            return resultado;
        }

        public Models.Usuarios.Usuarios BuscarUsuario(int IdUsuario)
        {
            Models.Usuarios.Usuarios usuario = _context.Usuarios.Where(x => x.IdUsuario == IdUsuario).FirstOrDefault();
            return usuario;
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
