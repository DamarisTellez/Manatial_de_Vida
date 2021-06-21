using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Manatial_de_Vida.Models
{
    public class Horario
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
    }
}
