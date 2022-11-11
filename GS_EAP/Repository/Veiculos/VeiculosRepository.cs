using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using GS_EAP.Data;
using GS_EAP.Models.Base;
using GS_EAP.Models.Veiculos;
using GS_EAP.Repository.Interfaces.Veiculos;

namespace GS_EAP.Repository.Veiculos
{
    public class VeiculosRepository : IVeiculosRepository, IDisposable
    {
        protected Context _context;
        Resultado resultado = new Resultado();

        public VeiculosRepository(Context db)
        {
            _context = db;
        }

        public List<Models.Veiculos.Veiculos> ListarVeiculos()
        {
            List<Models.Veiculos.Veiculos> veiculos = _context.Veiculos.OrderBy(x => x.NomModelo).ToList();
            return veiculos;
        }

        public Resultado CriarVeiculo(Models.Veiculos.Veiculos veiculo)
        {
            try
            {
                _context.Veiculos.Add(veiculo);
                _context.SaveChanges();
                resultado.IndResultado = true;
                resultado.NomMensagem = "Sucesso ao incluir um veículo";
            }
            catch (System.Exception ex)
            {
                resultado.IndResultado = false;
                resultado.NomException = ex;
                resultado.NomMensagem = "Erro ao incluir um veículo";
            }

            return resultado;
        }

        public Resultado EditarVeiculo(Models.Veiculos.Veiculos veiculo)
        {
            try
            {
                _context.Entry(veiculo).State = EntityState.Modified;
                _context.SaveChanges();
                resultado.IndResultado = true;
                resultado.NomMensagem = "Sucesso ao editar o veículo";

            }
            catch (System.Exception ex)
            {
                resultado.IndResultado = false;
                resultado.NomException = ex;
                resultado.NomMensagem = "Erro ao editar o veículo";
            }
            return resultado;
        }

        public Resultado DeletarVeiculo(Models.Veiculos.Veiculos veiculo)
        {
            try
            {
                _context.Entry(veiculo).State = EntityState.Deleted;
                _context.SaveChanges();
                resultado.IndResultado = true;
                resultado.NomMensagem = "Sucesso ao deletar o veículo";

            }
            catch (System.Exception ex)
            {
                resultado.IndResultado = false;
                resultado.NomException = ex;
                resultado.NomMensagem = "Erro ao deletar o veículo";
            }
            return resultado;
        }

        public Models.Veiculos.Veiculos BuscarVeiculo(int IdVeiculo)
        {
            Models.Veiculos.Veiculos veiculo = _context.Veiculos.Where(x => x.IdVeiculo == IdVeiculo).FirstOrDefault();
            return veiculo;
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
