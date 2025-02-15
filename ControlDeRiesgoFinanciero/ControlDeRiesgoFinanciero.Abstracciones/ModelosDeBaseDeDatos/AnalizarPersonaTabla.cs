using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos
{
    [Table("ANALISIS_PERSONA_TABLA")]
    public class AnalizarPersonaTabla
    {

        [Key]
        public int IdAnalisis { get; set; }
        public int IdPersona { get; set; }
        public int NivelDeRiesgoGenerado { get; set; }
        public int TotalDePalabrasClaveEncontradas { get; set; }
        public int CanitdadDeArchivosEmparejados { get; set; }
        public DateTime FechaDeAnalisis { get; set; }
        public string Comentario { get; set; }
    }
}
