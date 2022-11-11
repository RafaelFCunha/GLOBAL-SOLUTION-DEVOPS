using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GS_EAP.Models.Usuarios
{
    public class Pontos
    {
        [Key]
        public int IdPonto { get; set; }
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public int QtdPontos { get; set; }
        public DateTime DatUltAlteracao { get; set; }

        public virtual Usuarios Usuario { get; set; }
    }
}
