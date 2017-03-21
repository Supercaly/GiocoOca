using System;
namespace GiocoOca
{
    public class Labirinto : Casella
    {
        private const int NUM_CASELLA = 42;

        public Labirinto() : base(NUM_CASELLA)
        {
        }

        public override void effetto(TavoloDaGioco t, Pedina p, EventHandler<ArgPedina> evento)
        {
            int tiro = p.muovi(-3);
            t.sposta(p, tiro);
            evento.Invoke(this, new ArgPedina(p));
        }
    }
}