using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Champions_Stuff
{
    public class Entity : IComparable
    {
        public int Speed { get; set; }
        public int Dexterity { get; set; }
        public string Name { get; set; }

        public int CompareTo(object obj)
        {
            Entity test = obj as Entity;

            int result = Dexterity - test.Dexterity;
            if (result != 0)
                return result;
            else
                return Speed - test.Speed;
        }

        public override string ToString()
        {
            return Name;
        }

        public Entity(string name = "", int spd = 0, int dex = 0)
        {
            Name = name;
            Speed = spd;
            Dexterity = dex;
        }
    }
}
