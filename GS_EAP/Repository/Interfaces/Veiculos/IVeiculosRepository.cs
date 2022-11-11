using System;
using System.Collections.Generic;
using GS_EAP.Models.Base;

namespace GS_EAP.Repository.Interfaces.Veiculos
{
    public interface IVeiculosRepository : IDisposable
    {
        List<Models.Veiculos.Veiculos> ListarVeiculos();
        Resultado CriarVeiculo(Models.Veiculos.Veiculos veiculo);
        Resultado EditarVeiculo(Models.Veiculos.Veiculos veiculo);
        Resultado DeletarVeiculo(Models.Veiculos.Veiculos veiculo);
        Models.Veiculos.Veiculos BuscarVeiculo(int IdVeiculo);

    }
}
