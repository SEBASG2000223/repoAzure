using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.Modelos.AnalizarPersona
{
    public class AnalizarPersonaDto
    {
        [Key]
        public int IdAnalisis { get; set; }
        [Display(Name = "Id Persona", Prompt = "Id Persona", Description = "Id Persona")]
        [Required]
        public int IdPersona { get; set; }
        [Display(Name = "Nivel de riesgo del análisis", Prompt = "Nivel de riesgo del análisis", Description = "Nivel de riesgo del análisis")]
        [Required]
        public int NivelDeRiesgoGenerado { get; set; }
        [Display(Name = "Cantidad de palabras clave", Prompt = "Cantidad de palabras clave", Description = "Cantidad de palabras clave")]
        [Required]
        public int TotalDePalabrasClaveEncontradas { get; set; }
        [Display(Name = "Cantidad de archivos", Prompt = "Cantidad de archivos", Description = "Cantidad de archivos")]
        [Required]
        public int CanitdadDeArchivosEmparejados { get; set; }
        [Display(Name = "Fecha de análisis", Prompt = "Fecha de análisis", Description = "Fecha de análisis")]
        [Required]
        public string FechaDeAnalisis { get; set; }
        [Display(Name = "Comentario", Prompt = "Comentario", Description = "Comentario")]
        [Required]
        public string Comentario { get; set; }

    }
}
