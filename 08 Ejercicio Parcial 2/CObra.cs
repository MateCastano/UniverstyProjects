using System.Collections;

namespace Constructora
{
    public class CObra
    {
        private string código;
        private CDirección dirección;
        private CListadoEmpleados obreros;
        private CCapataz capataz;

        public CObra(string cód, string cal, uint núm, string loc, string pro)
        {
            this.código = cód;
            this.dirección = new CDirección(cal, núm, loc, pro);
            this.obreros = new CListadoEmpleados();
        }

        public string getCódigo()
        {
            return this.código;
        }
        public string darDatos()
        {
            string cap = "Capataz sin designar";
            if (this.capataz != null) cap = this.capataz.darDatos();
            return "Obra código: " + this.código + " - " + this.dirección.darDatos()+ " - "+cap;
        }
        public string darObreros()
        {
            return this.obreros.darDatos();
        }
        public bool asignar(CObrero obrero)
        {
            return this.obreros.registrar(obrero);
        }
        public bool asignar (CEmpleado emp)
        {
            if (emp is CCapataz)
            {
                this.capataz = (CCapataz) emp;
                return true;
            }
            else
            {
                if (emp is CObrero)
                {
                    return this.obreros.registrar(emp);
                }
            }
            return false;
        }
        public bool remover (string doc)
        {
            if (this.capataz!= null && this.capataz.DNI == doc)
            {
                this.capataz.desocupar();
                this.capataz = null;
                return true;
            }
            return this.obreros.eliminar(doc);
        }

    }
}
