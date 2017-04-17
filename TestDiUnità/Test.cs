﻿using System;
using GiocoOca.Modello;
using System.Collections.Generic;

namespace TestDiUnità
{
    class Test
    {
        private Pedina pedina;
        private List<Casella> casella;
        int id = 0;
        int numeroCaselle;
        string tipoPedina = "GIOCATORE";
        
        public Test()
        {
            id = 0;
            numeroCaselle = 63;
            tipoPedina = "GIOCATORE";
            casella = new List<Casella>();
        }//end costruttore

        //corpo principale della classe di testing
        public void test()
        {
            bool terminare = false;
            int scelta = 0;

            Console.WriteLine("############################");
            Console.WriteLine("   Programma di Testing");
            Console.WriteLine("############################\n");

            creaPedina();
            do
            { 
                scelta = menu();

                switch (scelta)
                {
                    case 1:
                        testaPosizione();
                        break;
                    case 2:
                        testaEffetto();
                        break;
                    case 3:
                        terminare = true;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            }
            while (!terminare);
        }

        //creo la pedina con le specifiche scelte dall'utente
        private void creaPedina()
        {
            Console.WriteLine("######################################################################");
            Console.Write("Inserire numero di caselle [63/90]: ");
            int.TryParse(Console.ReadLine(), out numeroCaselle);
            pedina = new Pedina(id, numeroCaselle, tipoPedina);
            Console.WriteLine("Creazione Pedina con ID: " + pedina.idGiocatore 
                + ", Numero Caselle: " + numeroCaselle 
                + ", di tipo: " + pedina.tipoPedina);
            Console.WriteLine("######################################################################\n");
        }

        //menu principale
        private int menu()
        {
            int scelta = 0;

            Console.WriteLine("#####################################\n\t\tMENU\n");
            Console.WriteLine("Scegliere un test da effettuare: ");
            Console.WriteLine("1. Test posizione pedina");
            Console.WriteLine("2. Test effetto");
            Console.WriteLine("3. Esci");
            Console.WriteLine("#####################################");
            int.TryParse(Console.ReadLine(), out scelta);
            return scelta;
        }

        //testo il calcolo della posizione della pedina
        private void testaPosizione()
        {
            int input = 0;
            int output = 0;
            int valAtt = 0;

            Console.Write("Inserire il valore lancio dei dadi:");
            int.TryParse(Console.ReadLine(), out input);
            Console.Write("Inserire il valore atteso:");
            int.TryParse(Console.ReadLine(), out valAtt);

            Console.Write("La pedina è nel pozzo? [s/N]");
            if (Console.ReadLine().Equals("s"))
            {
                pedina.inPozzo = true;
            }
            Console.Write("La pedina è in prigione? [s/N]");
            if (Console.ReadLine().Equals("s") && pedina.inPozzo == false)
            {
                pedina.inPrigione = true;
            }
            Console.Write("La pedina deve attendere dei turni? [s/N]");
            if(Console.ReadLine().Equals("s") && pedina.inPozzo == false && pedina.inPrigione == false)
            {
                pedina.attendi(3);
            }

            output = pedina.muovi(input);
            Console.WriteLine("La pedina è in posizione: " + output);
            if (pedina.vincitore == true)
                Console.WriteLine("La pedina ha vinto la partita");
            if (output == valAtt)
                Console.WriteLine("Test superato! :)");
            else
            Console.WriteLine("Test non superato! :(");
        }

        private void testaEffetto()
        {
            int scelta = 0;
           
            TavoloDaGioco tavolo = new TavoloDaGioco(numeroCaselle, 2);
            tavolo.OnEffetto_Applied += applicaEffetto;

            Console.WriteLine("Quale tipo di casella testare?");
            Console.WriteLine("1. Normale");
            Console.WriteLine("2. Locanda");
            Console.WriteLine("3. SpostaAvanti");
            Console.WriteLine("4. SpostaInDietro");
            Console.WriteLine("5. RestaFermo");
            int.TryParse(Console.ReadLine(), out scelta);
            Console.WriteLine("############################");
            switch (scelta)
            {
                case 1:
                    tavolo.gioca_test(0, 2);               
                    break;
                case 2:
                    for(int i = 0; i < 5; i++)
                    {
                        tavolo.gioca_test(0, 19);
                    }
                    break;
                case 3:
                    tavolo.gioca_test(0, 5);
                    break;
                case 4:
                    tavolo.gioca_test(0, 58);
                    break;
                case 5:
                    for (int i = 0; i < 4; i++)
                    {
                        tavolo.gioca_test(0, 31);
                        tavolo.gioca_test(1, i == 0 ? 0 : 31);
                    }
                    break;
                default:
                    Console.WriteLine("Scelta non valida!");
                    break;
            }
        }

        private void applicaEffetto(object sender, ArgEvento<Pedina> e)
        {
            Console.WriteLine("Giocatore: " + e.getValore.idGiocatore
                + " in posizione: " + e.getValore.posizione
                + " su una casella di tipo: " + sender.ToString());
        }
    } 
}