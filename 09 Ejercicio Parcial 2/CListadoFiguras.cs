using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Ejercicio_Parcial_2
{
    public class CListadoFiguras
    {
        private ArrayList Listado;
        public CListadoFiguras()
        {
            this.Listado = new ArrayList();
        }
        public void registrar(CFigura fig)
        {
            this.Listado.Add(fig);
            this.Listado.Sort();
        }
        public string mayorPerimetro()
        {
            string mayorP = "", nombFig = "";
            float mayorPerimetro = 0;

            for(int i = 0; i < Listado.Count; i ++)
            {
                CFigura fig = (CFigura)Listado[i];

                if (mayorPerimetro < fig.DarPerimetro())
                {
                    mayorPerimetro = fig.DarPerimetro();
                    nombFig = fig.GetNombre();
                }
            }

            return mayorP += "LA FIGURA DE MAYOR PERIMETRO ES: " + nombFig + " Y SU PERIMETRO ES DE: " + mayorPerimetro;
        }
        public string darDatos()
        {
            string datos = "";

            datos += mayorPerimetro() + "\n";
            foreach (CFigura aux in this.Listado) datos += aux.DarDatos() + " PERIMETRO: " + aux.DarPerimetro() + "\n";

            return datos;
        }
    }
}
