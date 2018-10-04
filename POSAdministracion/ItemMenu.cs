using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gasolutions.UInterface 
{
    public partial class ItemMenu : UserControl
    {
        public delegate void OnClosedHandler(object sender, EventArgs e);
        public event OnClosedHandler OnClosed;

        public ItemMenu()  {  InitializeComponent();  }

        protected internal virtual void RiseEvent_OnClosed(object sender, EventArgs e)
        {
            if (this.OnClosed != null)
            { this.OnClosed(sender, e); }
        }
             
    }
}
