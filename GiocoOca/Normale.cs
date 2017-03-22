using System;

namespace GiocoOca
{
    class Normale : Casella
    {
        public Normale(int numCasella) : base(numCasella)
        {
        }

        public override void effetto(TavoloDaGioco t, Pedina p, EventHandler<ArgPedina> evento)
        {
            //la casella normale non fa nulla in particolare
            evento.Invoke(this, new ArgPedina(p));
        }
    }
}