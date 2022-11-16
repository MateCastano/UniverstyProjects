namespace Constructora
{
    public class CCapataz:CEmpleado
    {
        private uint matrícula;

        public CCapataz(string doc, string ape, string nom, uint mat): base (doc,ape,nom)
        {
            this.matrícula=mat;
        }
        public override string darDatos()
        {
            return base.darDatos() + " - Matrícula: " + this.matrícula.ToString()+ " - [Capataz]";
        }
        
    }
}
