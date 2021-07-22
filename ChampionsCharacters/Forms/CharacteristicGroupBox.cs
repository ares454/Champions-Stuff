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
    public partial class CharacteristicGroupBox : UserControl
    {
        bool _readonly;

        public bool ReadOnly 
        { 
            get { return _readonly; } 
            set
            {
                _readonly = value;
                groupBox1.Enabled = !_readonly;
            }
        }
        public CharacteristicGroupBox()
        {
            InitializeComponent();
        }

        public void Subscribe(BaseCPObject obj)
        {
            if (!(obj is Characteristics) || obj == null)
            {
                ReadOnly = true;
                return;
            }

            List<RollableCPObjectToolSet> controls = new List<RollableCPObjectToolSet>();
            controls.AddRange(groupBox1.Controls.OfType<RollableCPObjectToolSet>());
            controls = (from control in controls
                       orderby control.TabIndex
                        where control is RollableCPObjectToolSet
                       select control).ToList<RollableCPObjectToolSet>();
            Characteristics characteristics = obj as Characteristics;
            int index = 0;

            foreach (Control control in controls)
                control.Visible = false;

            foreach(Characteristic c in characteristics.ToList())
            {
                RollableCPObjectToolSet control = controls[index++];
                control.Visible = true;
                control.Subscribe(c);
            }    

            obj.Alert += ObjectUpdated;
            ObjectUpdated(obj, new ObjectUpdatedEventArgs(obj.CP, obj.Value));
        }

        public void ObjectUpdated(object sender, EventArgs e)
        {
            if (sender == null)
            {
                ReadOnly = true;
                return;
            }

            groupBox1.Text = string.Format("Characteristics: {0} CP", ((BaseCPObject)sender).CP);
        }
    }
}
