using System;

namespace GiocoOca
{
    public class ArgPedina : EventArgs
    {
        private Pedina pedina;

        public ArgPedina(Pedina p)
        {
            pedina = p;
        }//end costruttore

        //proprietà per ottenere la pedina
        public Pedina getPedina
        {
            get { return pedina; }
        }
    }
}