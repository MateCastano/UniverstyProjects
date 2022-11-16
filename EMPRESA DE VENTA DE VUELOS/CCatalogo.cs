using System;
using System.Collections;

namespace Aterrizar
{
    public class CCatalogo
    {
        private ArrayList listado;
        public CCatalogo()
        {
            listado = new ArrayList(0);
        }
        public CViaje buscar(string cod)
        {
            foreach (CViaje aux in this.listado)
            {
                if (aux.GetCodigo() == cod) return aux;
            }
            return null;
        }
        public bool Registar(string cod, string ori, string dest, float pre, ETipoVuelo tipoVuelo, byte cou)
        {
            this.listado.Add(new CAereo(cod, ori, dest, pre, tipoVuelo, cou));
            return true;
        }
        public string darCatalogo()
        {
            if (this.listado.Count != 0)
            {
                String datos = "";
                foreach (CViaje aux in this.listado) datos += aux.DarDatos() + "\n";
                return datos;
            }
            return "NO SE REGISTRARON VIAJES";
        }
        public string CompararViajes(string cod, string cod2)
        {
            CViaje aux1 = this.buscar(cod);
            CViaje aux2 = this.buscar(cod2);
            if (aux1 != null && aux2 != null)
            {
                if (aux1.CompareTo(aux2) == 0)
                {
                    return "LOS VIAJES TIENEN EL MISMO ORIGEN Y DESTINO";
                }
                if (aux1.CompareTo(aux2) == 1)
                {
                    return "LOS VIAJES TIENEN EL MISMO ORIGEN PERO NO DESTINO";
                }
                if (aux1.CompareTo(aux2) == 2)
                {
                    return "LOS VIAJES NO TIENEN EL MISMO ORIGEN PERO SI EL MISMO DESTINO";
                }
                if (aux1.CompareTo(aux2) == 3)
                {
                    return "LOS VIAJES NO TIENEN EL MISMO ORIGEN NI EL MISMO DESTINO";
                }
            }
            return "SE INGRESO MAL LOS VIAJES";
        }
        public bool Remover(string cod)
        {
            CViaje aux = this.buscar(cod);
            if(aux != null)
            {
                this.listado.Remove(aux);
                return true;
            }
            return false;
        }
        public bool Remover()
        {
            this.listado.Clear();
            return true;
        }
    }
}
