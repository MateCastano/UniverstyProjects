using System;
using System.Collections;


namespace _10_Ejercicio_Parcial_2
{
    public class CUniversidad
    {
        private CListadoAlumnos alumnos;
        private CListadoDocente docentes;
        private CListaComision comision;
        public CUniversidad()
        {
            this.alumnos = new CListadoAlumnos();
            this.docentes = new CListadoDocente();
            this.comision = new CListaComision();
        }
        //REGISTROS
        public bool registrar(string nom, string ape, string dni, uint leg, string tit)//Registrar alumno
        {
            return this.alumnos.registrar(nom, ape, dni, leg, tit);
        }
        public bool registrar(string nom, string ape, string dni, uint leg, ECategoria cat)//Registrar docente
        {
            return this.docentes.registrar(nom, ape, dni, leg, cat);
        }
        public bool registrar(string cod, string tur)//Registrar comision
        {
            return this.comision.registrar(cod, tur);
        }
        //ASIGNACIONES Y ELIMINACION COMISION
        public bool asignarDocente(string cod, uint leg)//Asignar docente
        {
            CDocente doc = this.docentes.buscar(leg);
            if(doc != null)
            {
                return this.comision.asignarDocente(doc, cod);
            }
            return false;
        }
        public bool eliminarDocenteComision(string cod, uint leg)//Remover docente de una comision
        {
            return this.comision.removerDocente(cod, leg);
        }
        public bool asignarAlumno(string cod, uint leg)//Asignar alumno
        {
            CAlumno alum = this.alumnos.buscar(leg);
            if (alum != null)
            {
                return this.comision.asignarAlumnos(alum, cod);
            }
            return false;
        }
        public bool eliminarAlumnoComision(string cod, uint leg)//Remover docente de una comision
        {
            return this.comision.removerAlumno(cod, leg);
        }
        //ELIMINACIONES UNIVERSIDAD
        public bool eliminarDocenteUniversidad(uint leg)//Remover docente de la universidad
        {
            return this.docentes.remover(leg);
        }
        public bool eliminarAlumnoUniversidad(uint leg)//Remover alumno de la universidad
        {
            return this.alumnos.remover(leg);
        }
        //LISTAS
        public string darListaAlumnos()//Lista Alumnos
        {
            return this.alumnos.darLista();
        }
        public string darListaDocentes()//Lista Alumnos
        {
            return this.docentes.darLista();
        }
        public string darListaComision()//Lista comision
        {
            return this.comision.darLista();
        }
        //BUSQUEDA ALUMNO O DOCENTE
        public string Busqueda(uint leg)
        {
            CAlumno auxA = this.alumnos.buscar(leg);

            if(auxA != null)
            {
                return this.alumnos.darDatos(leg);
            }
            else
            {
                CDocente auxD = this.docentes.buscar(leg);
                if(auxD != null)
                {
                    return this.docentes.darDatos(leg);
                }
            }
            return "NO EXISTE ALUMNO O DOCENTE CON ESE LEGAJO";
        }
    }
}
