using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Champions.Characters
{
    public class Characteristic : BaseCPObject, IIntervalObject
    {

        public int BaseValue { get; private set; }
        public int CPInterval { get; private set; }
        public int ValueInterval { get; private set; }
        public int BaseCP { get; private set; }

        public override int CP 
        {
            get
            {
                return BaseCP + (int)Math.Ceiling((Value - BaseValue) * (decimal)CPInterval);
            }
        }

        public Characteristic(string name, int baseValue, int increase, int interval, bool hasRoll, int baseCP = 0) : base(name)
        {
            BaseValue = baseValue;
            ValueInterval = increase;
            CPInterval = interval;
            if (hasRoll)
            {
                CharacteristicRoll = new ModifiedSkill(name, Skill.SkillType.Characteristic);
                CharacteristicRoll.Subscribe(this);
            }

            Value = baseValue;
            BaseCP = baseCP;
        }

        public ModifiedSkill CharacteristicRoll { get; private set; }

    }

    public class Characteristics : BaseCPObject
    {
        Dictionary<string, Characteristic> _characteristics;

        readonly public static List<string> Order = new List<string>()
        {
            "Size",
            "STR",
            "DEX",
            "CON",
            "INT",
            "EGO",
            "PRE",
            "OCV",
            "DCV",
            "OMCV",
            "DMCV",
            "SPD",
            "PD",
            "ED",
            "REC",
            "END",
            "BODY",
            "STUN",
            "Run",
            "Leap",
            "Swim"
        };

        public Characteristics(string name) : base(name)
        {
            _characteristics = new Dictionary<string, Characteristic>();
        }

        public override int CP
        {
            get
            {
                int cp = 0;
                foreach (string key in _characteristics.Keys)
                    cp += _characteristics[key].CP;
                return cp;
            }
        }

        public void ObjectUpdated(object sender, EventArgs e)
        {
            OnUpdate(new ObjectUpdatedEventArgs(CP, Value));
        }

        public void AddCharacteristic(Characteristic c)
        {
            try
            {
                _characteristics.Add(c.Name, c);
            }
            catch (ArgumentException) 
            {
                _characteristics[c.Name] = c;
            }

            c.Alert += ObjectUpdated;
        }

        public Characteristic GetCharacteristic(string key)
        {
            return _characteristics[key];
        }

        public List<Characteristic> ToList()
        {
            List<Characteristic> ret = new List<Characteristic>();

            foreach (string key in Order)
                if (_characteristics.ContainsKey(key))
                    ret.Add(_characteristics[key]);

            return ret;
        }
    }
}
