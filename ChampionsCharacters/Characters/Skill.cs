using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Champions.Characters
{
    public abstract class Skill : BaseCPObject
    {
        public enum SkillType { Characteristic, Characteristic_CPCost, Background }
        public override int CP { get; }

        public Skill(string name) : base(name)
        {

        }
    }

    public class ModifiedSkill : Skill, IThreshold
    {
        private SkillType type;
        int bonus;
        public int Threshold 
        {
            get => (9 + Value + bonus);
            set
            {
                Value = value;
                base.OnUpdate(new ThreshholdChangedEventArgs(Threshold));
            }
        }
        public override int CP
        {
            get
            {
                switch(type)
                {
                    case SkillType.Characteristic:
                        return 0;
                    case SkillType.Characteristic_CPCost:
                        return 3 + (2 * Value);
                    case SkillType.Background:
                        return 3 + Value;
                }

                return 0;
            }
        }

        public decimal NumDice { get; private set; }

        public RollType Type { get; private set; }

        public ModifiedSkill(string name, SkillType type = (SkillType)0) : base(name)
        {
            NumDice = 3;
            this.type = type;
            Type = RollType.Skill;
        }

        public void Update(object sender, EventArgs e)
        {
            ObjectUpdatedEventArgs args = e as ObjectUpdatedEventArgs;
            bonus = args.Value / 5;
            base.OnUpdate(new ThreshholdChangedEventArgs(Threshold));
        }

        public RollResult Roll()
        {
            RollResult result = new RollResult(Dice.Roll((int)NumDice, Dice.Die.d6), Type);
            return result;
        }


        public void Subscribe(BaseCPObject obj)
        {
            obj.Alert += Update;
        }
    }

    public class RollResult
    {
        /// <summary>
        /// This variable represents sum of the die rolled. Use for Effect Rolls, Stun Damage, and other Rolls
        /// </summary>
        public int Total { get; private set; }
        /// <summary>
        /// This variable is used for anything that requires a body result
        /// </summary>
        public int Body { get; private set; }

        public int[] DieValues { get; private set; }

        public RollResult(int[] values, RollType type)
        {
            Total = 0;
            Body = 0;
            DieValues = values;


            switch(type)
            {
                case RollType.Skill:
                case RollType.Effect:
                case RollType.Body_Only:
                case RollType.Attack:
                    Total = FaceCount(values);
                    break;
                case RollType.Normal_Damage:
                case RollType.Killing_Damage:
                    Total = FaceCount(values);
                    Body = BodyCount(values);
                    if(type == RollType.Killing_Damage)
                        Total *= Dice.Roll(Dice.Die.d3);
                    break;
                case RollType.Six_Only:
                    Total = ValueCount(values, 6);
                    break;
            }
        }

        public int FaceCount(int[] values)
        {
            int ret = 0;
            foreach (int value in values)
                ret += value;

            return ret;
        }

        public int BodyCount(int[] values)
        {
            int ret = 0;
            foreach(int value in values)
            {
                if (value >= 2 && value <= 5)
                    ret++;
                else if (value == 6)
                    ret += 2;
            }

            return ret;
        }

        public int ValueCount(int[] values, int target)
        {
            return values.Count<int>(s => s == target);
        }
    }

    public class ThreshholdChangedEventArgs : EventArgs
    {
        public int Threshhold { get; private set; }
        public ThreshholdChangedEventArgs(int threshhold)
        {
            Threshhold = threshhold;
        }
    }
}
