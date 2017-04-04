using System;
namespace GiocoOca.Modello
{
    public class Pedina
    {
        //attributi identificativi
        private int _idGiocatore;   //numero del giocatore [1-6]
        private int _numeroCaselle; //numero delle caselle
        private string _tipoPedina; //sono un giocatore o un bot

        //attributi di stato
        private int _posizioneAttuale;  //posizione della pedina
        private int _tiroPrecedente;        //tiro precedente
        private int _numeroTurniAttendere;  //numero turni d'attesa
        private bool _inAttesa;     //sono nella locanda?
        private bool _inPrigione;   //sono in prigione?
        private bool _inPozzo;      //sono nel pozzo?
        private bool _vincitore;    //sono nell'ultima casella?

        public Pedina(int id, int numCas, string tipoPedina)
        {
            _idGiocatore          = id;
            _numeroCaselle        = numCas;
            _tipoPedina           = tipoPedina;

            _posizioneAttuale     = 0; //le caselle partono dalla casella 0 
            _tiroPrecedente       = 0;
            _numeroTurniAttendere = 0;
            _vincitore            = false;
            _inAttesa             = false;
            _inPrigione           = false;
            _inPozzo              = false;
        }//end costruttore

        //Proprietà 
        //restituisce l'id del giocatore
        public int idGiocatore
        {
            get { return _idGiocatore; }
        }
        //restituisce una stringa che indica se la pedina 
        //è GIOCATORE o BOT
        public string tipoPedina
        {
            get { return _tipoPedina; }
        }

        //restituisce il tiro effettuato precedentemente
        public int tiroPrecedente
        {
            get { return _tiroPrecedente; }
        }

        //restituisce la posizione attuale della pedina
        public int posizione
        {
            get { return _posizioneAttuale; }
        }
        //restituisce un valore booleano che indica se la 
        //pedina è in attesa
        public bool inAttesa
        {
            get { return _inAttesa; }
        }
        //restituisce un valore booleano che indica se la 
        //pedina è in prigione
        public bool inPrigione
        {
            get { return _inPrigione; }
            set { _inPrigione = value; }
        }
        //restituisce un valore booleano che indica se la 
        //pedina è nel pozzo
        public bool inPozzo
        {
            get { return _inPozzo; }
            set { _inPozzo = value; }
        }
        //restituisce un valore booleano che indica se la 
        //pedina è il vincitore
        public bool vincitore
        {
            get { return _vincitore; }
            set { _vincitore = value; }
        }
        /*
		* il metodo prende in input un intero (esito del lancio dei dadi)
		* e restituisce un intero (casella nella quale spostarsi)
		* attenzione perché la posizione restituita va da 1 a numero caselle
		*/
        public int muovi(int tiro)
        {
            _tiroPrecedente = tiro;
            //se sono capitato sulla locanda
            if (_numeroTurniAttendere != 0)
                //decremento di uno i turni d'attesa
                _numeroTurniAttendere--;
            //altrimenti se non sono nella locanda e non sono in pozzo o prigione
            else if(_inPozzo == false && _inPrigione == false)
            {
                //aggiorno la posizione
                _posizioneAttuale += tiro;
                
                //se con il tiro ho superato la fine devo tornare indietro
                if (_posizioneAttuale > _numeroCaselle)
                    _posizioneAttuale = _numeroCaselle - (_posizioneAttuale - _numeroCaselle);

                //controllo se la pedina è arrivata nell'ultima casella
                if (_posizioneAttuale == _numeroCaselle)
                    _vincitore = true;
            }
            return _posizioneAttuale;
        }//end muovi

        /*
         * Metodo per mettere in attesa la pedina quando finisce nella locanda.
         * Controllo se la pedina è in attesa e nel caso la metto in attesa e 
         * setto i turni d'attesa altrimenti se il numero di turni d'attesa è 
         * 0 non devo essere in attesa.
         */
        public void attendi(int numTurniAttesa)
        {
            if (!_inAttesa)
            {
                _inAttesa = true;
                _numeroTurniAttendere = numTurniAttesa;
            }
            else if(_numeroTurniAttendere == 0)
                _inAttesa = false;
        }//end attendi
    }
}
