using System;
using System.Collections.Generic;
using GS_EAP.Models.Base;

namespace GS_EAP.Repository.Interfaces.Parceiros
{
    public interface IParceirosRepository : IDisposable
    {
        List<Models.Parceiros.Parceiros> ListarParceiros();
        Resultado CriarParceiro(Models.Parceiros.Parceiros parceiro);
        Resultado EditarParceiro(Models.Parceiros.Parceiros parceiro);
        Resultado DeletarParceiro(Models.Parceiros.Parceiros parceiro);
        Models.Parceiros.Parceiros BuscarParceiro(int IdParceiro);

    }
}
