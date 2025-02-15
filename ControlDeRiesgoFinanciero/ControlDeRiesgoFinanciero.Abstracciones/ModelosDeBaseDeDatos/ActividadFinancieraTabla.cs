using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos
{
    [Table("ACTIVIDAD_FINANCIERA_TABLA")]
    public class ActividadFinancieraTabla
    {
        [Key]
        public int IdActividadFinanciera { get; set; }
        public string NombreActividadFinanciera { get; set; }
        public string DescripcionActividadFinanciera { get; set; }
        public int NivelDeRiesgo { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public DateTime FechaDeModificacion { get; set; }
        public bool Estado { get; set; }
    }
}
