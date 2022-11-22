using System;
using System.Collections;

namespace _11_Ejercicio_Parcial_2
{
    public class CEquipo
    {
        private string codigo;
        private string nombre;
        private CListaSocio listado;
        private CEntrenador entrenador;
        public CEquipo(string cod, string nom)
        {
            this.codigo = cod;
            this.nombre = nom;
            this.listado = new CListaSocio();
        }
        public CEquipo() : this("SIN ASIGNAR", "SIN ASIGNAR") { }
        public void SetCodigo(string cod)
        {
            this.codigo = cod;
        }
        public void SetNombre(string nom)
        {
            this.nombre = nom;
        }
        public string GetCodigo()
        {
            return this.codigo;
        }
        public string GetNombre()
        {
            return this.nombre;
        }
        public bool asignar(CSocio soc)
        {
            if(soc is CJugador && soc.GetRegistros() == 0)
            {
                this.listado.registrarJugador((CJugador)soc);
                return true;
            }
            if (soc is CEntrenador && this.entrenador == null)
            {
                this.entrenador = (CEntrenador)soc;
                return true;
            }
            return false;
        }
        public bool remover(string dni)
        {
            if(this.entrenador.GetDNI() == dni && this.entrenador != null)
            {
                this.entrenador.Desregistrar();
                this.entrenador =  null;
                return true;
            }
            return this.listado.Remover(dni);
        }

        public string darDatos()
        {
            string data = "";
            return data = "\nNombre: " + this.nombre + " Codigo: " + this.codigo + " JUGADORES: " + this.listado.darLista() + " ENTRENADOR: "+ this.entrenador.GetApellido()+ " " + this.entrenador.GetNombre() + "\n";
        }
    }
}
