using System;

namespace GiocoOca.Modello
{
    class RestaFermo : Casella
    {
        private const int POZZO = 31;
        private const int PRIGIONE = 52;
        private int _idCasella;

        public RestaFermo(int idCasella) : base(idCasella)
        {
            _idCasella = idCasella;
        }

        public override void effetto(TavoloDaGioco t, Pedina p, EventHandler<ArgEvento<Pedina>> evento)
        {
            //se la casella è il pozzo
            if (_idCasella == POZZO)
            {
                //controllo se in pozzo c'è nessuno
                if (t.inPozzo != null && t.inPozzo != p)
                    //se c'è un'altra pedina la libero
                    t.inPozzo.inPozzo = false;
                //poi prendo il posto in pozo
                p.inPozzo = true;
                t.inPozzo = p;
            }
            //altrimenti se la casella è la prigione
            else if(_idCasella == PRIGIONE)
            {
                //controllo se in prigione c'è nessuno
                if (t.inPrigione != null && t.inPrigione != p)
                    //se c'era un'altra pedina la libero
                    t.inPrigione.inPrigione = false;
                
                //poi prendo il posto in prigione 
                p.inPrigione = true;
                t.inPrigione = p;
            }
            evento.Invoke(this, new ArgEvento<Pedina>(p));
        }
    }
}
