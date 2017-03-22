using System;

namespace GiocoOca
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

        public override void effetto(TavoloDaGioco t, Pedina p, EventHandler<ArgPedina> evento)
        {
            if (_idCasella == POZZO)
            {
                if (t.inPozzo != null && t.inPozzo != p)
                    t.inPozzo.inPozzo = false;
                p.inPozzo = true;
                t.inPozzo = p;
            }
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
            //Console.WriteLine(this.idCasella + " " + _idCasella + " " + t.inPozzo + " " + t.inPrigione + " " + p.inPozzo + p.inPrigione);
            evento.Invoke(this, new ArgPedina(p));
        }
    }
}
