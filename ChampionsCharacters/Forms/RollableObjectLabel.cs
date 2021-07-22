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
    public partial class RollableObjectLabel : Label
    {
        public RollableObjectLabel()
        {
            InitializeComponent();
        }

        public bool Subscribe(BaseCPObject obj)
        {
            if (!(obj is IThreshold))
            {
                Text = "";
                return false;
            }

            obj.Alert += ObjectUpdated;
            ObjectUpdated(obj, new ThreshholdChangedEventArgs(((IThreshold)obj).Threshold));
            return true;
        }

        public void ObjectUpdated(object sender, EventArgs e)
        {
            if (!(sender is IRollable) || sender == null)
            {
                return;
            }

            try
            {

                if (sender is IThreshold)
                {
                    ThreshholdChangedEventArgs tc = e as ThreshholdChangedEventArgs;
                    IThreshold obj = sender as IThreshold;

                    Text = string.Format("{0}-", obj.Threshold);
                }
            }catch(Exception)
            {

            }
        }
    }
}
