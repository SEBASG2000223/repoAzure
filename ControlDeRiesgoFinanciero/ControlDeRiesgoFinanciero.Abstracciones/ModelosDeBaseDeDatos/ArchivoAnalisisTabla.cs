using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos
{
    [Table("ARCHIVO_ANALISIS_TABLA")]
    public class ArchivoAnalisisTabla
    {
        [Key]
        public int IdArchivo { get; set; }
        public string Nombre { get; set; }
        public string TextoDelArchivo { get; set; }
        public string Fuente { get; set; }
        public DateTime FechaDeRegistro { get; set; }
    }
}
