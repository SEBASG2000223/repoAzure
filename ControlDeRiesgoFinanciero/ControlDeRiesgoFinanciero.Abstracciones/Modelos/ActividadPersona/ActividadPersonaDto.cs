using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona
{
    using System.ComponentModel.DataAnnotations;

    public class ActividadPersonaDto
    {
        public int IdActividadPersona { get; set; }

        [Required]
        [Display(Name = "Actividad Financiera", Prompt = "Ingrese el nombre de la actividad financiera", Description = "Nombre Actividad Financiera")]
        public int IdActividadFinanciera { get; set; }

        [Required]
        [Display(Name = "Persona", Prompt = "Ingrese el nombre de la persona", Description = "Nombre de la Persona")]
        public int IdPersona { get; set; }

        [Display(Name = "Fecha de Registro", Description = "Fecha en que se registró la actividad")]
        public string FechaDeRegistro { get; set; }

        [Display(Name = "Fecha de Modificación", Description = "Fecha en que se modificó la actividad")]
        public string FechaDeModificacion { get; set; }

        [Required]
        [Display(Name = "Estado", Description = "Estado de la actividad financiera")]
        public bool Estado { get; set; }

        [Display(Name = "Nombre Actividad Financiera", Prompt = "Ingrese el nombre de la actividad financiera", Description = "Nombre Actividad Financiera")]
        public string NombreActividadFinanciera { get; set; }

        [Display(Name = "Nivel de Riesgo", Description = "Nivel de riesgo asociado a la actividad financiera")]
        public int NivelDeRiesgo { get; set; }

        [Display(Name = "Nombre de Persona", Prompt = "Ingrese el nombre completo de la persona", Description = "Nombre completo de la persona")]
        public string NombrePersona { get; set; }


    }

}
