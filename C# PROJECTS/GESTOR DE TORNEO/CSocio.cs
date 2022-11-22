using System;
using System.Collections;

namespace _11_Ejercicio_Parcial_2
{
    public class CSocio
    {
        private string dni;
        private string apellido;
        private string nombre;
        private byte registros;

        public CSocio(string dni, string ape, string nom)
        {
            this.dni = dni;
            this.apellido = ape;
            this.nombre = nom;
            this.registros = 0;
        }
        public CSocio() : this("SIN ASIGNAR", "SIN ASIGNAR","SIN ASIGNAR") { }
        public void SetDNI(string DNI)
        {
            this.dni = DNI;
        }
        public void SetApellido(string ape)
        {
            this.apellido = ape;
        }
        public void SetNombre(string nom)
        {
            this.nombre = nom;
        }
        public string GetDNI()
        {
            return this.dni;
        }
        public string GetApellido()
        {
            return this.apellido;
        }
        public string GetNombre()
        {
            return this.nombre;
        } 
        public byte GetRegistros()
        {
            return this.registros;
        }
        public void Registrado()
        {
            this.registros++;
        }
        public void Desregistrar()
        {
            this.registros--;
        }
        public virtual string darDatos()
        {
            string data;
            return data = "\nDNI: " + this.dni + " APELLIDO: " + this.apellido + " NOMBRE: " + this.nombre + "\n";
        }
    }
}
