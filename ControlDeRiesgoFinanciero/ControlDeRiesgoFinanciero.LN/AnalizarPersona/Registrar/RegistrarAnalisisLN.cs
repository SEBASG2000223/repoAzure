using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.AnalizarPersona;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.AnalizarPersona.Analizar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.AnalizarPersona.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.AnalizarPersona;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.AnalizarPersona.Registrar;
using ControlDeRiesgoFinanciero.LN.AnalizarPersona.Analizar;
using ControlDeRiesgoFinanciero.LN.General;
using System;

namespace ControlDeRiesgoFinanciero.LN.AnalizarPersona.Registrar
{
    public class RegistrarAnalisisLN : IRegistrarAnalisisLN
    {
        IRegistrarAnalisisAD _registrarAnalisisAD;
        IAnalizarPersonaLN _analizarPersonaLN;
        IFecha _fecha;

        public RegistrarAnalisisLN()
        {
            _registrarAnalisisAD = new RegistrarAnalisisAD();
            _analizarPersonaLN = new AnalizarPersonaLN();
            _fecha = new Fecha();
        }

        public void RegistrarAnalisis(int idPersona)
        {
            var (nivelDeRiesgo, cantidadPalabrasClave, cantidadArchivos) = _analizarPersonaLN.RealizarAnalisis(idPersona);

            int nivelDeRiesgoGenerado = ConvertirNivelDeRiesgo(nivelDeRiesgo);

            var analisis = new AnalizarPersonaTabla
            {
                IdPersona = idPersona,
                NivelDeRiesgoGenerado = nivelDeRiesgoGenerado,
                TotalDePalabrasClaveEncontradas = cantidadPalabrasClave,
                CanitdadDeArchivosEmparejados = cantidadArchivos,
                FechaDeAnalisis = _fecha.ObtenerFecha(), 
                Comentario = GenerarComentario(nivelDeRiesgoGenerado)
            };

            _registrarAnalisisAD.Registrar(analisis);
        }
       
        

        private int ConvertirNivelDeRiesgo(string nivelDeRiesgo)
        {
            if (nivelDeRiesgo == "Sin análisis") return 0;
            if (nivelDeRiesgo == "Riesgo bajo") return 1;
            if (nivelDeRiesgo == "Riesgo medio") return 2;
            if (nivelDeRiesgo == "Riesgo alto") return 3;
            if (nivelDeRiesgo == "Riesgo crítico") return 4;
            return 0;
        }


        private string GenerarComentario(int nivelDeRiesgo)
        {
            if (nivelDeRiesgo == 0) return "No se encontraron suficientes datos para el análisis.";
            if (nivelDeRiesgo == 1) return "Nivel de riesgo bajo basado en los datos analizados.";
            if (nivelDeRiesgo == 2) return "Riesgo moderado, revisar los datos detallados.";
            if (nivelDeRiesgo == 3) return "Riesgo elevado, se recomienda mayor atención.";
            if (nivelDeRiesgo == 4) return "Riesgo crítico, acción inmediata requerida.";
            return "Análisis realizado.";
        }

      

    }
}


