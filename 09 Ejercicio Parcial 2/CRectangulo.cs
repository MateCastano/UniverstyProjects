using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Ejercicio_Parcial_2
{
    public class CRectangulo : CFigura
    {
        private float Altura;
        private float Base;
        public CRectangulo(float alt, float bas) : base("RECTANGULO", 4)
        {
            this.Altura = alt;
            this.Base = bas;
        }
        public CRectangulo() : this(1, 1) { }
        public void SetAltura(float alt)
        {
            this.Altura = alt;
        }
        public void SetBase(float bas)
        {
            this.Base = bas;
        }
        public float GetAltura()
        {
            return this.Altura;
        }
        public float GetBase()
        {
            return this.Base;
        }
        public override float DarPerimetro()
        {
            return (float)((this.Base * this.Altura) / 2);
        }
        public override string DarDatos()
        {
            return base.DarDatos() + " ALTURA: " + this.Altura.ToString() + " BASE: " + this.Base.ToString();
        }
    }
}
