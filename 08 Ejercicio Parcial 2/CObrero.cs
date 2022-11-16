namespace Constructora
{
    public class CObrero:CEmpleado
    {
        private EEspecialidad especialidad;

        public CObrero(string doc, string ape, string nom, EEspecialidad esp): base (doc,ape,nom)
        {
            this.especialidad = esp;
        }
        public override string darDatos()
        {
            return base.darDatos() + " - " + this.especialidad + " - [Obrero]";
        }
        
    }
}
