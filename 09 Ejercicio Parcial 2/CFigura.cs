using System;

namespace _09_Ejercicio_Parcial_2
{
    public class CFigura:IComparable
    {
        private string nombre;
        private byte CantLados;
        public CFigura(string nomb, byte canL)
        {
            this.nombre = nomb;
            this.CantLados = canL;
        }
        public CFigura() : this("POLIMEDRO", 0)
        {}
        public void SetNombre(string nomb)
        {
            this.nombre = nomb;
        }
        public void SetCantLados(byte canL)
        {
            this.CantLados = canL;
        }
        public string GetNombre()
        {
            return this.nombre;
        }
        public byte GetCantLados()
        {
            return this.CantLados;
        }
        public int CompareTo(object figura)
        {
            return (int)(this.CantLados.CompareTo(((CFigura)figura).GetCantLados()));
        }
        public virtual float DarPerimetro()
        {
            return 0.0f;
        }
        public virtual string DarDatos()
        {
            return this.nombre + " LADOS: " + this.CantLados.ToString();
        }
    }
}
