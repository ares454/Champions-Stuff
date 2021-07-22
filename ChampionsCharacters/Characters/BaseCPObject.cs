using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Champions.Characters
{
    public class Dice
    {
        public enum Die { d2 = 2, d3 = 3, d4 = 4, d6 = 6, d8 = 8, d10 = 10, d12 = 12, d20 = 20, d100 = 100}
        static Random rng;
        private Dice() { }

        static public int Roll(Die die = Die.d6)
        {
            if (rng == null)
                rng = new Random();

            return rng.Next(1, (int)die + 1);
        }

        static public int[] Roll(int numDice, Die die = Die.d6)
        {
            int[] results = new int[numDice];
            for (int i = 0; i < numDice; ++i)
                results[i] = rng.Next(1, (int)die + 1);

            return results;
        }
    }
        
    abstract public class BaseCPObject
    {
        private int _value;

        public string Name { get; set; }
        public abstract int CP { get; }
        public int Value 
        {
            get => _value;
            protected set
            {
                if (_value == value)
                    return;

                _value = value;
                OnUpdate(new ObjectUpdatedEventArgs(CP, Value));
            }
        }

        //public delegate void ObjectUpdated(object sender, EventArgs e);
        public void UpdateValue(int value) { Value = value; }

        public event EventHandler Alert;

        public BaseCPObject(string name)
        {
            Name = name;
#if DEBUG
            Alert += UpdateObject;
#endif
        }

        public void UpdateObject(object sender, EventArgs e)
        {
            ObjectUpdatedEventArgs oa = e as ObjectUpdatedEventArgs;
            Console.WriteLine("{0} is the new value.", ((BaseCPObject)sender).Value);
        }


        protected virtual void OnUpdate(EventArgs e)
        {
            EventHandler handler = Alert;
            if (Alert != null)
                handler.Invoke(this, e);
        }
    }

    public interface IIntervalObject
    {
        int CPInterval { get; }
        int ValueInterval { get;  }
        int BaseCP { get; }
    }


    public class ObjectUpdatedEventArgs : EventArgs
    {
        public int CP { get; private set; }
        public int Value { get; private set; }

        public ObjectUpdatedEventArgs(int cp, int value)
        {
            CP = cp;
            Value = value;
        }
    }
}
