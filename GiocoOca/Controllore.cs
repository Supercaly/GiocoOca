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
            _vista.getButtonLanciaDadi.Click  += Vista_Click_LanciaDadi;
            _vista.OnRigioca_Clicked            += Vista_Click_Rigioca;
            _vista.getButtonReset.Click       += Vista_Click_Rigioca;
        }//end costruttore

        //metodo eseguito quando si vuole rigiocare la partita
        private void Vista_Click_Rigioca(object sender, EventArgs e)
        {
            //setto a true il campo rigiocare del tavolo in modo 
            //da bloccare i giocatori che non hanno vinto 
            _tavolo.rigiocare = true;
            //riinizializzo tutti gli elementi del tavolo e della vista
            _tavolo.inizializza();
            _vista.inizializza();
        }
        //metodo eseguito alla vittoria di un giocatore
        private void VittoriaDiUnGiocatore(object sender, ArgEvento<Pedina> e)
        {
            if (e.getValore != null)
                _vista.comunicaVincitore(e.getValore.idGiocatore.ToString());
            else
                _vista.comunicaVincitore();
        }
        //metodo eseguito ogni volta che la pedina aggiorna la sua posizione o viene applicato un effetto di una casella
        private void AggiornaPosizione(object sender, ArgEvento<Pedina> e)
        {
            _vista.spostaPedina(e.getValore.posizione, e.getValore.idGiocatore);
        }
        //metodo eseguito al click del pulsante lancia dadi
        private void Vista_Click_LanciaDadi(object sender, EventArgs e)
        {
            _tavolo.gioca();
        }
        //metodo eseguito ogni volta che i dadi sono lanciati; ne stampa il loro valore
        private void StampaDadi(object sender, ArgEvento<int> e)
        {
            _vista.setLabelLancioDadi = e.getValore.ToString();
        }
    }
}
