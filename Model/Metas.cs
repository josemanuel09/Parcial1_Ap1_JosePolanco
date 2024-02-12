using System.ComponentModel.DataAnnotations;

namespace Parcial1_Ap1_JosePolanco.Model
{
    public class Metas
    {
        [Key]
        public int MetaId { get; set; }

        [Required(ErrorMessage = "Es obligatorio ")]
        public DateTime Fecha{ get; set; }

        [Required(ErrorMessage = "Es obligatorio ")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Es obligatorio ")]
        public decimal Monto { get; set; }
    }
}
