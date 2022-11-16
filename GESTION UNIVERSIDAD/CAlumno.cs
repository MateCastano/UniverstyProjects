using System;
using System.Collections;

namespace _10_Ejercicio_Parcial_2
{
    public class CAlumno:CPersona
    {
        private string titulo;
        public CAlumno(string nom, string ape, string dni, uint leg, string tit):base(nom, ape, dni, leg)
        {
            this.titulo = tit;
        }
        public override string DarDatos()
        {
            return base.DarDatos() + " ALUMNO TITULO: " + this.titulo;
        }
    }
}
