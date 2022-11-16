using System;
using System.Collections;

namespace _10_Ejercicio_Parcial_2
{
    public class CComision
    {
        private string codigo;
        private string turno;
        private CListadoAlumnos alumnos;
        private CListadoDocente docentes;
        public CComision(string cod, string tur)
        {
            this.codigo = cod;
            this.turno = tur;
            alumnos = new CListadoAlumnos();
            docentes = new CListadoDocente();
        }
        public CComision() : this("SIN ASIGNAR","SIN ASIGNAR") { }
        public void SetCodigo(string cod)
        {
            this.codigo = cod;
        }
        public void SetTurno(string tur)
        {
            this.turno = tur;
        }
        public string GetCodigo()
        {
            return this.codigo;
        }
        public string GetTurno()
        {
            return this.turno;
        }
        public bool asignarDocente(CDocente doc)
        {
            if(doc is CDocente)
            {
                this.docentes.registrar(doc);
                return true;
            }
            return false;
        }
        public bool removerDocente(uint leg)
        {
            if(this.docentes.buscar(leg) != null)
            {
                this.docentes.remover(leg);
                return true;
            }
            return false;
        }
        public bool removerAlumno(uint leg)
        {
            if (this.alumnos.buscar(leg) != null)
            {
                this.alumnos.remover(leg);
                return true;
            }
            return false;
        }
        public bool asignarAlumnos(CAlumno alu)
        {
            if (alu is CAlumno)
            {
                this.alumnos.registrar(alu);
                return true;
            }
            return false;
        }
        public string DarDatos()
        {
            string data = "";

            return data += "\nCODIGO: " + this.codigo + " TURNO: " + this.turno + "\n";
        }
        public string DarAlumnos()
        {
            return this.alumnos.darLista();
        }
        public string DarDocente()
        {
            return this.docentes.darLista();
        }
    }
}
