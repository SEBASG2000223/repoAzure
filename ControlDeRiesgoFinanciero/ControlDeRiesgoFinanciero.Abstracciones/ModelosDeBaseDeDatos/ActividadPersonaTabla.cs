using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos
{
    [Table("ACTIVIDAD_PERSONA_TABLA")]
    public class ActividadPersonaTabla
    {

        [Key] 
        public int IdActividadPersona { get; set; }
        public int IdActividadFinanciera { get; set; }
        public int IdPersona { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public DateTime FechaDeModificacion { get; set; }
        public bool Estado { get; set; }
    }
}
