using System;
using System.Collections;

namespace _10_Ejercicio_Parcial_2
{
    public class CControladora
    {
        public static void Main()
        {
            char opcion;
            CUniversidad universidad = new CUniversidad();
            do
            {
                char.TryParse(CInterfaz.DarOpcion().ToUpper(), out opcion);
                string nom, ape, dni, tit, cod, turno;
                uint leg;
                switch(opcion)
                {
                    case '1'://Resgistar docente
                        nom = CInterfaz.PedirDato("nombre");
                        ape = CInterfaz.PedirDato("apellido");
                        dni = CInterfaz.PedirDato("DNI");
                        leg = uint.Parse(CInterfaz.PedirDato("legajo"));
                        string cat = CInterfaz.PedirDato("\n1-Profesor Titular\n2-Profesor Adjunto\n3-Jefe de Trabajos Practicos\n4-Ayudante de TrabajosPracticos");
                        ECategoria cate = ECategoria.Profesor_Titular;

                        switch (cat)
                        {
                            case "1":
                                cate = ECategoria.Profesor_Titular;
                                break;
                            case "2":
                                cate = ECategoria.Profesor_Adjunto;
                                break;
                            case "3":
                                cate = ECategoria.Jefe_De_Trabajos_Practicos;
                                break;
                            case "4":
                                cate = ECategoria.Ayudante_De_Trabajos_Practicos;
                                break;
                        }

                        if (universidad.registrar(nom, ape, dni, leg, cate) == true)
                        {
                            CInterfaz.MostrarInfo("OPERACION EXITOSA");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("OPERACION FALLIDA");
                        }
                        break;
                    case '2'://Resgistar alumno
                        nom = CInterfaz.PedirDato("nombre");
                        ape = CInterfaz.PedirDato("apellido");
                        dni = CInterfaz.PedirDato("DNI");
                        leg = uint.Parse(CInterfaz.PedirDato("legajo"));
                        tit = CInterfaz.PedirDato("titulo");

                        if(universidad.registrar(nom, ape, dni, leg, tit)==true)
                        {
                            CInterfaz.MostrarInfo("OPERACION EXITOSA");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("OPERACION FALLIDA");
                        }
                        break;
                    case '3'://Resgistar comision
                        cod = CInterfaz.PedirDato("codigo");
                        turno = CInterfaz.PedirDato("turno");

                        if (universidad.registrar(cod, turno) == true)
                        {
                            CInterfaz.MostrarInfo("OPERACION EXITOSA");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("OPERACION FALLIDA");
                        }
                        break;
                    case '4'://Asignar docente a una comision
                        cod = CInterfaz.PedirDato("codigo de la comision");
                        leg = uint.Parse(CInterfaz.PedirDato("legajo del docente")); 

                        if(universidad.asignarDocente(cod, leg) == true)
                        {
                            CInterfaz.MostrarInfo("DOCENTE ASIGNADO");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("DOCENTE NO ASIGNADO");
                        }
                        break;
                    case '5'://Asignar alumno a una comision
                        cod = CInterfaz.PedirDato("codigo de la comision");
                        leg = uint.Parse(CInterfaz.PedirDato("legajo del docente"));

                        if (universidad.asignarDocente(cod, leg) == true)
                        {
                            CInterfaz.MostrarInfo("DOCENTE ASIGNADO");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("DOCENTE NO ASIGNADO");
                        }
                        break;
                    case '6'://Listar comisiones
                        CInterfaz.MostrarInfo(universidad.darListaComision());
                        break;
                    case '7'://Listar alumnos
                        CInterfaz.MostrarInfo(universidad.darListaDocentes());
                        break;
                    case '8'://Listar alumnos
                        CInterfaz.MostrarInfo(universidad.darListaAlumnos());
                        break;
                    case '9'://Remover docente de la universidad
                        leg = uint.Parse(CInterfaz.PedirDato("legajo"));
                        if(universidad.eliminarDocenteUniversidad(leg) == true)
                        {
                            CInterfaz.MostrarInfo("DOCENTE ELIMINADO");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("OPERACION FALLIDA");
                        }
                        break;
                    case 'A'://Remover alumno de la universidad
                        leg = uint.Parse(CInterfaz.PedirDato("legajo"));
                        if (universidad.eliminarAlumnoUniversidad(leg) == true)
                        {
                            CInterfaz.MostrarInfo("ALUMNO ELIMINADO");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("OPERACION FALLIDA");
                        }
                        break;
                    case 'B'://Remover docente de una comision
                        cod = CInterfaz.PedirDato("codigo de la comision");
                        leg = uint.Parse(CInterfaz.PedirDato("legajo del docente"));
                        if(universidad.eliminarDocenteComision(cod, leg) == true)
                        {
                            CInterfaz.MostrarInfo("DOCENTE ELIMINADO");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("OPERACION FALLIDA");
                        }
                        break;
                    case 'C'://Remover alumno de una comision
                        cod = CInterfaz.PedirDato("codigo de la comision");
                        leg = uint.Parse(CInterfaz.PedirDato("legajo del alumno"));
                        if (universidad.eliminarAlumnoComision(cod, leg) == true)
                        {
                            CInterfaz.MostrarInfo("ALUMNO ELIMINADO");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("OPERACION FALLIDA");
                        }
                        break;
                    case 'D'://Busqueda
                        leg = uint.Parse(CInterfaz.PedirDato("legajo"));
                        CInterfaz.MostrarInfo(universidad.Busqueda(leg));
                        break;
                }
            } while (opcion != '0');
        }
    }
}
