using System;
using System.Collections;

namespace _11_Ejercicio_Parcial_2
{
    public class CJugador:CSocio
    {
        private EPosicion posicion;
        public CJugador(string dni, string ape, string nom, EPosicion pos):base(dni, ape, nom)
        {
            this.posicion = pos;
        }
        public override string darDatos()
        {
            return base.darDatos() + " POSICION: " + this.posicion + "\n";
        }
    }
}
