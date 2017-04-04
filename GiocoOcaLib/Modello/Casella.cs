using System;
namespace GiocoOca.Modello
{
    public abstract class Casella
    {
        private int _numeroCasella; //numero della casella

        public Casella(int id)
        {
            _numeroCasella = id;
        }//end costruttore

        //metodo che ritorna il numero della casella
        public int idCasella
        {
            get { return _numeroCasella; }
        }

        /*
         * Metodo estratto effetto della pedina.
         * Al metodo è passata l'istanza del tavolo, la pedina che invoca l'effetto 
         * e l'evento effetto applicato che informa il controllore dell'applicazione dell'effetto
         */
        public abstract void effetto(TavoloDaGioco t, Pedina p, EventHandler<ArgEvento<Pedina>> evento);
    }
}
