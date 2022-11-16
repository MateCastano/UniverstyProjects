using System;
using System.Collections;
namespace Constructora
{
    public class CListadoObras
    {
        //Variables Miembro
        private ArrayList listado;
        //Constructor
        public CListadoObras()
        {
            this.listado = new ArrayList();
        }
        public CObra buscar(string cód)
        {
            foreach (CObra aux in this.listado)
            {
                if (aux.getCódigo() == cód) return aux;
            }
            return null;
        }
        public bool registrar(string cód, string cal, uint núm, string loc, string pro)
        {
            if (this.buscar(cód) == null)
            {
                this.listado.Add(new CObra(cód, cal, núm, loc, pro));
                return true;
            }
            return false;
        }
        public string darDatos(string cód)
        {
            CObra aux = this.buscar(cód);
            if (aux != null) return aux.darDatos();
            return "Obra Inexistente";
        }
        public string darDatos()
        {

            if (this.listado.Count != 0)
            {
                String datos = "";
                foreach (CObra aux in this.listado) datos += aux.darDatos() + "\n";
                return datos;
            }
            return "No se registraron obras válidas";
        }
        public string darObreros(string cód)
        {
            CObra obr = this.buscar(cód);
            if(obr!=null)
            {
                return obr.darObreros();
            }
            return "La obra no tiene obreros asignados";
        }
        public bool eliminar(string cód)
        {
            CObra aux = this.buscar(cód);
            if (aux != null)
            {
                this.listado.Remove(aux);
                return true;
            }
            return false;
        }
        
        public bool asignar(CEmpleado emp, string cód)
        {
            CObra obra = this.buscar(cód);
            if (obra!=null)
            {
               return obra.asignar(emp);
            }
            return false;
        }
        public bool remover(string doc, string cód)
        {
            CObra obr = this.buscar(cód);
            if(obr!=null)
            {
                return obr.remover(doc);
            }
            return false;
        }
        public bool remover(string doc)
        {
            bool band = false;
            foreach(CObra obr in this.listado)
            {
                if (obr.remover(doc) == true) band = true;
            }
            return band;
        }
    }
}

