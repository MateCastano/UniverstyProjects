using System;
using System.Collections;
namespace _11_Ejercicio_Parcial_2
{
    public class CListaEquipo
    {
        ArrayList listado;
        public CListaEquipo()
        {
            listado = new ArrayList();
        }
        public CEquipo buscar(string cod)
        {
            foreach (CEquipo aux in this.listado)
            {
                if (aux.GetCodigo() == cod) return aux;
            }
            return null;
        }
        public bool registrarEquipo(string cod, string nom)
        {
            if(this.buscar(cod) == null)
            {
                this.listado.Add(new CEquipo(cod, nom));
                return true;
            }
            return false;
        }
        public bool asignar(CSocio soc, string dni, string cod)
        {
            CEquipo auxEq = this.buscar(cod);
            if (auxEq != null)
            {
                return auxEq.asignar(soc);
            }
            return false;
        }
        public bool remover(string dni, string cod)
        {
            CEquipo aux = this.buscar(cod);
            if(aux != null)
            {
                return aux.remover(dni);
            }
            return false;
        }
        public string darEquipos()
        {
            if(this.listado.Count != 0)
            {
                string datos = "";
                foreach (CEquipo aux in this.listado) datos += aux.darDatos() + "\n";
                return datos;
            }
            return "NO SE REGISTRARON EQUIPOS";
        }
        public string buscarEquipo(string cod)
        {
            CEquipo aux = this.buscar(cod);
            if(aux != null)
            {
                return aux.darDatos();
            }
            return "NO EXISTE ESE EQUIPO";
        }
    }
}
