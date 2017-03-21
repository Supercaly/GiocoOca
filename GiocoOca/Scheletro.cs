using System;
namespace GiocoOca
{
    public class Scheletro : Casella
    {
        private const int NUM_CASELLA = 58;
        public Scheletro() : base(NUM_CASELLA)
        {
        }

        public override void effetto(TavoloDaGioco t, Pedina p, EventHandler<ArgPedina> evento)
        {
            int tiro = p.muovi(-57);
            t.sposta(p, tiro);
            evento.Invoke(this, new ArgPedina(p));
        }
    }
}
