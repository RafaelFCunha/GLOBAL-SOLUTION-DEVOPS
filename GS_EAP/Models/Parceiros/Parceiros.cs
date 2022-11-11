using System.ComponentModel.DataAnnotations;

namespace GS_EAP.Models.Parceiros
{
    public class Parceiros
    {
        [Key]
        public int IdParceiro { get; set; }
        public string NomParceiro { get; set; }
        public string NumCNPJ { get; set; }
        public string NomLogradouro { get; set; }
        public string NomCidade { get; set; }
        public string NomEstado { get; set; }
        public string NomComplemento { get; set; }
        public string NomCEP { get; set; }
        public bool Status { get; set; }
    }
}
