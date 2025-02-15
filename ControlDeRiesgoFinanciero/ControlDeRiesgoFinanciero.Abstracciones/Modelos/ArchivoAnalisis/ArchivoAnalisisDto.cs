using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.Modelos.ArchivoAnalisis
{
    public class ArchivoAnalisisDto
    {
        [Key]
        public int IdArchivo { get; set; }

        [Display(Name = "Nombre", Prompt = "Ingrese el nombre del archivo", Description = "Nombre del archivo de análisis")]
        [Required(ErrorMessage = "El nombre del archivo es obligatorio.")]
        [MaxLength(10, ErrorMessage = "El nombre excede la cantidad de caracteres permitida (10 caracteres máximo).")]
        public string Nombre { get; set; }

        [Display(Name = "Texto del Archivo", Prompt = "Ingrese el contenido del archivo", Description = "Contenido completo del archivo de análisis")]
        [Required(ErrorMessage = "El texto del archivo es obligatorio.")]
        public string TextoDelArchivo { get; set; }

        [Display(Name = "Fuente", Prompt = "Ingrese la fuente del archivo", Description = "Fuente del archivo de análisis")]
        [Required(ErrorMessage = "La fuente es obligatoria.")]
        [MaxLength(2000, ErrorMessage = "La fuente excede los caracteres máximos permitidos (2000 caracteres) .")]
        public string Fuente { get; set; }

        [Display(Name = "Fecha de Registro", Description = "Fecha de registro del archivo")]
        [Required(ErrorMessage = "La fecha de registro es obligatoria.")]
        public string FechaDeRegistro { get; set; }

    }
}
