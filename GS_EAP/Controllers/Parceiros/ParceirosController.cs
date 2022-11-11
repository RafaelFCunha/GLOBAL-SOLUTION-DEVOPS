using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GS_EAP.Data;
using GS_EAP.Models.Base;
using GS_EAP.Repository.Interfaces.Parceiros;
using GS_EAP.Repository.Parceiros;

namespace GS_EAP.Controllers.Parceiros
{
    public class ParceirosController : Controller
    {
        private IParceirosRepository _parceirosRepository;

        public ParceirosController()
        {
            this._parceirosRepository = new ParceirosRepository(new Context());
        }

        public IActionResult Index()
        {
            List<Models.Parceiros.Parceiros> parceiros = _parceirosRepository.ListarParceiros();
            return View("~/Views/Parceiros/ListaParceiros.cshtml", parceiros);
        }

        public IActionResult CriarParceiro()
        {
            Models.Parceiros.Parceiros parceiro = new Models.Parceiros.Parceiros();
            return View("~/Views/Parceiros/CriarParceiro.cshtml", parceiro);
        }

        [HttpPost]
        public IActionResult CriarParceiro(Models.Parceiros.Parceiros parceiro)
        {
            //VERIFICAR SE É EDIÇÃO
            if (parceiro.IdParceiro != 0)
            {
                return RedirectToAction("EditarParceiroPost", new { parceiro = parceiro });
            }


            Resultado resultado = _parceirosRepository.CriarParceiro(parceiro);
            if (resultado.IndResultado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("~/Views/Parceiros/CriarParceiro.cshtml", parceiro);
            }
        }

        public IActionResult EditarParceiro(int IdParceiro)
        {
            Models.Parceiros.Parceiros parceiro = _parceirosRepository.BuscarParceiro(IdParceiro);
            return View("~/Views/Parceiros/CriarParceiro.cshtml", parceiro);
        }

        [HttpPost]
        public IActionResult EditarParceiroPost(Models.Parceiros.Parceiros parceiro)
        {
            Resultado resultadoEdicao = _parceirosRepository.EditarParceiro(parceiro);
            if (resultadoEdicao.IndResultado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("~/Views/Parceiros/CriarParceiro.cshtml", parceiro);
            }
        }
        public IActionResult ExcluirParceiro(int IdParceiro)
        {
            Models.Parceiros.Parceiros parceiro = _parceirosRepository.BuscarParceiro(IdParceiro);
            Resultado resultadoExclusao = _parceirosRepository.DeletarParceiro(parceiro);
            if (resultadoExclusao.IndResultado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("~/Views/Parceiros/CriarParceiro.cshtml", parceiro);
            }
        }
    }
}
