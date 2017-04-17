using System;
using GiocoOca.Modello;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestDiUnità
{
    class Program
    {
        static void Main(string[] args)
        {
            //classe di testing
            Test test = new Test();
            bool terminare = false;
            //avvio il test
            test.test();
           //uscita
           // Console.WriteLine("############################");
            //Console.WriteLine("Premere un tasto per uscire...");
            //Console.ReadKey();
        }
    }
}
