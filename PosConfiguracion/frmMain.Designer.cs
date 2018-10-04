namespace PosConfiguracion
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fsConfigColombia1 = new Controles.FSConfigColombia();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tobBotton = new gasolutions.UInterface.CustomToolStrip();
            this.tobMain = new gasolutions.UInterface.CustomToolStrip();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator1.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator2.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator3.Visible = false;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(95, 22);
            this.toolStripLabel1.Text = "Gasolutions Ltda";
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.AutoScroll = true;
            this.pnlContenedor.BackColor = System.Drawing.Color.White;
            this.pnlContenedor.Location = new System.Drawing.Point(155, 107);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(961, 561);
            this.pnlContenedor.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fsConfigColombia1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 626);
            this.panel1.TabIndex = 9;
            // 
            // fsConfigColombia1
            // 
            this.fsConfigColombia1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.fsConfigColombia1.Config = true;
            this.fsConfigColombia1.Dock = System.Windows.Forms.DockStyle.Left;
            this.fsConfigColombia1.Estacion = true;
            this.fsConfigColombia1.FormaPago = true;
            this.fsConfigColombia1.Lectores = true;
            this.fsConfigColombia1.Liquido = true;
            this.fsConfigColombia1.Location = new System.Drawing.Point(0, 0);
            this.fsConfigColombia1.Name = "fsConfigColombia1";
            this.fsConfigColombia1.Otros = true;
            this.fsConfigColombia1.Size = new System.Drawing.Size(152, 626);
            this.fsConfigColombia1.Sobretasa = true;
            this.fsConfigColombia1.TabIndex = 0;
            this.fsConfigColombia1.Tarjeta = true;
            this.fsConfigColombia1.Unidad = true;
            this.fsConfigColombia1.OtrosEvent += new Controles.FSConfigColombia.EventHandler(this.fsConfigColombia1_OtrosEvent);
            this.fsConfigColombia1.LectoresEvent += new Controles.FSConfigColombia.EventHandler(this.fsConfigColombia1_LectoresEvent);
            this.fsConfigColombia1.ConfigEvent += new Controles.FSConfigColombia.EventHandler(this.fsConfigColombia1_ConfigEvent);
            this.fsConfigColombia1.EstacionEvent += new Controles.FSConfigColombia.EventHandler(this.fsConfigColombia1_EstacionEvent);
            this.fsConfigColombia1.LiquidoEvent += new Controles.FSConfigColombia.EventHandler(this.fsConfigColombia1_LiquidoEvent);
            this.fsConfigColombia1.UnidadEvent += new Controles.FSConfigColombia.EventHandler(this.fsConfigColombia1_UnidadEvent);
            this.fsConfigColombia1.SobretasaEvent += new Controles.FSConfigColombia.EventHandler(this.fsConfigColombia1_SobretasaEvent);
            this.fsConfigColombia1.TarjetaEvent += new Controles.FSConfigColombia.EventHandler(this.fsConfigColombia1_TarjetaEvent);
            this.fsConfigColombia1.SalirEvent += new Controles.FSConfigColombia.EventHandler(this.fsConfigColombia1_SalirEvent);
            this.fsConfigColombia1.FormaPagoEvent += new Controles.FSConfigColombia.EventHandler(this.fsConfigColombia1_FormaPagoEvent);
            this.fsConfigColombia1.BonosEvent += new Controles.FSConfigColombia.EventHandler(this.fsConfigColombia1_BonosEvent);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 51);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // tobBotton
            // 
            this.tobBotton.AutoSize = false;
            this.tobBotton.BackgroundImage = global::PosConfiguracion.Properties.Resources.BarraInf;
            this.tobBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tobBotton.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tobBotton.Location = new System.Drawing.Point(152, 665);
            this.tobBotton.Name = "tobBotton";
            this.tobBotton.Size = new System.Drawing.Size(1202, 68);
            this.tobBotton.TabIndex = 4;
            this.tobBotton.Text = "customToolStrip1";
            // 
            // tobMain
            // 
            this.tobMain.AutoSize = false;
            this.tobMain.BackgroundImage = global::PosConfiguracion.Properties.Resources.Encabezado3;
            this.tobMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tobMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tobMain.Location = new System.Drawing.Point(0, 0);
            this.tobMain.Name = "tobMain";
            this.tobMain.Padding = new System.Windows.Forms.Padding(0, 4, 1, 0);
            this.tobMain.Size = new System.Drawing.Size(1354, 107);
            this.tobMain.TabIndex = 3;
            this.tobMain.Text = "customToolStrip1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.tobBotton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.tobMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Sauce | Configurador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private gasolutions.UInterface.CustomToolStrip tobBotton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Panel panel1;
        private Controles.FSConfigColombia fsConfigColombia1;
        private gasolutions.UInterface.CustomToolStrip tobMain;





    }
}


