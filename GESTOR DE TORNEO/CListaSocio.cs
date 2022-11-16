using System;
using System.Collections;

namespace _11_Ejercicio_Parcial_2
{
    public class CListaSocio
    {
        private ArrayList listado;
        public CListaSocio()
        {
            listado = new ArrayList();
        }
        public CSocio buscar(string dni)
        {
            foreach (CSocio aux in this.listado)
            {
                if (aux.GetDNI() == dni) return aux;
            }
            return null;
        }
        public bool registrarJugador(string dni, string ape, string nom, EPosicion pos)
        {
            if (this.buscar(dni) == null)
            {
                this.listado.Add(new CJugador(dni, ape, nom, pos));
                return true;
            }
            return false;
        }
        public bool registrarJugador(CJugador jug)
        {
            if (this.buscar(jug.GetDNI()) == null)
            {
                jug.Registrado();
                this.listado.Add(jug);
                return true;
            }
            return false;
        }
        public bool registrarEntrenador(string dni, string ape, string nom, string tel)
        {
            if (this.buscar(dni) == null)
            {
                this.listado.Add(new CEntrenador(dni, ape, nom, tel));
                return true;
            }
            return false;
        }
        public bool registrarEntrenador(CEntrenador dt)
        {
            if (this.buscar(dt.GetDNI()) == null)
            {
                this.listado.Add(dt);
                return true;
            }
            return false;
        }
        public bool Remover(string dni)
        {
            CSocio soc = this.buscar(dni);
            if (soc != null)
            {
                soc.Desregistrar();
                this.listado.Remove(soc);
                return true;
            }
            return false;
        }
        public string darLista()
        {
            if (this.listado.Count != 0)
            {
                string datos = "";
                foreach (CSocio aux in this.listado) datos += aux.darDatos() + "\n";
                return datos;
            }
            return "NO SE REGISTRARON JUGADORES";
        }
    }
}
