using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Ejercicio_Parcial_2
{
    public class CDocente:CPersona
    {
        private ECategoria Categoria;
        public CDocente(string nom, string ape, string dni, uint leg, ECategoria cat):base(nom, ape, dni, leg)
        {
            this.Categoria = cat;
        }
        public override string DarDatos()
        {
            return base.DarDatos() + " Docente Categoria: " + this.Categoria;
        }
    }
}
