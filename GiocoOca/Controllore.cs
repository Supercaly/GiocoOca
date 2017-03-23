using System;

namespace GiocoOca
{
    class Controllore
    {
        private TavoloDaGioco _tavolo;
        private VistaDiGioco _vista;

        public Controllore(VistaDiGioco vista, TavoloDaGioco tavolo)
        {
            _vista = vista;
            _tavolo = tavolo;

            //eventi
            _tavolo.OnEffetto_Applied           += AggiornaPosizione;
            _tavolo.OnValueDadi_Updated         += StampaDadi;
            _tavolo.OnPosizione_Updated         += AggiornaPosizione;
            _tavolo.OnVittoria                  += VittoriaDiUnGiocatore;
            _vista.getButtonLanciaDadi().Click  += Vista_Click_LanciaDadi;
            _vista.OnRigioca_Clicked            += Vista_Click_Rigioca;
        }//end costruttore

        private void Vista_Click_Rigioca(object sender, EventArgs e)
        {
            _tavolo.inizializza();
            _vista.inizializza();
        }
        //metodo eseguito alla vittoria di un giocatore
        private void VittoriaDiUnGiocatore(object sender, ArgPedina e)
        {
            if (e.getPedina != null)
                _vista.SetTextbutt(e.getPedina.idGiocatore.ToString());
            else
                _vista.SetTextbutt();

           // _vista.SetTextbutt("ha vinto il giocatore: " + _tavolo._vincitore.idGiocatore);
        }

        //metodo eseguito ogni volta che la pedina aggiorna la sua posizione o viene applicato un effetto di una casella
        private void AggiornaPosizione(object sender, ArgPedina e)
        {
            _vista.spostaPedina(e.getPedina.posizione, e.getPedina.idGiocatore);
        }

        //metodo eseguito al click del pulsante lancia dadi
        private void Vista_Click_LanciaDadi(object sender, EventArgs e)
        {
            _tavolo.gioca();
        }

        //metodo eseguito ogni volta che i dadi sono lanciati; ne stampa il loro valore
        private void StampaDadi(object sender, EventArgs e)
        {
            _vista.setLabelLancioDadi(_tavolo.lancio.ToString());
        }
    }
}
