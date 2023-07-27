using System;
using System.Collections.Generic;
using System.Text;

namespace MantenimientoUEBanos.WS
{
    internal class reparacionesporequipo
    {
        public int Cod_Reparacion { get; set; }

        public string No_Caso_Reparacion { get; set; }

        public string descripcion_problema_Reparacion { get; set; }

        public string fecha_ingreso_Reparacion { get; set; }

        public string fecha_entrega_Reparacion { get; set; }

        public int estado_Reparacion { get; set; }

        public string primerreporte_Reparacion { get; set; }

        public string segundoreporte_Reparacion { get; set; }

        public string componentesreemplazados_Reparacion { get; set; }

       
    }
}
