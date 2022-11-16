using System;
using System.Collections;
namespace Aterrizar
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
            Console.WriteLine("*     Sistema de Gestión de Aterrizar     *");
            Console.WriteLine("***********************************************");
            Console.WriteLine("\n[1] Registrar un viaje.");
            Console.WriteLine("\n[2] Mostrar catalogo.");
            Console.WriteLine("\n[3] Remover un viaje del catalogo.");
            Console.WriteLine("\n[4] Comparar dos viajes del catalogo.");
            Console.WriteLine("\n[5] Borrar todo el catalogo.");
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