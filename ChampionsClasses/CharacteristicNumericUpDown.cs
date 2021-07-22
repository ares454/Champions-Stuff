using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Champions.Characters;

namespace Champions.Forms
{
    public partial class CharacteristicNumericUpDown : NumericUpDown
    {
        private delegate void UpdateObject(int value);
        private UpdateObject _update;


        public CharacteristicNumericUpDown()
        {
            InitializeComponent();
        }

        public bool Subscribe(BaseCPObject obj)
        {
            _update = obj.UpdateValue;
            return false;
        }

        private void CharacteristicNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _update((int)this.Value);
        }
    }
}
