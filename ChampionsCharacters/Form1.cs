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
using Champions;

namespace ChampionsCharacters
{
    public partial class Form1 : Form
    {
        BaseCPObject obj = CloneFactory.GetCharacteristicSet("Vehicle");

        public Form1()
        {
            InitializeComponent();
            characteristicGroupBox1.Subscribe(obj);
        }
    }
}
