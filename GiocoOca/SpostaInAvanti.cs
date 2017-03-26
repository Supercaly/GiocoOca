using System;

namespace GiocoOca
{
    class SpostaInAvanti : Casella
    {

        public SpostaInAvanti(int idCasella) : base(idCasella)
        {
        }

        /*
         * Override del metodo effetto.
         * Il metodo sposta la pedina di n posizioni pari al tiro
         * effettuato precedentemente.
         */
        public override void effetto(TavoloDaGioco t, Pedina p, EventHandler<ArgEvento<Pedina>> evento)
        {
            if (!p.vincitore)
            {
                int tiro = p.muovi(p.tiroPrecedente);
                t.sposta(p, tiro);
            }
            evento.Invoke(this, new ArgEvento<Pedina>(p));
        }
    }
}
