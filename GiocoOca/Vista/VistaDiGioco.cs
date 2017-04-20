using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GiocoOca.Vista
{
    /*
     * La Classe VistaDiGioco contiene tutto il necessario per far funzionare 
     * l'aspetto grafico del programma...
     */
    public partial class VistaDiGioco : Form
    {
        //attributi principali della classe
        private int numCaselle;     //numero caselle
        private int numGiocatori;   //numero giocatori
        //liste
        private List<Button> caselle;           //i riquadri rappresentanti le caselle
        private List<Button> pedine;            //i riquadri rappresentanti le pedine
        private GroupBox GruppoGiocatori;       //box lista dei giocatori
        private List<Label> LabelGiocatori;     //nome dei giocatori nel box
        private List<Button> BottoniGiocatori;  //quadrati colorati nel box
        //array contenente tutti i colori delle pedine
        //i colori sono assegnati ad ogni giocatore in
        //base al suo id
        private Color[] colori = {
                   Color.FromArgb(255, 255, 0, 0),     //rosso
                   Color.FromArgb(255, 143, 0, 255),   //viola
                   Color.FromArgb(255, 0, 255, 0),     //verde
                   Color.FromArgb(255, 0, 0, 255),     //blu   
                   Color.FromArgb(255, 255, 20, 147),  //arancione
                   Color.FromArgb(255, 0, 0, 0)        //nero
                   };
        //evento che permette di rigiocare la partita
        public EventHandler OnRigioca_Clicked;

        public VistaDiGioco(int numeroCaselle, int numeroGiocatori)
        {
            this.numCaselle = numeroCaselle;
            this.numGiocatori = numeroGiocatori;
            this.caselle = new List<Button>();
            this.pedine = new List<Button>();
            this.LabelGiocatori = new List<Label>();
            this.BottoniGiocatori = new List<Button>();
            this.GruppoGiocatori = new GroupBox();

            InitializeList();
            InitializeComponent();

            pannelloTavolo.BackgroundImage = Properties.Resources.Sfondo;
            pannelloTavolo.BorderStyle = BorderStyle.FixedSingle;

            loadCaselle();  //disegno le caselle
            inizializza();  //disegno le pedine
            loadIndice();   //disegno l'indice dei giocatori
        }//end costruttore

        //proprietà
        //passo il bottone lancia dadi al controllore
        public Button getButtonLanciaDadi
        {
            get { return bottoneLanciaDadi; }
        }
        //passo il bottone reset al controllore
        public Button getButtonReset
        {
            get { return bottoneReset; }
        }
        //setto la labelLancioDadi con il valore del lancio dei dadi
        public string setLabelLancioDadi
        {
            set { labelLancioDadi.Text = value; }
        }

        //metodo pubblico che richiama il caricamento delle pedine
        public void inizializza()
        {
            loadPedine();
        }

        //metodo per inizializzare le liste
        private void InitializeList()
        {
            for (int i = 0; i <= numCaselle; i++)
                caselle.Add(new Button());
            for (int i = 0; i < numGiocatori; i++)
            {
                pedine.Add(new Button());
                LabelGiocatori.Add(new Label());
                BottoniGiocatori.Add(new Button());
            }
        }//end Initializelist
         
        //metodo per disegnare tutte le caselle
        private void loadCaselle()
        {
            int h = 0, w = 0;   //posizione della prima casella

            if (numCaselle == 63)
                w = 100;
            else
                w = 80;
            
            for (int i = 0; i < caselle.Count; i++)
            {
                if (numCaselle == 63)
                    caselle[i].Size = new Size(50, 50);
                else
                    caselle[i].Size = new Size(40, 40);

                caselle[i].Enabled = true;
                caselle[i].Text = i.ToString();
                caselle[i].TabStop = false;
                caselle[i].FlatStyle = FlatStyle.Flat;
                caselle[i].FlatAppearance.BorderSize = 0;
                caselle[i].Font = new Font(caselle[i].Font, FontStyle.Bold);
                caselle[i].Margin = new Padding(0);
                caselle[i].ForeColor = Color.FromArgb(255, 32, 32, 32);

                if (numCaselle == 63)
                {
                    caselle[i].Location = new Point(w, h);
                    if (i < 12)
                        w += caselle[i].Width;
                    else if (i < 19)
                        h += caselle[i].Height;
                    else if (i < 33)
                        w -= caselle[i].Width;
                    else if (i < 38)
                        h -= caselle[i].Height;
                    else if (i < 50)
                        w += caselle[i].Width;
                    else if (i < 53)
                        h += caselle[i].Height;
                    else if (i <= 63)
                        w -= caselle[i].Width;
                }
                else
                {
                    caselle[i].Location = new Point(w, h);
                    if (i < 16)
                        w += caselle[i].Width;
                    else if (i < 25)
                        h += caselle[i].Height;
                    else if (i < 43)
                        w -= caselle[i].Width;
                    else if (i < 50)
                        h -= caselle[i].Height;
                    else if (i < 66)
                        w += caselle[i].Width;
                    else if (i < 71)
                        h += caselle[i].Height;
                    else if (i < 85)
                        w -= caselle[i].Width;
                    else if (i < 88)
                        h -= caselle[i].Width;
                    else if (i <= 90)
                        w += caselle[i].Width;
                }

                pannelloTavolo.Controls.Add(caselle[i]);
                disegnaCaselle();
                caselle[i].Update();
            }
        }//end loadCaselle

        //metodo per mostrare le pedine nella casella 0
        private void loadPedine()
        {
            for (int i = 0; i < numGiocatori; i++)
            {
                pedine[i].BackColor = colori[i];    //setto il colore
                pedine[i].Location = posizionePedina(i);    //imposto la posizione
                //setto la dimensione del riquadro
                if (numCaselle == 63)
                    pedine[i].Size = new Size(14, 14);
                else
                    pedine[i].Size = new Size(12, 12);
                pedine[i].Text = "";    
                pedine[i].Name = "Giocatore " + i;  //nome della pedina
                pedine[i].TabStop = false;
                pedine[i].Enabled = false; 
                //imposto i bordi
                pedine[i].FlatStyle = FlatStyle.Flat;
                pedine[i].FlatAppearance.BorderSize = 2;
                pedine[i].FlatAppearance.BorderColor = Color.FromArgb(255, 255, 255, 255);
                caselle[i].Invalidate();
                //aggiungo tutte le pedine nella casella 0
                caselle[0].Controls.Add(pedine[i]);
            }
        }//end loadPedine
        
        //metodo che carica l'indice dei giocatori
        private void loadIndice()
        {
            GruppoGiocatori.Location = new Point(12, 418);  //posizione
            GruppoGiocatori.Size = new Size(200, 91);   //dimensione
            GruppoGiocatori.Text = "Giocatori"; 
            GruppoGiocatori.TabStop = false;
            //GruppoGiocatori.TabIndex = 7;
            
            panel1.Controls.Add(GruppoGiocatori);

            for (int i = 0; i < numGiocatori; i++)
            {
                switch (i)
                {
                    case 0:
                        LabelGiocatori[i].Location = new Point(28, 21);
                        BottoniGiocatori[i].Location = new Point(6, 21);
                        break;
                    case 1:
                        LabelGiocatori[i].Location = new Point(28, 44);
                        BottoniGiocatori[i].Location = new Point(6, 44);
                        break;
                    case 2:
                        LabelGiocatori[i].Location = new Point(28, 65);
                        BottoniGiocatori[i].Location = new Point(6, 65);
                        break;
                    case 3:
                        LabelGiocatori[i].Location = new Point(122, 21);
                        BottoniGiocatori[i].Location = new Point(100, 21);
                        break;
                    case 4:
                        LabelGiocatori[i].Location = new Point(122, 44);
                        BottoniGiocatori[i].Location = new Point(100, 44);
                        break;
                    case 5:
                        LabelGiocatori[i].Location = new Point(122, 65);
                        BottoniGiocatori[i].Location = new Point(100, 65);
                        break;
                }
                //setto lo stile delle label e dei riquadri
                LabelGiocatori[i].AutoSize = true;
                LabelGiocatori[i].Size = new Size(62, 13);
                LabelGiocatori[i].Text = "Giocatore " + i;
                BottoniGiocatori[i].BackColor = colori[i];
                BottoniGiocatori[i].Enabled = false;
                BottoniGiocatori[i].Size = new Size(16, 16);
                BottoniGiocatori[i].TabIndex = i;
                BottoniGiocatori[i].FlatStyle = FlatStyle.Flat;
                BottoniGiocatori[i].FlatAppearance.BorderSize = 0;
                BottoniGiocatori[i].UseVisualStyleBackColor = false;
                //agiungo la label e il riquadro all'indice
                GruppoGiocatori.Controls.Add(LabelGiocatori[i]);
                GruppoGiocatori.Controls.Add(BottoniGiocatori[i]);
            }
        }//end loadIndice

        //metodo per inserire le immagini dentro le caselle
        private void disegnaCaselle()
        {
            for(int i = 0; i < caselle.Count; i++)
            {
                if ((i != 0 && i % 9 == 0 || i % 9 == 5) && i != numCaselle) //caselle oca
                    caselle[i].BackgroundImage = Properties.Resources.Oca2;
                else if (i % 2 == 0) //tutte le caselle pari
                    caselle[i].BackgroundImage = Properties.Resources.SfondoPari;
                else //tutte le caselle dispari
                    caselle[i].BackgroundImage = Properties.Resources.SfondoDispari;

                caselle[i].BackgroundImageLayout = ImageLayout.Stretch;
            }

            caselle[6].BackgroundImage = Properties.Resources.Ponte2;
            caselle[19].BackgroundImage = Properties.Resources.Locanda2;
            caselle[31].BackgroundImage = Properties.Resources.Pozzo;
            caselle[52].BackgroundImage = Properties.Resources.Prigione;
            caselle[42].BackgroundImage = Properties.Resources.Labirinto2;
            caselle[58].BackgroundImage = Properties.Resources.Scheletro;
            caselle[numCaselle].BackgroundImage = Properties.Resources.Oca3;
        }//end disegnaCaselle

        //metodo per spostare una pedina nella nuova posizione
        public void spostaPedina(int posizione, int numPedina)
        {
            caselle[posizione].Controls.Add(pedine[numPedina]);
        }

        //metodo per calcolare la posizione della pedina dentro la casella
        private Point posizionePedina(int numPedina)
        {
            Point posizione = new Point(0, 0);
            if (numCaselle == 63)
            
                switch (numPedina)
                {
                    case 0:
                        posizione = new Point(6, 0);
                        break;
                    case 1:
                        posizione = new Point(6, 16);
                        break;
                    case 2:
                        posizione = new Point(6, 32);
                        break;
                    case 3:
                        posizione = new Point(28, 0);
                        break;
                    case 4:
                        posizione = new Point(28, 16);
                        break;
                    case 5:
                        posizione = new Point(28, 32);
                        break;
                }
            
            else if(numCaselle == 90)
            
                switch (numPedina)
                {
                    case 0:
                        posizione = new Point(4, 0);
                        break;
                    case 1:
                        posizione = new Point(4, 13);
                        break;
                    case 2:
                        posizione = new Point(4, 26);
                        break;
                    case 3:
                        posizione = new Point(23, 0);
                        break;
                    case 4:
                        posizione = new Point(23, 13);
                        break;
                    case 5:
                        posizione = new Point(23, 26);
                        break;
                }
            
            return posizione;
        }//end posizionePedina

        //metodo che stampa un messaggio contenente il vincitore della partita
        public void comunicaVincitore(string s)
        {
            string testo = "Il Giocatore " + s + " ha vinto la partita...";
            string titolo = "Vittoria!";
            MessageBoxButtons bottoni = MessageBoxButtons.OK;
            MessageBoxIcon icona = MessageBoxIcon.Asterisk;
            MessageBox.Show(testo, titolo, bottoni, icona);
            rigiocare();
        }
        //overload del metodo comunicaVincitore per terminare il gioco in caso di parità
        public void comunicaVincitore()
        {
            string testo = "Nessun giocatore ha vinto la partita...";
            string titolo = "Parità";
            MessageBoxButtons bottoni = MessageBoxButtons.OK;
            MessageBoxIcon icona = MessageBoxIcon.Asterisk;
            MessageBox.Show(testo, titolo, bottoni, icona);
            rigiocare();
        }
        /*
         * Il metodo viene chiamato dopo la vittoria di un giocatore 
         * o in caso di parità, chiede all'utente se vuole ripetere la 
         * partita mantenendo le stesse impostazioni; in caso affermativo 
         * si invoca il metodo OnRigioca_Clicked che comunica al controllore
         * di ricaricare la partita, altrimenti l'applicazione termina 
         */
        private void rigiocare()
        {
            string testo = "Ripetere la partita?";
            string titolo = "Rigiocare";
            MessageBoxButtons bottoni = MessageBoxButtons.YesNo;
            MessageBoxIcon icona = MessageBoxIcon.Question;
            DialogResult rigiocare = DialogResult.Yes;
            if (MessageBox.Show(testo, titolo, bottoni, icona) == rigiocare)
            {
                OnRigioca_Clicked.Invoke(this, new EventArgs());
            }
            else
                Application.Exit();
        }
        //mostra le regole del gioco
        private void bottoneRegole_Click(object sender, EventArgs e)
        {
            string regole = Properties.Resources.Regole_gioco_oca;
            string titolo = "Regole del gioco";
            MessageBoxButtons bottoni = MessageBoxButtons.OK;
            MessageBox.Show(regole, titolo, bottoni);
        }
    }
}
