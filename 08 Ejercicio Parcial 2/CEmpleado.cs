using System;
namespace Constructora
{
    public class CEmpleado:IComparable
    {
        private string dni;
        private string apellido;
        private string nombre;
        private int ocupaciones;

        public CEmpleado():this("Sin Asignar", "Sin Asignar", "Sin Asignar")
        { }
        public CEmpleado(string doc, string ape, string nom)
        {
            this.dni = doc;
            this.apellido = ape;
            this.nombre = nom;
            this.ocupaciones = 0;
        }
        public int CompareTo(object empleado)
        {

            return this.dni.CompareTo(((CEmpleado)empleado).getDNI());
        }

        public virtual string darDatos()
        {
            string ocu;
            if (this.ocupaciones ==0) ocu = "Desocupado";
            else ocu = "Ocupado";
            return "DNI: " + this.dni + " - " + this.nombre+" "+this.apellido+" - ["+ocu+" "+this.ocupaciones.ToString()+"]";
        }

        public string getDNI()
        {
            return this.dni;
        }
        public void setDNI(string doc)
        {
            this.dni = doc;
        }
        public string getNombre()
        {
            return this.nombre;
        }
        public void setNombre(string nom)
        {
            this.nombre = nom;
        }
        public string getApellido()
        {
            return this.apellido;
        }
        public void setApellido(string ape)
        {
            this.apellido=ape;
        }
        public string DNI
        {
            set { this.dni = value; }
            get { return this.dni; }
        }
        public void ocupar()
        {
            this.ocupaciones++;
        }
        public void desocupar()
        {
            this.ocupaciones--;
        }
    }
}
