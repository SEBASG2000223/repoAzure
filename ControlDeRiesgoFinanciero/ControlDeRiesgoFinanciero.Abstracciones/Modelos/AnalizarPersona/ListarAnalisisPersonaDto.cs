using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.Modelos.AnalizarPersona
{
    public class ListarAnalisisPersonaDto
    {
        [Display(Name = "Id Persona", Prompt = "Id Persona", Description = "Id Persona")]
        [Required]
        public int IdPersona { get; set; }
        [Display(Name = "Tipo de Identificación")]
        public int TipoIdentificacion { get; set; }

        [Display(Name = "Nombre de la Persona")]
        public string NombrePersona { get; set; }

        [Display(Name = "Primer Apellido")]
        public string PrimerApellidoPersona { get; set; }

        [Display(Name = "Segundo Apellido")]
        public string SegundoApellidoPersona { get; set; }

        [Display(Name = "Nivel de Riesgo")]
        public int NivelDeRiesgo { get; set; }

        [Display(Name = "Fecha del Último Análisis")]
        public DateTime FechaUltimoAnalisis { get; set; }
    }
}
