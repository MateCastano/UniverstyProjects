using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Ejercicio_Parcial_2
{
    public class CTriangulo :CFigura
    {
        private float Altura;
        private float Base;
        public CTriangulo(float alt, float bas) : base("TRIANGULO", 3)
        {
            this.Altura = alt;
            this.Base = bas;
        }
        public CTriangulo() : this(1,1) { }
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

