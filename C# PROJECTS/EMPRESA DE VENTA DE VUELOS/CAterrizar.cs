using System;
using System.Collections;

namespace Aterrizar
{
    public class CAterrizar
    {
        private CCatalogo catalogo;
        public CAterrizar()
        {
            this.catalogo = new CCatalogo();
        }
        public bool registrarViaje(string cod, string ori, string dest, float pre, ETipoVuelo tv, byte cou)
        {
            return catalogo.Registar(cod, ori, dest, pre, tv, cou);
        }
        public string mostarCatalogo()
        {
            return catalogo.darCatalogo();
        }
        public string compararViajes(string cod, string cod2)
        {
            return catalogo.CompararViajes(cod, cod2);
        }
        public bool removerViaje(string cod)
        {
            return catalogo.Remover(cod);
        }
        public bool removerCatalogo()
        {
            return catalogo.Remover();
        }
    }
}
