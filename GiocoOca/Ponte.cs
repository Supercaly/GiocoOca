using System;
namespace GiocoOca
{
    public class Ponte : Casella
    {
        private const int NUM_CASELLA = 6;
        public Ponte() : base(NUM_CASELLA)
        {
        }

        public override void effetto(TavoloDaGioco t, Pedina p, EventHandler<ArgPedina> evento)
        {
            int tiro = p.muovi(p.tiroPrecedente);
            t.sposta(p, tiro);
            evento.Invoke(this, new ArgPedina(p));
        }
    }
}
