using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas
{
    public class PersonasDto
    {
        [Display(Name = "Id Persona", Description = "Id Persona")]
        [Required]
        public int IdPersona { get; set; }

        [Display(Name = "Identificación Persona", Prompt = "Ingrese la identificación de la persona", Description = "Identificación Persona")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten números.")]
        [MaxLength(30)]
        [Required]
        public string IdentificacionPersona { get; set; }

        [Display(Name = "Tipo Identificación", Prompt = "Ingrese el tipo de identificación", Description = "Tipo Identificación")]
        [Required]
        public int TipoIdentificacion { get; set; }

        [Display(Name = "Nombre Persona", Prompt = "Ingrese el nombre de la persona", Description = "Nombre Persona")]
        [MaxLength(100)]
        [Required]
        public string NombrePersona { get; set; }

        [Display(Name = "Primer Apellido Persona", Prompt = "Ingrese el primer apellido de la persona", Description = "Primer Apellido Persona")]
        [MaxLength(100)]
        [Required]
        public string PrimerApellidoPersona { get; set; }

        [Display(Name = "Segundo Apellido Persona", Prompt = "Ingrese el segundo apellido de la persona", Description = "Segundo Apellido Persona")]
        [MaxLength(100)]
        [Required]
        public string SegundoApellidoPersona { get; set; }

        [Display(Name = "Teléfono", Prompt = "Ingrese el teléfono", Description = "Teléfono")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten números.")]
        [MaxLength(20)]
        [Required]
        public string Telefono { get; set; }

        [Display(Name = "Correo Electrónico", Prompt = "Ingrese el correo electrónico", Description = "Correo Electrónico")]
        [EmailAddress(ErrorMessage = "Por favor, ingrese un correo electrónico válido.")]
        [MaxLength(200)]
        [Required]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Dirección", Prompt = "Ingrese la dirección", Description = "Dirección")]
        [MaxLength(500)]
        [Required]
        public string Direccion { get; set; }

        [Display(Name = "Estado de Riesgo", Prompt = "Ingrese el estado de riesgo", Description = "Estado de Riesgo")]
        [Required]
        public int EstadoDeRiesgo { get; set; }

        [Display(Name = "Fecha de Registro", Prompt = "Ingrese la fecha de registro", Description = "Fecha de Registro")]
        [Required]
        public string FechaDeRegistro { get; set; }

        [Display(Name = "Fecha de Modificación", Prompt = "Ingrese la fecha de modificación", Description = "Fecha de Modificación")]
        [Required]
        public string FechaDeModificacion { get; set; }

        [Display(Name = "Estado", Prompt = "Ingrese el estado", Description = "Estado")]
        [Required]
        public bool Estado { get; set; }
    }
}
