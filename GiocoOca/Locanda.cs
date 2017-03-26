using System;
namespace GiocoOca
{
    public class Locanda : Casella
    {
        private const int NUM_CASELLA = 19;
        private const int NUM_TURNI_ATTESA = 3;

        public Locanda() : base(NUM_CASELLA)
        {
        }

        public override void effetto(TavoloDaGioco t, Pedina p, EventHandler<ArgEvento<Pedina>> evento)
        {
            //metto la pedina in attesa per tre turni
            p.attendi(NUM_TURNI_ATTESA);
            evento.Invoke(this, new ArgEvento<Pedina>(p));
        }
    }
}