using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Champions.Characters
{
    public class RollableAbility : IRollable
    {
        public decimal NumDice { get; private set; }

        public RollType Type { get; private set; }

        public RollResult Roll()
        {

            throw new NotImplementedException();
        }

        public void Update(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
