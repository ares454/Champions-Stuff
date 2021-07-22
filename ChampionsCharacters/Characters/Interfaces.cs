using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Champions.Characters
{
    public enum RollType { Skill, Attack, Normal_Damage, Killing_Damage, Effect, Body_Only, Six_Only }

    interface IRollable
    {
        RollType Type { get; }
        decimal NumDice { get; }

        RollResult Roll();

        void Update(object sender, EventArgs e);
    }

    interface IThreshold : IRollable
    {
        int Threshold { get; }
    }
}
