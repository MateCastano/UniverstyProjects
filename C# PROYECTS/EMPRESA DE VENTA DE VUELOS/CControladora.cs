using System;
using System.Collections;

namespace Aterrizar
{
    public class CControladora
    {
        public static void Main()
        {
            char opcion;
            CAterrizar aterrizar = new CAterrizar();
            do
            {
                char.TryParse(CInterfaz.DarOpcion().ToUpper(), out opcion);
                string cod, cod2, ori, dest, tipoVuelo;
                float pre, imp;
                byte cou;
                switch (opcion)
                {
                    case '1'://REGISTRAR VIAJE
                        if(CAereo.GetImpuesto() == 0)
                        {
                            imp = float.Parse(CInterfaz.PedirDato("impuesto de viaje aereo"));
                            CAereo.SetImpuesto(imp);
                        }
                        cod = CInterfaz.PedirDato("codigo");
                        ori = CInterfaz.PedirDato("origen");
                        dest = CInterfaz.PedirDato("destino");
                        tipoVuelo = CInterfaz.PedirDato("tipo de vuelo\n1-Cabotaje\n2-Internacional");
                        ETipoVuelo TV = ETipoVuelo.Cabotaje;
                        switch(tipoVuelo)
                        {
                            case "1":
                                TV = ETipoVuelo.Cabotaje;
                                break;
                            case "2":
                                TV = ETipoVuelo.Internacional;
                                break;
                        }
                        pre = float.Parse(CInterfaz.PedirDato("precio inicial"));
                        cou = byte.Parse(CInterfaz.PedirDato("coutas (1/3/6/12)"));
                        if (aterrizar.registrarViaje(cod, ori, dest, pre, TV, cou))
                        {
                            CInterfaz.MostrarInfo("VIAJE REGISTRADO");
                        }    
                        else
                        {
                            CInterfaz.MostrarInfo("VIAJE NO REGISTRADO");
                        }
                        break;
                    case '2'://MOSTRAR CATALOGO
                        CInterfaz.MostrarInfo(aterrizar.mostarCatalogo());
                        break;
                    case '3'://REMOVER VIAJE
                        cod = CInterfaz.PedirDato("codigo");
                        if (aterrizar.removerViaje(cod) == true)
                        {
                            CInterfaz.MostrarInfo("VIAJE ELIMINADO");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("VIAJE NO ELIMINADO");
                        }
                        break;
                    case '4'://COMPARAR VIAJES
                        cod = CInterfaz.PedirDato("codigo del primer viaje: ");
                        cod2 = CInterfaz.PedirDato("codigo del segundo viaje: ");
                        CInterfaz.MostrarInfo(aterrizar.compararViajes(cod, cod2));
                        break;
                    case '5'://REMOVER CATALOGO
                        if(aterrizar.removerCatalogo() == true)
                        {
                            CInterfaz.MostrarInfo("CATALOGO ELIMINADO");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("CATALOGO NO ELIMINADO");
                        }
                        break;
                }
            } while (opcion != '0');
        }
    }
}