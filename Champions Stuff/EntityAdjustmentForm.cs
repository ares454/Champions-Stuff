using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Champions_Stuff
{
    public partial class EntityAdjustmentForm : Form
    {

        public int SpeedAdjustment { get; private set; }
        public int DexterityAdjustment { get; private set; }

        public EntityAdjustmentForm()
        {
            InitializeComponent();
        }

        private void speedNUD_ValueChanged(object sender, EventArgs e)
        {
            SpeedAdjustment = (int)speedNUD.Value;
        }

        private void dexterityNUD_ValueChanged(object sender, EventArgs e)
        {
            DexterityAdjustment = (int)dexterityNUD.Value;
        }
    }
}
