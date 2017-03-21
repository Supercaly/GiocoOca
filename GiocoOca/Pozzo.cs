using System;
namespace GiocoOca
{
    public class Pozzo : Casella
    {
        private const int NUM_CASELLA = 31;

        public Pozzo() : base(NUM_CASELLA)
        {
        }

        public override void effetto(TavoloDaGioco t, Pedina p, EventHandler<ArgPedina> evento)
        {
            //Sposto la pedina nella casella 52
            int tiro = p.muovi(21);
            t.sposta(p, tiro);
            evento.Invoke(this, new ArgPedina(p));
        }
    }
}