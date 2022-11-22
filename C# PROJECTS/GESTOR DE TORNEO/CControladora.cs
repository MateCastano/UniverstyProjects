using System;
using System.Collections;

namespace _11_Ejercicio_Parcial_2
{
    public class CControladora
    {
        public static void Main(string[] args)
        {
            char opcion;
            CTorneo torneo = new CTorneo();
            do
            {
                opcion = char.Parse(CInterfaz.DarOpcion());
                string nom, ape, dni, cod;
                switch(opcion)
                {
                    case '1':
                        cod = CInterfaz.PedirDato("codigo");
                        nom = CInterfaz.PedirDato("nombre");
                        if(torneo.registrarEquipo(cod, nom) == true)
                        {
                            CInterfaz.MostrarInfo("EQUIPO REGISTRADO");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("EQUIPO NO REGISTRADO");
                        }
                        break;
                    case '2':
                        dni = CInterfaz.PedirDato("DNI");
                        ape = CInterfaz.PedirDato("apellido");
                        nom = CInterfaz.PedirDato("nombre");
                        string pos = CInterfaz.PedirDato("\n1-Arquero\n2-Defensor\n3-Mediocampistas\n4-Delantero");
                        cod = CInterfaz.PedirDato("codigo");
                        EPosicion posi = EPosicion.Arquero;
                        switch(pos)
                        {
                            case "1":
                                posi = EPosicion.Arquero;
                                break;
                            case "2":
                                posi = EPosicion.Defensor;
                                break;
                            case "3":
                                posi = EPosicion.Mediocampista;
                                break;
                            case "4":
                                posi = EPosicion.Delantero;
                                break;
                        }
                        if(torneo.registrarJugador(dni, ape, nom, posi) == true && torneo.asignar(dni, cod) == true)
                        {
                            CInterfaz.MostrarInfo("JUGADOR REGISTRADO");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("JUGADOR NO REGISTRADO");
                        }
                        break;
                    case '3':
                        dni = CInterfaz.PedirDato("DNI");
                        ape = CInterfaz.PedirDato("apellido");
                        nom = CInterfaz.PedirDato("nombre");
                        string tel = CInterfaz.PedirDato("telefono");
                        cod = CInterfaz.PedirDato("codigo");
                        if (torneo.registrarEntrenador(dni, ape, nom, tel) == true && torneo.asignar(dni,cod) == true)
                        {
                            CInterfaz.MostrarInfo("ENTRENADOR REGISTRADO");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("ENTRENADOR NO REGISTRADO");
                        }
                        break;
                    case '4':
                        CInterfaz.MostrarInfo(torneo.listarEquipos());
                        break;
                    case '5':
                        cod = CInterfaz.PedirDato("codigo");
                        CInterfaz.MostrarInfo(torneo.buscarEquipo(cod));
                        break;
                    case '6':
                        dni = CInterfaz.PedirDato("dni");
                        cod = CInterfaz.PedirDato("codigo");
                        if(torneo.remover(dni) == true && torneo.remover(dni,cod) == true)
                        {
                            CInterfaz.MostrarInfo("SOCIO ELIMINADO");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("SOCIO NO ELIMINADO");
                        }
                        break;
                    case '7':
                        CInterfaz.MostrarInfo(torneo.listarSocios());
                        break;
                }
            } while (opcion != '0');
        }
    }
}
