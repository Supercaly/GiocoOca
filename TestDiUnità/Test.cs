using System;
using GiocoOca.Modello;

namespace TestDiUnità
{
    class Test
    {
        private Pedina pedina;
        int id = 0;
        int numeroCaselle;
        string tipoPedina = "GIOCATORE";
        
        public Test()
        {
            id = 0;
            numeroCaselle = 63;
            tipoPedina = "GIOCATORE";
        }//end costruttore

        //corpo principale della classe di testing
        public void test()
        {
            int scelta = 0;
            Console.WriteLine("############################");
            Console.WriteLine("   Programma di Testing");
            Console.WriteLine("############################\n");

            creaPedina();
            scelta = menu();

            switch (scelta)
            {
                case 1:
                    testaPosizione();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        }

        //creo la pedina con le specifiche scelte dall'utente
        private void creaPedina()
        {
            Console.WriteLine("############################");
            Console.Write("Inserire numero di caselle [63/90]: ");
            int.TryParse(Console.ReadLine(), out numeroCaselle);
            pedina = new Pedina(id, numeroCaselle, tipoPedina);
            Console.WriteLine("Creazione Pedina con ID: " + pedina.idGiocatore 
                + ", Numero Caselle: " + numeroCaselle 
                + ", di tipo: " + pedina.tipoPedina);
            Console.WriteLine("############################\n");
        }

        //menu principale
        private int menu()
        {
            int scelta = 0;

            Console.WriteLine("############################\n\t\tMENU\n");
            Console.WriteLine("Scegliere un test da effettuare: ");
            Console.WriteLine("1. Test posizione pedina");
            Console.WriteLine("2. Test effetto");
            Console.WriteLine("3. Esci");
            int.TryParse(Console.ReadLine(), out scelta);
            Console.WriteLine("############################");
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
    } 
}