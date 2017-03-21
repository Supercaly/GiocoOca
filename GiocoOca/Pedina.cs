using System;
namespace GiocoOca
{
    public class Pedina
    {
        //attributi identificativi
        private int _idGiocatore;
        private int _numeroCaselle;
        private String _tipoPedina;

        //attributi di stato
        private int _posizioneAttuale;
        private int _tiroPrecedente; 
        private int _numeroTurniAttendere;
        private bool _inAttesa;
        private bool _inPrigione;
        private bool _vincitore;

       // public bool inGalera = false;

        public Pedina(int id, int numCas, String tipoPedina)
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
        }//end costruttore

        //Proprietà 
        public int idGiocatore
        {
            get { return _idGiocatore; }
        }

        public String tipoPedina
        {
            get { return _tipoPedina; }
        }

        public int tiroPrecedente
        {
            get { return _tiroPrecedente; }
        }

        public int posizione
        {
            get { return _posizioneAttuale; }
        }

        public bool inAttesa
        {
            get { return _inAttesa; }
        }

        public bool inPrigione
        {
            get { return _inPrigione; }
            set { _inPrigione = value; }
        }

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

            if (_numeroTurniAttendere != 0)
            {
                //se sono in attesa non posso muovermi e resto dove sono
                //se devo rimanere fermo per un numero di turni prestabilito
                //if (_numeroTurniAttendere != 0)
                    //faccio passare un turno
                    _numeroTurniAttendere--;
            }
            else if(_inPrigione == false)
            {
                //altrimenti mi sposto
                _inAttesa = false;
                _posizioneAttuale += tiro;
            }

            //se con il tiro ho superato la fine devo tornare indietro
            if (_posizioneAttuale > _numeroCaselle)
                _posizioneAttuale = _numeroCaselle - (_posizioneAttuale - _numeroCaselle);

            //controllo se la pedina è arrivata nell'ultima casella
            if (_posizioneAttuale == _numeroCaselle)
                _vincitore = true;

            return _posizioneAttuale;
        }//end muovi

        public void attendi(int numeroTurni)
        {
            //se la pedina non è in attesa
            if (!_inAttesa)
            {
                //la metto in attesa
                _inAttesa = true;
                //e setto il numero di turni d'attendere
                _numeroTurniAttendere = numeroTurni;
            }
        }//end attendi
    }
}
