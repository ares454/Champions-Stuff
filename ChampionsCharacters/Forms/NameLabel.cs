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
    public partial class NameLabel : Label
    {
        public NameLabel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// TODO: Update so that the text changes as the object name changes
        /// </summary>
        /// <param name="obj"></param>
        public void Subscribe(BaseCPObject obj)
        {
            if (obj == null)
                return;

            Text = obj.Name;
        }
    }
}
