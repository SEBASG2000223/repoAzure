using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadPersona.ListarPersonas;
using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ArchivoAnalisis.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.PalabrasClave.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.Personas.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.AnalizarPersona.Analizar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.PalabrasClave;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ArchivoAnalisis;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.PalabrasClave;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.ActividadPersona.ListarPersonasPorId;
using ControlDeRiesgoFinanciero.AccesoADatos.ArchivoAnalisis.Listar;
using ControlDeRiesgoFinanciero.AccesoADatos.PalabrasClave.Listar;
using ControlDeRiesgoFinanciero.AccesoADatos.Personas.ObtenerPorId;
using ControlDeRiesgoFinanciero.LN.General.Conversiones.PalabrasClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.AnalizarPersona.Analizar
{
    public class AnalizarPersonaLN : IAnalizarPersonaLN
    {
        IObtenerPersonasPorIdAD _obtenerPorIdAD;
        IListarPalabraClaveAD _listarPalabraClaveAD;
        IConvertirAPalabrasClaveDto _convertirAPalabrasClaveDto;
        IListarPersonasPorIdAD _listarActividadesAD;
        IListarArchivoAnalisisAD _listarArchivoAnalisisAD;

        public AnalizarPersonaLN()
        {
            _obtenerPorIdAD = new ObtenerPersonasPorIdAD();
            _listarPalabraClaveAD = new ListarPalabraClaveAD();
            _convertirAPalabrasClaveDto = new ConvertirAPalabrasClaveDto();
            _listarActividadesAD = new ListarPersonasPorIDAD();
            _listarArchivoAnalisisAD = new ListarArchivoAnalisisAD();


        }


        public (string nivelRiesgo, int cantidadPalabrasClave, int cantidadArchivos) RealizarAnalisis(int idPersona)
        {
            List<PalabrasClaveDto> palabrasClaveLista = ListarPalabras();

            PersonasDto persona = Obtener(idPersona);
            List<ArchivoAnalisisDto> archivos = ObtenerArchivos(persona);
            
            int contadorPalabras = 0;

            // Lista de palabras para convertirlas en string para el foreach
            List<string> palabrasClave = palabrasClaveLista.Select(p => p.Palabra).ToList();

            foreach (var archivo in archivos)
            {
                string contenidoArchivo = archivo.TextoDelArchivo; 
                List<string> palabrasEncontradas = new List<string>();

                foreach (var palabra in palabrasClave)
                {
                    if (contenidoArchivo.IndexOf(palabra, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        if (!palabrasEncontradas.Contains(palabra))
                        {
                            palabrasEncontradas.Add(palabra);
                            contadorPalabras++;
                        }
                    }
                }
            }

            List<ActividadPersonaDto> actividades = ListarActividades(idPersona);

            int cantidadArchivos = archivos.Count;
            int cantidadPalabrasClave = contadorPalabras;
            int actividadesBajas = actividades.Count(a => a.NivelDeRiesgo == 1);
            int actividadesMedias = actividades.Count(a => a.NivelDeRiesgo == 2);
            int actividadesAltas = actividades.Count(a => a.NivelDeRiesgo == 3);

            string nivelRiesgo = "";

            if (actividadesBajas >= 1 && actividadesBajas <= 5 && cantidadArchivos >= 1 && cantidadPalabrasClave == 0)
            {
                nivelRiesgo = "Riesgo bajo";
            }
            else if ((actividadesBajas > 5 || actividadesMedias >= 1) && cantidadArchivos > 4 && cantidadPalabrasClave >= 1 && cantidadPalabrasClave <= 5)
            {
                nivelRiesgo = "Riesgo medio";
            }
            else if ((actividadesMedias > 4 || actividadesAltas >= 1) && cantidadArchivos >= 5 && cantidadArchivos <= 9 && cantidadPalabrasClave >= 5 && cantidadPalabrasClave <= 10)
            {
                nivelRiesgo = "Riesgo alto";
            }
            else if (actividadesAltas > 1 && cantidadArchivos > 10 && cantidadPalabrasClave > 10)
            {
                nivelRiesgo = "Riesgo crítico";
            }
            return (nivelRiesgo, cantidadPalabrasClave, cantidadArchivos);
        }

        private List<ArchivoAnalisisDto> FiltrarArchivosPorPersonaFisica(List<ArchivoAnalisisDto> listaDeArchivos, PersonasDto persona)
        {
            return listaDeArchivos.Where(archivo =>
            
                (!string.IsNullOrEmpty(persona.NombrePersona) && archivo.TextoDelArchivo.IndexOf(persona.NombrePersona, StringComparison.OrdinalIgnoreCase) >= 0) ||
                (!string.IsNullOrEmpty(persona.PrimerApellidoPersona) && archivo.TextoDelArchivo.IndexOf(persona.PrimerApellidoPersona, StringComparison.OrdinalIgnoreCase) >= 0) ||
                (!string.IsNullOrEmpty(persona.SegundoApellidoPersona) && archivo.TextoDelArchivo.IndexOf(persona.SegundoApellidoPersona, StringComparison.OrdinalIgnoreCase) >= 0) ||
                (!string.IsNullOrEmpty(persona.IdentificacionPersona) && archivo.TextoDelArchivo.IndexOf(persona.IdentificacionPersona, StringComparison.OrdinalIgnoreCase) >= 0)
            ).ToList();
        }

   
        private List<ArchivoAnalisisDto> FiltrarArchivosPorPersonaJuridica(List<ArchivoAnalisisDto> listaDeArchivos, PersonasDto persona)
        {
            return listaDeArchivos.Where(archivo =>
             
                (!string.IsNullOrEmpty(persona.NombrePersona) && archivo.TextoDelArchivo.IndexOf(persona.NombrePersona, StringComparison.OrdinalIgnoreCase) >= 0) ||
                (!string.IsNullOrEmpty(persona.IdentificacionPersona) && archivo.TextoDelArchivo.IndexOf(persona.IdentificacionPersona, StringComparison.OrdinalIgnoreCase) >= 0)
            ).ToList();
        }

        private List<ArchivoAnalisisDto> ObtenerArchivos(PersonasDto persona)
        {
            List<ArchivoAnalisisDto> listaDeArchivos = _listarArchivoAnalisisAD.Listar();

            if (persona.TipoIdentificacion == 1)
            {
                return FiltrarArchivosPorPersonaFisica(listaDeArchivos, persona);
            }
            else if (persona.TipoIdentificacion == 2)
            {
                return FiltrarArchivosPorPersonaJuridica(listaDeArchivos, persona);
            }

            return new List<ArchivoAnalisisDto>();
        }

        private List<ActividadPersonaDto> ListarActividades(int idPersona)
        {
            List<ActividadPersonaDto> laListaDeActividades = _listarActividadesAD.ListarActividades(idPersona);
            return laListaDeActividades;
        }

      
       

        private PersonasDto Obtener(int IdPersona)
        {
            PersonasTabla laPersonaEnBD = _obtenerPorIdAD.Obtener(IdPersona);
            PersonasDto laPersonaAMostrar = ConvertirAPersonaAMostrar(laPersonaEnBD);
            return laPersonaAMostrar;
        }


        private List<PalabrasClaveDto> ListarPalabras()
        {
            List<PalabrasClaveDto> laListaDePalabras = _listarPalabraClaveAD.Listar();
            return laListaDePalabras;
        }
        private PersonasDto ConvertirAPersonaAMostrar(PersonasTabla laPersonaEnBD)
        {
            return new PersonasDto
            {
                IdPersona = laPersonaEnBD.IdPersona,
                IdentificacionPersona = laPersonaEnBD.IdentificacionPersona,
                TipoIdentificacion = laPersonaEnBD.TipoIdentificacion,
                NombrePersona = laPersonaEnBD.NombrePersona,
                PrimerApellidoPersona = laPersonaEnBD.PrimerApellidoPersona,
                SegundoApellidoPersona = laPersonaEnBD.SegundoApellidoPersona,
                Estado = laPersonaEnBD.Estado
            };
        }

      


    }
}
