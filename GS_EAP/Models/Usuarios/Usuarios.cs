using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GS_EAP.Models.Usuarios
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        public string NomUsuario { get; set; }
        public string NomEmail { get; set; }
        public string NomSenha { get; set; }
        public string NomLogradouro { get; set; }
        public string NomCidade { get; set; }
        public string NomEstado { get; set; }
        public string NomComplemento { get; set; }
        public string NomCEP { get; set; }
        public string NumCPF { get; set; }
        public string NumTelefone { get; set; }
    }
}
