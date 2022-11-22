using System;

namespace _10_Ejercicio_Parcial_2
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
            Console.WriteLine("*     Sistema de Gestión de Universidad     *");
            Console.WriteLine("***********************************************");
            Console.WriteLine("\n[1] Registrar un docente.");
            Console.WriteLine("\n[2] Registrar un alumno.");
            Console.WriteLine("\n[3] Registrar una comision.");
            Console.WriteLine("\n[4] Asignar un docente a una comision.");
            Console.WriteLine("\n[5] Asignar un alumno a una comision.");
            Console.WriteLine("\n[6] Listar las comisiones de la universidad.");
            Console.WriteLine("\n[7] Listar los docentes de una universidad.");
            Console.WriteLine("\n[8] Listar las alumnos de la universidad.");
            Console.WriteLine("\n[9] Remover un docente de una universidad.");
            Console.WriteLine("\n[A] Remover un alumno de la universidad.");
            Console.WriteLine("\n[B] Remover un docente de la comision.");
            Console.WriteLine("\n[C] Remover un alumno de la comision.");
            Console.WriteLine("\n[D] Buscar alumno/docente por legajo.");
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
