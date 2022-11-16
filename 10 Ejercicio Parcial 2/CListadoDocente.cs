using System;
using System.Collections;

namespace _10_Ejercicio_Parcial_2
{
    public class CListadoDocente
    {
        private ArrayList listado;
        public CListadoDocente()
        {
            this.listado = new ArrayList();
        }
        public CDocente buscar(uint leg)
        {
            foreach (CDocente aux in this.listado)
            {
                if (aux.GetLegajo() == leg)
                {
                    return aux;
                }
            }
            return null;
        }
        public bool registrar(CDocente alu)
        {
            if (this.buscar(alu.GetLegajo()) == null)
            {
                this.listado.Add(alu);
                return true;
            }
            return false;
        }
        public bool registrar(string nom, string ape, string dni, uint leg, ECategoria cat)
        {
            if (this.buscar(leg) == null)
            {
                this.listado.Add(new CDocente(nom, ape, dni, leg, cat));
                return true;
            }
            return false;
        }
        public bool remover(uint leg)
        {
            CDocente doc = this.buscar(leg);
            if (doc != null)
            {
                this.listado.Remove(doc);
                return true;
            }
            return false;
        }
        public string darDatos(uint leg)
        {
            CDocente aux = this.buscar(leg);
            if (aux != null)
            {
                return aux.DarDatos();
            }

            return "DOCENTE INEXISTENTE";
        }
        public string darLista()
        {
            string data = "";

            if (this.listado.Count != 0)
            {
                foreach (CDocente aux in this.listado) data += aux.DarDatos() + "\n";
                return data;
            }
            return "NO SE REGISTRARON DOCENTE";
        }
    }
}
