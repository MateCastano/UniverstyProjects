using System;
using System.Collections;

namespace _11_Ejercicio_Parcial_2
{
    public class CTorneo
    {
        private CListaSocio socios;
        private CListaEquipo equipos;
        public CTorneo()
        {
            socios = new CListaSocio();
            equipos = new CListaEquipo();
        }
        //REGISTRAR EQUIPO
        public bool registrarEquipo(string cod, string nom)
        {
            return this.equipos.registrarEquipo(cod, nom);
        }
        //REGISTRAR JUGADOR
        public bool registrarJugador(string dni, string ape, string nom, EPosicion pos)
        {
            return this.socios.registrarJugador(dni, ape, nom, pos);
        }
        //REGISTRAR ENTRENADOR
        public bool registrarEntrenador(string dni, string ape, string nom, string tel)
        {
            return this.socios.registrarEntrenador(dni, ape, nom, tel);
        }
        //ASIGNACION
        public bool asignar(string dni, string cod)
        {
            CSocio jug = this.socios.buscar(dni);
            if (jug != null)
            {
                return equipos.asignar(jug,dni, cod);
            }
            return false;
        }
        //REMOVER
        public bool remover(string dni, string cod)
        {
            CEquipo equ = this.equipos.buscar(cod);
            if (equ != null)
            {
                return equipos.remover(dni, cod);
            }
            return false;
        }
        public bool remover(string dni)
        {
            CSocio jug = this.socios.buscar(dni);
            if (jug != null)
            {
                return socios.Remover(dni);
            }
            return false;
        }
        //LISTAS
        public string listarEquipos()
        {
            return this.equipos.darEquipos();
        }
        public string listarSocios()
        {
            return this.socios.darLista();
        }
        public string buscarEquipo(string cod)
        {
            return this.equipos.buscarEquipo(cod);
        }
    }
}
