using System;
using System.Collections;
namespace _11_Ejercicio_Parcial_2
{
    public class CEntrenador:CSocio
    {
        private string telefono;
        public CEntrenador(string dni, string ape, string nom, string tel):base(dni, ape, nom)
        {
            this.telefono = tel;
        }
        public override string darDatos()
        {
            return base.darDatos() + " TELEFONO: " + this.telefono + "\n";
        }
    }
}
