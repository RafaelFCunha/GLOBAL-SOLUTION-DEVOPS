//using GS_EAP.Data;
//using GS_EAP.Repository.Interfaces.Usuarios;
//using GS_EAP.Repository.Usuarios;
//using Microsoft.AspNetCore.Mvc;

//namespace GS_EAP.Controllers.Usuarios
//{
//    public class LoginController : Controller
//    {
//        private ILoginRepository _loginRepository;
//        private IUsuariosRepository _usuariosRepository;

//        public LoginController()
//        {
//            this._loginRepository = new LoginRepository(new Context());
//            this._usuariosRepository = new UsuariosRepository(new Context());
//        }
//        public IActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Login(Models.Usuarios.Usuarios usuario)
//        {
//            if (ModelState.IsValid)
//            {
//                bool usuarioExiste = _loginRepository.VerificarExistenciaUsuario(usuario);
//                if (usuarioExiste)
//                {
//                    bool usuarioValido = _loginRepository.ValidarUsuario(usuario);
//                    if (!usuarioValido)
//                    {

//                    }
//                    else
//                    {
//                        Models.Usuarios.Usuarios usuarioAutenticado = _usuariosRepository.BuscarUsuarioPorEmail(usuario.NomEmail);
//                        Session["IdUsuario"] = usuarioAutenticado.IdUsuario.ToString();
//                        Session["NomUsuario"] = usuarioAutenticado.NomUsuario.ToString();
//                    }
//                }
//                using (DB_Entities db = new DB_Entities())
//                {
//                    var obj = db.UserProfiles.Where(a => a.UserName.Equals(usuario.UserName) && a.Password.Equals(usuario.Password)).FirstOrDefault();
//                    if (obj != null)
//                    {
//                        Session["UserID"] = obj.UserId.ToString();
//                        Session["UserName"] = obj.UserName.ToString();
//                        return RedirectToAction("UserDashBoard");
//                    }
//                }
//            }
//            return View(objUser);
//        }
//    }
//}
