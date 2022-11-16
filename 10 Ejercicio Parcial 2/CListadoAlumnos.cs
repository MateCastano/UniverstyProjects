using System;
using System.Collections;

namespace _10_Ejercicio_Parcial_2
{
    public class CListadoAlumnos
    {
        private ArrayList listado;
        public CListadoAlumnos()
        {
            this.listado = new ArrayList();
        }
        public CAlumno buscar(uint leg)
        {
            foreach(CAlumno aux in this.listado)
            {
                if(aux.GetLegajo() == leg)
                {
                    return aux;
                } 
            }
            return null;
        }
        public bool registrar(CAlumno alu)
        {
            if (this.buscar(alu.GetLegajo()) == null)
            {
                this.listado.Add(alu);
                return true;
            }
            return false;
        }
        public bool registrar(string nom, string ape, string dni, uint leg, string tit)
        {
            if (this.buscar(leg) == null)
            {
                this.listado.Add(new CAlumno(nom, ape, dni, leg, tit));
                return true;
            }
            return false;
        }
        public bool remover(uint leg)
        {
            CAlumno alu = this.buscar(leg);
            if (alu != null)
            {
                this.listado.Remove(alu);
                return true;
            }
            return false;
        }
        public string darDatos(uint leg)
        {
            CAlumno aux = this.buscar(leg);
            if(aux != null)
            {
                return aux.DarDatos();
            }

            return "ALUMNO INEXISTENTE";
        }
        public string darLista()
        {
            string data = "";
            
            if(this.listado.Count != 0)
            {
                foreach (CAlumno aux in this.listado) data += aux.DarDatos() + "\n";
                return data;
            }
            return "NO SE REGISTRARON ALUMNOS";
        }
    }
}
