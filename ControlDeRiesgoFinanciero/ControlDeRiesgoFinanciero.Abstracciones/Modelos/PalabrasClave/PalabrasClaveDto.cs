using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.Modelos.PalabrasClave
{
    public class PalabrasClaveDto
    {
        [Display(Name = "Id Palabra", Description = "Id Palabra")]
        [Required]
        public int IdPalabra { get; set; }

        [Display(Name = "Palabra", Prompt = "Ingrese la palabra clave", Description = "Palabra")]
        [MaxLength(30)]
        [Required]
        public string Palabra { get; set; }

        [Display(Name = "Orden", Prompt = "Ingrese la orden", Description = "Orden")]
        [Required]
        public int Orden { get; set; }

        [Display(Name = "Fecha de Registro", Prompt = "Ingrese la fecha de registro", Description = "Fecha de Registro")]
        [Required]
        public string FechaDeRegistro { get; set; }

        [Display(Name = "Fecha de Modificación", Prompt = "Ingrese la fecha de modificación", Description = "Fecha de Modificación")]
        [Required]
        public string FechaDeModificacion { get; set; }

        [Display(Name = "Estado", Prompt = "Ingrese el estado", Description = "Estado")]
        [Required]
        public bool Estado { get; set; }
    }
}

