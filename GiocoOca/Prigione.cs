using System;
namespace GiocoOca
{
    public class Prigione : Casella
    {
        private const int NUM_CASELLA = 52;

        public Prigione() : base(NUM_CASELLA)
        {
        }

        public override void effetto(TavoloDaGioco t, Pedina p, EventHandler<ArgPedina> evento)
        {
            //controllo se in prigione c'è nessuno
            if (t.inPrigione != null && t.inPrigione != p)
            {
                //se c'era un'altra pedina la libero
                t.inPrigione.inPrigione = false;
            }
            //poi prendo il posto in prigione 
            p.inPrigione = true;
            t.inPrigione = p;
            evento.Invoke(this, new ArgPedina(p));
        }
    }
}