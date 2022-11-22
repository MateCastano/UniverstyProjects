using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aterrizar
{
    public class CAereo:CViaje
    {
        private static float impuesto;
        private ETipoVuelo tipoVuelo;
        public CAereo(string cod, string ori, string dest, float mon, ETipoVuelo tipoVuelo, byte cou):base(cod, ori, dest, mon, cou)
        {
            this.tipoVuelo = tipoVuelo;
        }
        public static void SetImpuesto(float imp)
        {
            CAereo.impuesto = imp;
        }
        public static float GetImpuesto()
        {
            return CAereo.impuesto;
        }
        public ETipoVuelo GetTipoVuelo()
        {
            return this.tipoVuelo;
        }
        public override string DarDatos()
        {
            return base.DarDatos() + " TIPO DE VUELO: " + GetTipoVuelo() + " IMPUESTOS A VIAJES AEREOS: " +  CAereo.GetImpuesto() + "\n";
        }
    }
}
