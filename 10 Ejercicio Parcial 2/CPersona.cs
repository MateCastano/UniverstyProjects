using System;

namespace _10_Ejercicio_Parcial_2
{
    public class CPersona
    {
        private string dni;
        private string apellido;
        private string nombre;
        private uint legajo;
        public CPersona(string nom, string ape, string dni, uint leg)
        {
            this.dni = dni;
            this.apellido = ape;
            this.nombre = nom;
            this.legajo = leg;
        }
        public CPersona() : this("SIN ASIGNAR", "SIN ASIGNAR", "SIN ASIGNAR",0) { }
        public void SetDni(string dni)
        {
            this.dni = dni;
        }
        public void SetApellido(string ape)
        {
            this.apellido = ape;
        }
        public void SetNombre(string nom)
        {
            this.nombre = nom;
        }
        public void SetLegajo(uint leg)
        {
            this.legajo = leg ;
        }
        public string GetDni()
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
        public uint GetLegajo()
        {
            return this.legajo;
        }
        public virtual string  DarDatos()
        {
            string datos = "";
            return datos += "\nNOMBRE: " + this.nombre + " APELLIDO: " + this.apellido + " DNI:" + this.dni + " LEGAJO: " + this.legajo + "\n";
        }
    }
}
