using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora
{
    public class CDirección
    {
        private string calle;
        private uint número;
        private string localidad;
        private string provincia;

        public CDirección(string cal, uint núm, string loc, string pro)
        {
            this.calle = cal;
            this.número = núm;
            this.localidad = loc;
            this.provincia = pro;
        }
        public string darDatos()
        {
            return "Dirección: " + this.calle + " N° " + this.número.ToString() + " " + this.localidad + " " + this.provincia;
        }

    }
}
