using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GS_EAP.Data;
using GS_EAP.Models.Base;
using GS_EAP.Repository.Interfaces.Usuarios;
using GS_EAP.Repository.Usuarios;

namespace GS_EAP.Controllers.Usuarios
{
    public class UsuariosController : Controller
    {
        private IUsuariosRepository _usuariosRepository;

        public UsuariosController()
        {
            this._usuariosRepository = new UsuariosRepository(new Context());
        }

        public IActionResult Index()
        {
            List<Models.Usuarios.Usuarios> usuarios = _usuariosRepository.ListarUsuarios();
            return View("~/Views/Usuarios/ListaUsuarios.cshtml", usuarios);
        }

        public IActionResult CriarUsuario()
        {
            Models.Usuarios.Usuarios usuario = new Models.Usuarios.Usuarios();
            return View("~/Views/Usuarios/CriarUsuario.cshtml",usuario);
        }

        [HttpPost]
        public IActionResult CriarUsuario(Models.Usuarios.Usuarios usuario)
        {
            //VERIFICAR SE É EDIÇÃO
            if (usuario.IdUsuario != 0)
            {
                return RedirectToAction("EditarUsuarioPost", new { usuario = usuario } );
            }
                

            Resultado resultado = _usuariosRepository.CriarUsuario(usuario);
            if (resultado.IndResultado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("~/Views/Usuarios/CriarUsuario.cshtml", usuario);
            }
        }

        public IActionResult EditarUsuario(int IdUsuario)
        {
            Models.Usuarios.Usuarios usuario = _usuariosRepository.BuscarUsuario(IdUsuario);
            return View("~/Views/Usuarios/CriarUsuario.cshtml", usuario);
        }

        [HttpPost]
        public IActionResult EditarUsuarioPost(Models.Usuarios.Usuarios usuario)
        {
            Resultado resultadoEdicao = _usuariosRepository.EditarUsuario(usuario);
            if (resultadoEdicao.IndResultado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("~/Views/Usuarios/CriarUsuario.cshtml", usuario);
            }
        }
        public IActionResult ExcluirUsuario(int IdUsuario)
        {
            Models.Usuarios.Usuarios usuario = _usuariosRepository.BuscarUsuario(IdUsuario);
            Resultado resultadoExclusao = _usuariosRepository.DeletarUsuario(usuario);
            if (resultadoExclusao.IndResultado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("~/Views/Usuarios/CriarUsuario.cshtml", usuario);
            }
        }
    }
}
