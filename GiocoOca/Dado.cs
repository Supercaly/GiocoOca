using System;
namespace GiocoOca
{
    public class Dado
    {
        private Random _rnd;

        public Dado(int seed)
        {
            _rnd = new Random(DateTime.Now.Millisecond + seed);
        }//end costruttore

        //metodo che simula il lancio di un dado 
        //estraendo in maniera casuale un numero [1-6]
        public int lanciaDadi()
        {
            return _rnd.Next(1, 7);
        }
    }
}