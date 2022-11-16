using System;
namespace Constructora
{
    public class CInterfaz
    {
        static CInterfaz()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static string DarOpcion()
        {
            Console.Clear();
            Console.WriteLine("***********************************************");
            Console.WriteLine("*     Sistema de Gestión de Constructora      *");
            Console.WriteLine("***********************************************");
            Console.WriteLine("\n[Q] Registrar un obrero.");
            Console.WriteLine("\n[W] Registrar un capataz.");
            Console.WriteLine("\n[E] Registrar una obra.");
            Console.WriteLine("\n[R] Asignar un obrero a una obra.");
            Console.WriteLine("\n[T] Asignar un capataz a una obra.");
            Console.WriteLine("\n[Y] Listar las obras de la constructora.");
            Console.WriteLine("\n[U] Listar los obreros de una obra.");
            Console.WriteLine("\n[I] Remover un empleado de una obra.");
            Console.WriteLine("\n[O] Remover un empleado de la constructora.");
            Console.WriteLine("\n[P] Listar los obreros de la consultora.");
            Console.WriteLine("\n[S] Salir de la aplicación.");
            Console.WriteLine("\n**********************************************");
            return CInterfaz.PedirDato("opción elegida");
        }
        public static string PedirDato(string nombDato)
        {
            Console.Write("[?] Ingrese " + nombDato + ": ");
            string ingreso = Console.ReadLine();
            while (ingreso == "")
            {
                Console.Write("[!] " + nombDato + "es de ingreso OBLIGATORIO:");
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