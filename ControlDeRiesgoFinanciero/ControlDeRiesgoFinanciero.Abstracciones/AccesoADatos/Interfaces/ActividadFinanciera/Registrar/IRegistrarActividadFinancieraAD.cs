﻿using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadFinanciera.Registrar
{
    public interface IRegistrarActividadFinancieraAD
    {
        Task<int> Guardar(ActividadFinancieraTabla laActividadAGuardar);
    }
}
