using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GS_EAP.Models.Veiculos
{
    public class Veiculos
    {
        [Key]
        public int IdVeiculo { get; set; }
        public string NomModelo { get; set; }
        public string NomMarca { get; set; }
        public string NumPlaca { get; set; }
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public virtual Usuarios.Usuarios Usuario { get; set; }
    }
}
