using System;
using System.Collections.Generic;

namespace GiocoOca
{
    public class TavoloDaGioco
    {
        //costanti simboliche per identificare il tipo di pedina
        private const string GIOCATORE = "GIOCATORE";
        private const string BOT = "BOT";
        //attributi della classe
        private int _numCaselle;    //numero di caselle
        private int _numGiocatori;  //numero di giocatori
        //oggetti principali 
        private List<Casella> _caselle; //lista di caselle
        private List<Pedina> _pedine;   //lista di caselle
        private Dado _dado1;    //il dado numero 1
        private Dado _dado2;    //il dado numero 2
        
        private bool _vincitore;  //pedina che ha vinto la partita
        private Pedina _inPrigione; //pedina dentro la prigione
        private Pedina _inPozzo;    //pedina dentro al pozzo
        private int _lancio;    //lancio del dado effettuato dal giocatore

        //eventi 
        public EventHandler<ArgPedina> OnEffetto_Applied;      //invocato quando viene applicato l'effetto
        public EventHandler OnValueDadi_Updated;    //invocato ogni volta che il dado viene lanciato
        public EventHandler<ArgPedina> OnPosizione_Updated;    //invocato quando la posizione di una pedina cambia 
        public EventHandler<ArgPedina> OnVittoria;             //invocato quando una pedina arriva alla fine
        
        /*
         * Al costruttore della classe è passato il numero delle caselle [63-90] 
         * e il numero di giocatori [2-6] in modo da creare delle liste contenenti
         * il giusto numero di elementi.
         */
        public TavoloDaGioco(int numCaselle, int numGiocatori)
        {
            _numCaselle   = numCaselle;
            _numGiocatori = numGiocatori;

            inizializza();

            _dado1 = new Dado(7);
            _dado2 = new Dado(25);
        }//end costruttore
        public void inizializza()
        {
            _caselle = new List<Casella>();
            _pedine = new List<Pedina>();
            _vincitore = false;
            _inPrigione = null;
            _inPozzo = null;
            _lancio = 0;

            popolaCaselle();
            popolaPedine();
            Console.WriteLine(_caselle.Count+" "+_pedine.Count+" "+_vincitore+_lancio);
        }
        //Proprietà 
        //ritorna il lancio del dado effettuato dal giocatore
        public int lancio
        {
            get { return _lancio; }
        }
        //ritorna e setta la pedina correntemente in prigione
        public Pedina inPrigione
        {
            get { return _inPrigione; }
            set { _inPrigione = value; }
        }
        //ritorna e setta la pedina correntemente nel pozzo
        public Pedina inPozzo
        {
            get { return _inPozzo; }
            set { _inPozzo = value; }
        }
        /*
         * Il metodo gioca è quello principale e gestisce il turno di tutti 
         * i giocatori, sia l'utente che i bot. 
         * Se non c'è un vincitore, per ogni pedina eseguo 
         * il turno del giocatore o del bot a seconda del tipo, 
         * poi controllo se ha vinto e nel caso setto il vincitore.
         */
        public void gioca()
        {
            if(_vincitore == false)
                foreach (Pedina p in _pedine)
                {
                    if (p.tipoPedina == GIOCATORE)
                        turnoGiocatore(p);
                    else if (p.tipoPedina == BOT)
                       turnoBot(p);
                    else
                       throw new Exception("Problema con le caselle");

                    if (p.vincitore)
                    {
                        _vincitore = true;
                        OnVittoria.Invoke(this, new ArgPedina(p));
                    }
                }
            if (_numGiocatori == 2 && _inPozzo != null && _inPrigione != null)
                OnVittoria.Invoke(this, new ArgPedina(null));
        }
        int turno = 0;
        int[] l = { 19 };//{ 31, -30, 18 };
        //metodo per gestire il turno dell'utente
        private void turnoGiocatore(Pedina p)
        {
            int tiro = 0;
            //se la pedina non è in attesa o in prigione
            //lancio il dado, altrimenti passo 0 come lancio
            if (!p.inAttesa && _inPrigione != p && _inPozzo != p)
                 tiro = lanciaDadi();
            _lancio = tiro;

            if (turno < l.Length)
                tiro = l[turno];
            turno++;
            OnValueDadi_Updated.Invoke(this, new EventArgs());
            sposta(p, p.muovi(tiro));
            OnPosizione_Updated.Invoke(this, new ArgPedina(p));
        }//end turnoGiocatore
        
        //metodo per gestire il turno dei bot
        private void turnoBot(Pedina p)
        {
            int tiro = lanciaDadi();
            sposta(p, p.muovi(tiro));
            OnPosizione_Updated.Invoke(this, new ArgPedina(p));
        }//end turnoBot

        //metodo per spostare le pedina
        public void sposta(Pedina p, int posizione)
        {
            _caselle[posizione - 1].effetto(this, p, OnEffetto_Applied);
        }

        //metodo che simula il lancio dei dadi 
        private int lanciaDadi()
        {
            return (_dado1.lanciaDadi() + _dado2.lanciaDadi());
        }//end lanciaDadi

        //metodi per istanziare le liste di caselle e pedine
        private void popolaPedine()
        {
            for(int i = 0; i < _numGiocatori; i++)
            {
                if (i == 0)
                    _pedine.Add(new Pedina(i, _numCaselle, GIOCATORE));
                else
                    _pedine.Add(new Pedina(i, _numCaselle, BOT));
            }
        }

        private void popolaCaselle()
        {
            for (int i = 1; i <= _numCaselle; i++)
            {
                /* if (i == 6)
                     _caselle.Add(new Ponte());
                 else if (i == 19)
                     _caselle.Add(new Locanda());
                 else if (i == 31)
                     _caselle.Add(new Pozzo());
                 else if (i == 52)
                     _caselle.Add(new Prigione());
                else if (i == 42)
                    _caselle.Add(new Labirinto());
                else if (i == 58)
                    _caselle.Add(new Scheletro());
                else if (i % 9 == 0 || i % 9 == 5)
                    _caselle.Add(new Oca(i));
                else
                    _caselle.Add(new Normale(i));*/

                //istanzio le caselle Oca e la casella Ponte
                if ((i == 6 || i % 9 == 0 || i % 9 == 5) && i != _numCaselle)
                    _caselle.Add(new SpostaInAvanti(i));
                //istanzio la casella Locanda
                else if (i == 19)
                    _caselle.Add(new Locanda());
                //istanzio la casella Pozzo
                else if (i == 31 || i == 52)
                    _caselle.Add(new RestaFermo(i));
               // else if (i == 31)
                 //   _caselle.Add(new Pozzo());
                //istanzio la casella Prigione
                //else if (i == 52)
                  //  _caselle.Add(new Prigione());
                //istanzio la casella Labirinto e Scheletro
                else if (i == 42 || i == 58)
                    _caselle.Add(new SpostaInDietro(i, (i == 42) ? 39 : 1));
                //istanzio le caselle Normali
                else
                    _caselle.Add(new Normale(i));
            }


            //foreach (Casella c in _caselle)
            //{
            //    Console.WriteLine(c.idCasella + " " + c.GetType());
            //    //if (c is Prigione)
            //    //    Console.WriteLine(c.idCasella);
            //}
        }
       
    }//end classe
}
