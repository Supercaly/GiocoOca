using System;

namespace GiocoOca.Modello
{
    public class ArgEvento<T> : EventArgs
    {
        private T _valore;

        public ArgEvento(T valore)
        {
            _valore = valore;
        }//end costruttore

        //proprietà per ottenere la pedina
        public T getValore
        {
            get { return _valore; }
        }
    }
}