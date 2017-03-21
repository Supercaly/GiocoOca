using System;
namespace GiocoOca
{
    public class Oca : Casella
    {
        public Oca(int numeroCasella) : base(numeroCasella)
        {
        }

        public override void effetto(TavoloDaGioco t, Pedina p, EventHandler<ArgPedina> evento)
        {
            if (!p.vincitore)
            {
                int tiro = p.muovi(p.tiroPrecedente);
                t.sposta(p, tiro);
            }
            evento.Invoke(this, new ArgPedina(p));
        }
    }
}
