using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Observable<T>
    {
        public delegate void Observer(T thingie);

        private List<Observer> _observers = new List<Observer>();

        public void Add(Observer del) => _observers.Add(del);

        public void Notify(T thingie) => _observers.ForEach(x => x.Invoke(thingie));

    }
}
