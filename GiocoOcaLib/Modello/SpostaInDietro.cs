using System;

namespace GiocoOca.Modello
{
    public class SpostaInDietro : Casella
    {
        private int _destinazione;

        public SpostaInDietro(int idCasella, int destinazione) : base(idCasella)
        {
            _destinazione = destinazione;
        }//end costruttore

        /*
         * Override del metodo effetto.
         * Il metodo sposta la pedina in una data posizione (destinazione) passata 
         * all'atto della creazione 
         */
        public override void effetto(TavoloDaGioco t, Pedina p, EventHandler<ArgEvento<Pedina>> evento)
        {
            int tiro = p.muovi(_destinazione - p.posizione);
            t.sposta(p, tiro);
            evento.Invoke(this, new ArgEvento<Pedina>(p));
        }
    }
}
