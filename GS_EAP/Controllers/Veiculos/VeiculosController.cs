using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GS_EAP.Data;
using GS_EAP.Models.Base;
using GS_EAP.Repository.Interfaces.Veiculos;
using GS_EAP.Repository.Veiculos;
using GS_EAP.Repository.Interfaces.Usuarios;
using GS_EAP.Repository.Usuarios;

namespace GS_EAP.Controllers.Veiculos
{
    public class VeiculosController : Controller
    {
        private IVeiculosRepository _veiculosRepository;
        private IUsuariosRepository _usuariosRepository;

        public VeiculosController()
        {
            this._usuariosRepository = new UsuariosRepository(new Context());
            this._veiculosRepository = new VeiculosRepository(new Context());
        }

        public IActionResult Index()
        {
            List<Models.Veiculos.Veiculos> veiculos = _veiculosRepository.ListarVeiculos();
            return View("~/Views/Veiculos/ListaVeiculos.cshtml", veiculos);
        }

        public IActionResult CriarVeiculo()
        {
            ViewBag.usuarios = _usuariosRepository.ListarUsuarios();
            Models.Veiculos.Veiculos veiculo = new Models.Veiculos.Veiculos();
            return View("~/Views/Veiculos/CriarVeiculo.cshtml", veiculo);
        }

        [HttpPost]
        public IActionResult CriarVeiculo(Models.Veiculos.Veiculos veiculo)
        {
            //VERIFICAR SE É EDIÇÃO
            if (veiculo.IdVeiculo != 0)
            {
                return RedirectToAction("EditarVeiculoPost", new { veiculo = veiculo });
            }


            Resultado resultado = _veiculosRepository.CriarVeiculo(veiculo);
            if (resultado.IndResultado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("~/Views/Veiculos/CriarVeiculo.cshtml", veiculo);
            }
        }

        public IActionResult EditarVeiculo(int IdVeiculo)
        {
            ViewBag.usuarios = _usuariosRepository.ListarUsuarios();
            Models.Veiculos.Veiculos veiculo = _veiculosRepository.BuscarVeiculo(IdVeiculo);
            return View("~/Views/Veiculos/CriarVeiculo.cshtml", veiculo);
        }

        [HttpPost]
        public IActionResult EditarVeiculoPost(Models.Veiculos.Veiculos veiculo)
        {
            Resultado resultadoEdicao = _veiculosRepository.EditarVeiculo(veiculo);
            if (resultadoEdicao.IndResultado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("~/Views/Veiculos/CriarVeiculo.cshtml", veiculo);
            }
        }
        public IActionResult ExcluirVeiculo(int IdVeiculo)
        {
            Models.Veiculos.Veiculos veiculo = _veiculosRepository.BuscarVeiculo(IdVeiculo);
            Resultado resultadoExclusao = _veiculosRepository.DeletarVeiculo(veiculo);
            if (resultadoExclusao.IndResultado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("~/Views/Veiculos/CriarVeiculo.cshtml", veiculo);
            }
        }
    }
}
