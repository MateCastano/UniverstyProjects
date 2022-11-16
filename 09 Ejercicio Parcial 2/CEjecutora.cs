using System;

/*Actividad práctica:
Implementar en una solución de consola de C#.Net:
1) CFigura, CCírculo, CTriángulo y CRectángulo.
2) Hacer que una colección de cualquier figura geométrica se pueda ordenar, primero, por cantidad de lados y luego, 
   por perímetro (ambos de menor a mayor).
3) Hacer que DarDatos() informe también el perímetro.
4) Realice un programa que permita registrar una cantidad desconocida de figuras geométricas, que informe la de mayor 
   perímetro y que liste los datos completos de todas, ordenados según el criterio definido.
5) Debe evitar que CFigura sea instanciada.
6) Reutilice código.
7) Aplique las técnicas estudiadas.*/

namespace _09_Ejercicio_Parcial_2
{
    public class CEjecutora
    {
        public static void Main(string[] args)
        {
            byte opcion;
            CListadoFiguras lista = new CListadoFiguras();
            do
            {
                Console.Write("\nCIRCULO [1]");
                Console.Write("\nTRIANGULO [2]");
                Console.Write("\nRECTANGULO [3]");
                Console.Write("\nSALIR [0]");
                Console.Write("\n\nQUE FIGURA DESEA REGISTRAR? (ELIJA UNA OPCION):");
                opcion = byte.Parse(Console.ReadLine());

                switch(opcion)
                {
                    case 1:
                        float radio;
                        Console.Write("RADIO DEL CIRCULO: ");
                        radio = float.Parse(Console.ReadLine());
                        CCirculo circulo = new CCirculo(radio);
                        lista.registrar(circulo);
                        break;
                    case 2:
                        float Base;
                        float altura;
                        Console.Write("ALTURA DEL TRIANGULO: ");
                        altura = float.Parse(Console.ReadLine());
                        Console.Write("BASE DEL TRIANGULO: ");
                        Base = float.Parse(Console.ReadLine());
                        CTriangulo triangulo = new CTriangulo(altura, Base);
                        lista.registrar(triangulo);
                        break;
                    case 3:
                        float BaseR;
                        float alturaR;
                        Console.Write("ALTURA DEL RECTANGULO: ");
                        alturaR = float.Parse(Console.ReadLine());
                        Console.Write("BASE DEL RECTANGULO: ");
                        BaseR = float.Parse(Console.ReadLine());
                        CRectangulo rectangulo = new CRectangulo(alturaR, BaseR);
                        lista.registrar(rectangulo);
                        break;
                }
            } while (opcion != 0);

            Console.Write(lista.darDatos());
        }
    }
}
