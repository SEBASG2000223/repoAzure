using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadFinanciera
{
    public class ActividadFinancieraDto
    {
        [Key]
        public int IdActividadFinanciera { get; set; }
        [Display(Name = "Actividad Financiera", Prompt = "Ingrese el nombre de la actividad financiera", Description = "Nombre Actividad Financiera")]
        [Required]
        public string NombreActividadFinanciera { get; set; }
        [Display(Name = "Descripción", Prompt = "Ingrese la descripcion de la actividad financiera", Description = "Descripcion Actividad Financiera")]
        [Required]
        public string DescripcionActividadFinanciera { get; set; }
        [Display(Name = "Nivel de Riesgo", Prompt = "Ingrese el nivel de riesgo de la actividad financiera", Description = "Nivel de Riesgo Actividad Financiera")]
        [Required]
        public int NivelDeRiesgo { get; set; }
        [Display(Name = "Fecha de registro", Description = "Fecha de resgistro")]
        [Required]
        public string FechaDeRegistro { get; set; }
        [Required]
        public string FechaDeModificacion { get; set; }
        [Required]
        public bool Estado { get; set; } = true;
    }
}
