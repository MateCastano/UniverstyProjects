using System;
using System.Collections;
namespace Constructora
{
    public class CControladora
    {
        public static void Main()
        {
            char opcion;
            CConstructora constructora = new CConstructora();
            do
            {
                char.TryParse(CInterfaz.DarOpcion().ToUpper(), out opcion);
                //.ToUpper() Convierte la cadena a MAYÚSCULAS.
                string doc, nom, ape, cód;
                switch (opcion)
                {
                    case 'Q': //Registrar un obrero.
                        doc = CInterfaz.PedirDato("DNI");
                        nom = CInterfaz.PedirDato("Nombre");
                        ape = CInterfaz.PedirDato("Apellido");
                        string esp=  CInterfaz.PedirDato("\n1-Albañil\n2-Pintor\n3-Plomero\n4-Herrero\n5-Electricista");
                        EEspecialidad espec=EEspecialidad.Albañil;
                        switch (esp)
                        {
                            case "1":
                                espec = EEspecialidad.Albañil;
                                break;
                            case "2":
                                espec = EEspecialidad.Pintor;
                                break;
                            case "3":
                                espec = EEspecialidad.Plomero;
                                break;
                            case "4":
                                espec = EEspecialidad.Herrero;
                                break;
                            case "5":
                                espec = EEspecialidad.Electricista;
                                break;
                        }
                        if (constructora.registrar(doc, ape, nom, espec)==true)
                        {
                            CInterfaz.MostrarInfo("Obrero registrado");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("Operación fallida");
                        }
                        break;
                    case 'W': //Registrar un capataz.
                        doc = CInterfaz.PedirDato("DNI");
                        nom = CInterfaz.PedirDato("Nombre");
                        ape = CInterfaz.PedirDato("Apellido");
                        uint mat = uint.Parse(CInterfaz.PedirDato("Matrícula"));
                        if (constructora.registrar(doc, ape, nom,mat)==true)
                        {
                            CInterfaz.MostrarInfo("Capataz registrado");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("Operación fallida");
                        }
                        break;
                    case 'E'://Registrar una obra.
                        cód = CInterfaz.PedirDato("Código de obra");
                        string cal = CInterfaz.PedirDato("Calle");
                        uint núm = uint.Parse(CInterfaz.PedirDato("Número"));
                        string loc = CInterfaz.PedirDato("Localidad");
                        string pro = CInterfaz.PedirDato("Provincia");

                        if (constructora.registrar(cód,cal,núm,loc,pro) == true)
                        {
                            CInterfaz.MostrarInfo("Obra registrada");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("Operación fallida");
                        }
                        break;
                    case 'R'://Asociar obrero a obra.
                        cód = CInterfaz.PedirDato("Código de obra");
                        doc = CInterfaz.PedirDato("DNI obrero");

                        if (constructora.asignar(doc,cód) == true)
                        {
                            CInterfaz.MostrarInfo("Obrero asignado");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("Operación fallida");
                        }
                        break;
                    case 'T'://Asociar capataz a obra.
                        cód = CInterfaz.PedirDato("Código de obra");
                        doc = CInterfaz.PedirDato("DNI capataz");

                        if (constructora.asignar(doc, cód) == true)
                        {
                            CInterfaz.MostrarInfo("Capataz asignado");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("Operación fallida");
                        }
                        break;
                    case 'Y'://Listar obras de la constructora.
                        CInterfaz.MostrarInfo(constructora.listarObras());
                        break;
                    case 'U'://Listar los obreros de una obra.
                        cód = CInterfaz.PedirDato("Código de obra");
                        CInterfaz.MostrarInfo(constructora.listarObrerosPorObra(cód));
                        break;
                    case 'I'://Remover un empleado de una obra.
                        cód = CInterfaz.PedirDato("Código de obra");
                        doc = CInterfaz.PedirDato("DNI empleado");

                        if (constructora.remover(doc, cód) == true)
                        {
                            CInterfaz.MostrarInfo("Empleado removido");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("Operación fallida");
                        }
                        break;
                    case 'O'://Remover un empleado de la constructora.
                        doc = CInterfaz.PedirDato("DNI empleado");

                        if (constructora.remover(doc) == true)
                        {
                            CInterfaz.MostrarInfo("Empleado removido");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("Operación fallida");
                        }
                        break;
                    case 'P'://Listar los obreros de la constructora.
                        CInterfaz.MostrarInfo(constructora.listarEmpleados());
                        break;
                }
            } while (opcion != 'S');
        }
    }
}

