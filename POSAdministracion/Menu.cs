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
    public partial class Menu : UserControl
    {
     
         #region "   Declaracion de Variables   y Eventos "
  
        protected ItemMenu SelectedItem = null;
        protected Panel View = null;
        protected Dictionary<string, ItemMenu> menuItems = new Dictionary<string, ItemMenu>();      

        #endregion


        public Menu()
        {
            InitializeComponent();
            this.Initialize();
        }


        protected void Initialize() 
        {
            this.InitializeOptions();

            if (this.View != null)
            {
                this.VisibleOptions(true);
                this.AsignButtonEvents();
            }
        }


        private void AsignButtonEvents()
        {
            foreach (Control control in this.View.Controls)
            {
                if (control is Button)
                    control.Click += new System.EventHandler(this.buttonMenu_Click);
            }
           
        }

        private void InitItemMenu(ItemMenu item)
        {
            try
            {
                item.Visible = false;
                item.OnClosed += new  ItemMenu.OnClosedHandler(this.item_OnClosed);
                this.View.Controls.Add(item);
            }
            catch { throw; }
        }

        private void item_OnClosed(object sender, EventArgs e)  {   this.Reset();   }
                       
      
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            try
            {
                this.VisibleOptions(false);
                this.AplicarPermisosPorAcciones();
                                
                string key = ((Control) sender).Name;
                ItemMenu item = (ItemMenu) Activator.CreateInstance(menuItems[key].GetType());

                this.InitItemMenu(item);
                item.Visible = true;
                item.BringToFront();

                if (this.SelectedItem != null)
                    this.SelectedItem.Visible = false;

                this.SelectedItem = item;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show((ex.Message));
            }

        }


        private void VisibleOptions(bool isVisible)
        {
            foreach (Control control in this.View.Controls)
                if (control is Button)  control.Visible = isVisible;
        }


        public void Reset()
        {
            if (this.SelectedItem != null)
            {
                this.SelectedItem.Visible = false;
                this.SelectedItem.Dispose();
                this.SelectedItem = null;
            }

            this.VisibleOptions(true);
        }


        protected virtual void AplicarPermisosPorAcciones(){}
        protected virtual void InitializeOptions(){}
    }
}
