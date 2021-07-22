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
    public partial class AddEntityForm : Form
    {
        public Entity Entity { get; set; }
        public AddEntityForm()
        {
            InitializeComponent();
        }

        private void AddEntityForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (nameTB.Text == "" && DialogResult == DialogResult.OK)
            {
                e.Cancel = true;
                return;
            }

            Entity = new Entity(nameTB.Text, (int)speedNUD.Value, (int)dexterityNUD.Value);
        }
    }
}
