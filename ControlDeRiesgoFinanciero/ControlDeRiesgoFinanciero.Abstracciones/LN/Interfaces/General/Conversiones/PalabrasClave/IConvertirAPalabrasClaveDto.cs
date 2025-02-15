﻿using ControlDeRiesgoFinanciero.Abstracciones.Modelos.PalabrasClave;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.PalabrasClave
{
    public interface IConvertirAPalabrasClaveDto
    {
        PalabrasClaveDto ConvertirObjetoAPalabrasClaveDto(PalabrasClaveTabla laPalabra);
    }
}
