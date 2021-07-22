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
    public partial class CPLabel : Label
    {
        public CPLabel()
        {
            InitializeComponent();
        }

        public void Subscribe(BaseCPObject obj)
        {
            obj.Alert += ObjectUpdated;
            ObjectUpdated(obj, new ObjectUpdatedEventArgs(obj.CP, obj.Value));
        }

        public void ObjectUpdated(object sender, EventArgs e)
        {
            try
            {
                ObjectUpdatedEventArgs args = e as ObjectUpdatedEventArgs;

                Text = string.Format("{0} CP", args.CP);
            }catch(Exception)
            {

            }
        }
    }
}
