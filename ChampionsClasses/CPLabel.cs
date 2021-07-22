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

namespace Champions.Characters
{
    public partial class CPLabel : Label
    {
        public CPLabel()
        {
            InitializeComponent();
        }

        public void Subscribe(BaseCPObject obj)
        {
            obj.Alert += ObjectUpdated;
        }

        public void ObjectUpdated(object sender, EventArgs e)
        {
            ObjectUpdatedEventArgs args = e as ObjectUpdatedEventArgs;

            Text = string.Format("{0}\tCP", args.CP);
        }
    }
}
