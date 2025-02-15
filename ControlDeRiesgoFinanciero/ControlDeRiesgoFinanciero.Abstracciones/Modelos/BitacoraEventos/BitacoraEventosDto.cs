using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.Modelos.BitacoraEventos
{
    public class BitacoraEventosDto
    {
        [Display(Name = "ID del Evento")]
        public int IdEvento { get; set; }

        [Display(Name = "Tabla Asociada al Evento")]
        [Required]
        public string TablaDeEvento { get; set; }

        [Display(Name = "Tipo de Evento")]
        public string TipoDeEvento { get; set; }

        [Display(Name = "Fecha del Evento")]
        public DateTime FechaDeEvento { get; set; }

        [Display(Name = "Descripción del Evento")]
        public string DescripcionDeEvento { get; set; }

        [Display(Name = "Detalles de la Excepción")]
        public string StackTrace { get; set; }

        [Display(Name = "Datos Anteriores")]
        public string DatosAnteriores { get; set; }

        [Display(Name = "Datos Posteriores")]
        public string DatosPosteriores { get; set; }
    }
}
