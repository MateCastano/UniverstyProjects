using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Ejercicio_Parcial_2
{
    public class CCirculo:CFigura
    {
        private float radio;
        public CCirculo(float rad):base("CIRCULO", 1)
        {
            this.radio = rad;
        }
        public CCirculo() : this(1) { }
        public void SetRadio(float rad)
        {
            this.radio = rad;
        }
        public float GetRadio()
        {
            return this.radio;
        }
        public override float DarPerimetro()
        {
            return (float)(this.radio * 2 * System.Math.PI);
        }
        public override string DarDatos()
        {
            return base.DarDatos() + " RADIO: " + this.radio.ToString();
        }
    }
}
