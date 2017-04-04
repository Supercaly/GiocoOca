﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoOca.Modello
{
    class SpostaInDietro : Casella
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