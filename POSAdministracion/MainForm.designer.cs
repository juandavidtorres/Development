using System.Windows.Forms;
namespace gasolutions.UInterface
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Popup = new PopupNotifier();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataAdminMenuColombia1 = new Controles.DataAdminMenuColombia();
            this.tlbBottom = new gasolutions.UInterface.CustomToolStrip();
            this.tlbTop = new gasolutions.UInterface.CustomToolStrip();
            this.mnuAyuda = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.tlbTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // Popup
            // 
            this.Popup.BodyColor = System.Drawing.Color.SteelBlue;
            this.Popup.CloseButton = false;
            this.Popup.ContentColor = System.Drawing.Color.White;
            this.Popup.ContentFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Popup.ContentText = null;
            this.Popup.HeaderColor = System.Drawing.Color.SteelBlue;
            this.Popup.Image = null;
            this.Popup.ImagePosition = new System.Drawing.Point(12, 21);
            this.Popup.ImageSize = new System.Drawing.Size(32, 32);
            this.Popup.OptionsMenu = null;
            this.Popup.Size = new System.Drawing.Size(400, 100);
            this.Popup.TextPadding = new System.Windows.Forms.Padding(0);
            this.Popup.TitleFont = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.Popup.TitleText = null;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.AutoScroll = true;
            this.pnlPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlPrincipal.Location = new System.Drawing.Point(171, 107);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(1199, 549);
            this.pnlPrincipal.TabIndex = 40;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.panel1.Controls.Add(this.dataAdminMenuColombia1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 621);
            this.panel1.TabIndex = 41;
            // 
            // dataAdminMenuColombia1
            // 
            this.dataAdminMenuColombia1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.dataAdminMenuColombia1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataAdminMenuColombia1.Location = new System.Drawing.Point(0, 0);
            this.dataAdminMenuColombia1.Margin = new System.Windows.Forms.Padding(1);
            this.dataAdminMenuColombia1.MenuAdministarEds = true;
            this.dataAdminMenuColombia1.MenuFinanciera = true;
            this.dataAdminMenuColombia1.MenuGerenciamiento = true;
            this.dataAdminMenuColombia1.Name = "dataAdminMenuColombia1";
            this.dataAdminMenuColombia1.Size = new System.Drawing.Size(169, 621);
            this.dataAdminMenuColombia1.TabIndex = 0;
            this.dataAdminMenuColombia1.MenuAdministarEdsEvent += new Controles.DataAdminMenuColombia.EventHandler(this.dataAdminMenuColombia1_MenuAdministarEdsEvent);
            this.dataAdminMenuColombia1.MenuGerenciamientoEvent += new Controles.DataAdminMenuColombia.EventHandler(this.dataAdminMenuColombia1_MenuGerenciamientoEvent);
            this.dataAdminMenuColombia1.MenuFinancieraEvent += new Controles.DataAdminMenuColombia.EventHandler(this.dataAdminMenuColombia1_MenuFinancieraEvent);
            this.dataAdminMenuColombia1.SalirEvent += new Controles.DataAdminMenuColombia.EventHandler(this.dataAdminMenuColombia1_SalirEvent);
            // 
            // tlbBottom
            // 
            this.tlbBottom.AutoSize = false;
            this.tlbBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.tlbBottom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tlbBottom.BackgroundImage")));
            this.tlbBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tlbBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlbBottom.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlbBottom.Location = new System.Drawing.Point(171, 659);
            this.tlbBottom.Name = "tlbBottom";
            this.tlbBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tlbBottom.Size = new System.Drawing.Size(1199, 69);
            this.tlbBottom.TabIndex = 32;
            this.tlbBottom.Text = "customToolStrip2";
            // 
            // tlbTop
            // 
            this.tlbTop.AutoSize = false;
            this.tlbTop.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Encabezado3;
            this.tlbTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlbTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAyuda});
            this.tlbTop.Location = new System.Drawing.Point(0, 0);
            this.tlbTop.Name = "tlbTop";
            this.tlbTop.Padding = new System.Windows.Forms.Padding(0, 4, 1, 0);
            this.tlbTop.Size = new System.Drawing.Size(1370, 107);
            this.tlbTop.TabIndex = 28;
            this.tlbTop.Text = "customToolStrip1";
            // 
            // mnuAyuda
            // 
            this.mnuAyuda.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuAyuda.Image = global::gasolutions.UInterface.Properties.Resources.help;
            this.mnuAyuda.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuAyuda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuAyuda.Name = "mnuAyuda";
            this.mnuAyuda.Padding = new System.Windows.Forms.Padding(4);
            this.mnuAyuda.Size = new System.Drawing.Size(32, 100);
            this.mnuAyuda.Text = "Ayuda";
            this.mnuAyuda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(86)))));
            this.ClientSize = new System.Drawing.Size(1370, 728);
            this.Controls.Add(this.tlbBottom);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.tlbTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "SAUCE |  Data Admin ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.tlbTop.ResumeLayout(false);
            this.tlbTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomToolStrip tlbBottom;
        internal PopupNotifier Popup;
        private Panel pnlPrincipal;
        private Panel panel1;
        private ToolStripButton mnuAyuda;
        private CustomToolStrip tlbTop;
        private Controles.DataAdminMenuColombia dataAdminMenuColombia1;
       

    }
}
