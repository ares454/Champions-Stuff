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
    public partial class RollableCPObjectToolSet : UserControl
    {
        string _text;
        public override string Text 
        { 
            get { return _text; }
            set
            {
                _text = value;
                cpLabel.Text = _text;
                nameLabel.Text = _text;
                rollableObjectLabel.Text = _text;

            }
        }

        public RollableCPObjectToolSet()
        {
            InitializeComponent();
        }

        public bool Subscribe(BaseCPObject obj)
        {
            nameLabel.Subscribe(obj);
            cpObjectNUD.Subscribe(obj);
            cpLabel.Subscribe(obj);
            return rollableObjectLabel.Subscribe(obj is IThreshold ? obj : ((Characteristic)obj).CharacteristicRoll);
        }
    }
}
