﻿using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.PalabrasClave.Registrar
{
    public interface IRegistrarPalabraClaveAD
    {
        Task<int> Guardar(PalabrasClaveTabla laPalabraAGuardar);
    }
}
