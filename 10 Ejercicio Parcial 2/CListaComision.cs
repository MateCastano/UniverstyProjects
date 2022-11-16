using System;
using System.Collections;

namespace _10_Ejercicio_Parcial_2
{
    public class CListaComision
    {
        private ArrayList listado;
        public CListaComision()
        {
            listado = new ArrayList();
        }
        public CComision buscar(string cod)
        {
            foreach (CComision aux in this.listado)
            {
                if (aux.GetCodigo() == cod)
                {
                    return aux;
                }
            }
            return null;
        }
        public bool registrar(CComision com)
        {
            if (this.buscar(com.GetCodigo()) == null)
            {
                this.listado.Add(com);
                return true;
            }
            return false;
        }
        public bool registrar(string cod, string tur)
        {
            if (this.buscar(cod) == null)
            {
                this.listado.Add(new CComision(cod, tur));
                return true;
            }
            return false;
        }
        public bool asignarDocente(CDocente doc, string cod)
        {
            CComision com = this.buscar(cod);
            if (com != null)
            {
                return com.asignarDocente(doc);
            }
            return false;
        }
        public bool removerDocente(string cod, uint leg)
        {
            CComision com = this.buscar(cod);
            if(com != null)
            {
                com.removerDocente(leg);
                return true;
            }
            return false;
        }
        public bool asignarAlumnos(CAlumno alu, string cod)
        {
            CComision com = this.buscar(cod);
            if (com != null)
            {
                return com.asignarAlumnos(alu);
            }
            return false;
        }
        public bool removerAlumno(string cod, uint leg)
        {
            CComision com = this.buscar(cod);
            if (com != null)
            {
                com.removerAlumno(leg);
                return true;
            }
            return false;
        }
        public string darDatos(string cod)
        {
            CComision aux = this.buscar(cod);
            if (aux != null)
            {
                return aux.DarDatos();
            }

            return "COMISION INEXISTENTE";
        }
        public string darLista()
        {
            string data = "";

            if (this.listado.Count != 0)
            {
                foreach (CComision aux in this.listado) data += aux.DarDatos() + "\n";
                return data;
            }
            return "NO SE REGISTRARON COMISIONES";
        }
    }
}
