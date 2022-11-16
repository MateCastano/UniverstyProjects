using System;
using System.Collections;
namespace Constructora
{
    public class CListadoEmpleados
    {
        //Variables Miembro
        private ArrayList listado;
        //Constructor
        public CListadoEmpleados()
        {
            this.listado = new ArrayList();
        }
        public CEmpleado buscar(string doc)
        {
            foreach (CEmpleado aux in this.listado)
            {
                if (aux.getDNI() == doc) return aux;
            }
            return null;
        }
        public bool registrar(CEmpleado emp)
        {
            if (this.buscar(emp.getDNI()) == null)
            {
                this.listado.Add(emp);
                return true;
            }
            return false;
        }
        public bool registrar(string doc, string ape, string nom, EEspecialidad esp)
        {
            if (this.buscar(doc) == null)
            {
                this.listado.Add(new CObrero(doc, ape, nom, esp));
                return true;
            }
            return false;
        }
        
        public bool registrar(string doc, string ape, string nom, uint mat)
        {
            if (this.buscar(doc) == null)
            {
                this.listado.Add(new CCapataz(doc, ape, nom, mat));
                return true;
            }
            return false;
        }
        public string darDatos(string doc)
        {
            CEmpleado aux = this.buscar(doc);
            if (aux != null) return aux.darDatos();
            return "Empleado Inexistente";
        }
        public string darDatos()
        {

            if (this.listado.Count != 0)
            {
                String datos = "";
                this.ordenar();
                foreach (CEmpleado aux in this.listado) datos += aux.darDatos() + "\n";
                return datos;
            }
            return "No se registraron empleados válidos";
        }
        public bool eliminar(string doc)
        {
            CEmpleado aux = this.buscar(doc);
            if (aux != null)
            {
                aux.desocupar();
                this.listado.Remove(aux);
                return true;
            }
            return false;
        }
        public void ordenar()
        {
            this.listado.Sort();
        }
    }
}

