using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using GS_EAP.Data;
using GS_EAP.Models.Base;
using GS_EAP.Models.Parceiros;
using GS_EAP.Repository.Interfaces.Parceiros;

namespace GS_EAP.Repository.Parceiros
{
    public class ParceirosRepository : IParceirosRepository, IDisposable
    {
        protected Context _context;
        Resultado resultado = new Resultado();

        public ParceirosRepository(Context db)
        {
            _context = db;
        }

        public List<Models.Parceiros.Parceiros> ListarParceiros()
        {
            List<Models.Parceiros.Parceiros> parceiros = _context.Parceiros.OrderBy(x => x.NomParceiro).ToList();
            return parceiros;
        }

        public Resultado CriarParceiro(Models.Parceiros.Parceiros parceiro)
        {
            try
            {
                _context.Parceiros.Add(parceiro);
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

        public Resultado EditarParceiro(Models.Parceiros.Parceiros parceiro)
        {
            try
            {
                _context.Entry(parceiro).State = EntityState.Modified;
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

        public Resultado DeletarParceiro(Models.Parceiros.Parceiros parceiro)
        {
            try
            {
                _context.Entry(parceiro).State = EntityState.Deleted;
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

        public Models.Parceiros.Parceiros BuscarParceiro(int IdParceiro)
        {
            Models.Parceiros.Parceiros parceiro = _context.Parceiros.Where(x => x.IdParceiro == IdParceiro).FirstOrDefault();
            return parceiro;
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
