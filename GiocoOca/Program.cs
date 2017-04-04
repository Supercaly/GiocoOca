using System;
using System.Windows.Forms;
using GiocoOca.Modello;
using GiocoOca.Vista;
using GiocoOca.Controller;

namespace GiocoOca
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int numeroCaselle;
            int numeroGiocatori;

            Menu menu;                  //il menù iniziale
            VistaDiGioco vista;         //la vista di gioco
            TavoloDaGioco tavolo;       //il tavolo da gioco
            Controllore controllore;    //il controllore

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            menu = new Menu();
            Application.Run(menu);
            
            numeroGiocatori = menu.getGiocatori;
            numeroCaselle = menu.getCaselle;

            //se il numero delle caselle e delle pedine è stato settato
            //avvio la vista principale
            if (numeroCaselle != 0 && numeroGiocatori != 0)
            {
                vista = new VistaDiGioco(numeroCaselle, numeroGiocatori);
                tavolo = new TavoloDaGioco(numeroCaselle, numeroGiocatori);
                controllore = new Controllore(vista, tavolo);
                Application.Run(vista);
            }
        }
    }
}
