using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Manatial_de_Vida.Models
{
    public class Miembro
    {
        public int Id { get; set; }
        [DisplayName("Nombre del miembro")]
        [Required(ErrorMessage = "El nombre es  requerido")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "  El {0} Solo permite letras.")]
        [StringLength(50, ErrorMessage = " El {0} de contenener entre {2} y {1}  caracteres.", MinimumLength = 2)]
        public string Nombre { get; set; }
        public string TipoMiembro { get; set; }
    }
}