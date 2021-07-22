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
    public partial class CPObjectNumericUpDown : NumericUpDown
    {
        private delegate void UpdateObject(int value);
        private UpdateObject _update;


        public CPObjectNumericUpDown()
        {
            InitializeComponent();
        }

        public bool Subscribe(BaseCPObject obj)
        {
            _update = obj.UpdateValue;
            this.Value = obj.Value;
            return false;
        }

        /// <summary>
        /// Updates the value for the associated CPObject
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacteristicNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(_update != null)
                _update((int)this.Value);
        }
    }
}
