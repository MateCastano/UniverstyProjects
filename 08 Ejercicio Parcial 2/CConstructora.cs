using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora
{
    class CConstructora
    {

        private CListadoEmpleados empleados;
        private CListadoObras obras;

        public CConstructora()
        {
            this.empleados = new CListadoEmpleados();
            this.obras = new CListadoObras();
        }

        public bool registrar(string doc, string ape, string nom, EEspecialidad esp)//Registra Obrero.
        {
            return this.empleados.registrar(doc, ape, nom, esp);
        }
        public bool registrar(string doc, string ape, string nom, uint mat)//Registra Capataz.
        {
            return this.empleados.registrar(doc, ape, nom, mat);
        }
        public bool registrar(string cód, string cal, uint núm, string loc, string pro)//Registra Obra.
        {
            return this.obras.registrar(cód, cal, núm, loc, pro);
        }
        public bool asignar(string doc, string cód)//Asigna empleado (obrero o capataz) a obra.
        {
            CEmpleado emp = this.empleados.buscar(doc);
            if (emp !=null)
            {
                if (this.obras.asignar(emp, cód) == true)
                {
                    emp.ocupar();//ver
                    return true;
                }
            }
            return false;
        }
        public string listarObras()//Lista las obras y su capataz.
        {
            return this.obras.darDatos();
        }
        public string listarObrerosPorObra(string cód)
        {
            return this.obras.darObreros(cód);
        }
        public bool remover(string doc,string cód)//Remueve un obrero de una obra.
        {
            return this.obras.remover(doc, cód);
        }
        public bool remover(string doc)//Remueve un empleado de la constructora.
        {
            this.obras.remover(doc);
            return this.empleados.eliminar(doc);
        }
        public string listarEmpleados()//Lista los empleados de la constructora.
        {
            return this.empleados.darDatos();
        }
    }
}
