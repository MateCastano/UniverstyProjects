using System;

namespace Aterrizar
{
    public class CViaje : IComparable
    {
        private string codigo;
        private string origen;
        private string destino;
        private float precio;
        private byte cuotas;
        public CViaje(string cod, string ori, string dest, float pre, byte cuo)
        {
            this.codigo = cod;
            this.origen = ori;
            this.destino = dest;
            this.precio = pre;
            this.cuotas = cuo;
        }
        public CViaje() : this("SIN ASIGNAR", "SIN ASIGNAR", "SIN ASIGNAR", 0, 0) { }
        public string GetCodigo()
        {
            return this.codigo;
        }
        public string GetOrigen()
        {
            return this.origen;
        }
        public string GetDestino()
        {
            return this.destino;
        }
        public float Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }
        public float DarPrecio(byte cou)
        {
            float precioFinal = this.precio;

            if (cou == 3)
            {
                precioFinal = this.precio + ((this.precio * 10) / 100);
                return precioFinal;
            }
            else if (cou == 6)
            {
                precioFinal = this.precio + ((this.precio * 20) / 100);
                return precioFinal;
            }
            else if (cou == 12)
            {
                precioFinal = this.precio + ((this.precio * 40) / 100);
                return precioFinal;
            }

            return precioFinal;
        }
        public int CompareTo(object obj)
        {
            if(obj is CViaje)
            {
                if (this.GetOrigen() == (((CViaje)obj).GetOrigen()) && this.GetDestino() == (((CViaje)obj).GetDestino()))
                {
                    return 0;
                }
                if (this.GetOrigen() == (((CViaje)obj).GetOrigen()) && this.GetDestino() != (((CViaje)obj).GetDestino()))
                {
                    return 1;
                }
                if (this.GetOrigen() != (((CViaje)obj).GetOrigen()) && this.GetDestino() != (((CViaje)obj).GetDestino()))
                {
                    return 2;
                }
                return 3;
            }
            return 3;
        }
        public virtual string DarDatos()
        {
            string data = "";
            return data += "\nCODIGO: " + this.codigo + " ORIGEN: " + this.origen + " DESTINO: " + this.destino + " PRECIO ORIGINAL:" + this.precio.ToString() + " COUTAS:" + this.cuotas.ToString() +
                            " PRECIO CON COUTAS:" + this.DarPrecio(this.cuotas).ToString() + "\n";
        }
    }
}
