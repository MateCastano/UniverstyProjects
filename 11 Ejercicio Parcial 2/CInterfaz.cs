using System;
using System.Collections;
namespace _11_Ejercicio_Parcial_2
{
    public class CInterfaz
    {
        static CInterfaz()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public static string DarOpcion()
        {
            Console.Clear();
            Console.WriteLine("***********************************************");
            Console.WriteLine("*     Sistema de Gestión de Torneo      *");
            Console.WriteLine("***********************************************");
            Console.WriteLine("\n[1] Registrar un equipo.");
            Console.WriteLine("\n[2] Registrar un jugador en su equipo.");
            Console.WriteLine("\n[3] Registrar un entrenador en su equipo.");
            Console.WriteLine("\n[4] Listar los equipos del torneo");
            Console.WriteLine("\n[5] Listar equipo con sus jugadores.");
            Console.WriteLine("\n[6] Remover un socio del torneo.");
            Console.WriteLine("\n[7] Listar todos los socios del torneo.");
            Console.WriteLine("\n[0] Salir de la aplicación.");
            Console.WriteLine("\n**********************************************");
            return CInterfaz.PedirDato("opción elegida");
        }
        public static string PedirDato(string nombDato)
        {
            Console.Write("[?] Ingrese " + nombDato + ": ");
            string ingreso = Console.ReadLine();
            while (ingreso == "")
            {
                Console.Write("[!] " + nombDato + " es de ingreso OBLIGATORIO:");
                ingreso = Console.ReadLine();
            }
            Console.Clear();
            return ingreso.Trim();

        }
        public static void MostrarInfo(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.Write("<Pulse Enter>");
            Console.ReadLine();
            Console.Clear();
        }
    }
}