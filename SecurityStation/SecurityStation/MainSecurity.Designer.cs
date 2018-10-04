namespace SecurityStation
{
    partial class MainSecurity
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
            this.Popup = new PopupNotifier();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.securityStationColombia1 = new Controles.SecurityStationColombia();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Popup
            // 
            this.Popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            this.Popup.ContentText = null;
            this.Popup.Image = null;
            this.Popup.ImagePosition = new System.Drawing.Point(12, 21);
            this.Popup.ImageSize = new System.Drawing.Size(32, 32);
            this.Popup.OptionsMenu = null;
            this.Popup.Size = new System.Drawing.Size(400, 100);
            this.Popup.TextPadding = new System.Windows.Forms.Padding(0);
            this.Popup.TitleFont = new System.Drawing.Font("Segoe UI", 9F);
            this.Popup.TitleText = null;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.AutoScroll = true;
            this.pnlPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlPrincipal.Location = new System.Drawing.Point(152, 107);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(1218, 455);
            this.pnlPrincipal.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.securityStationColombia1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 527);
            this.panel1.TabIndex = 6;
            // 
            // securityStationColombia1
            // 
            this.securityStationColombia1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.securityStationColombia1.Cambiar = true;
            this.securityStationColombia1.Desbloquear = true;
            this.securityStationColombia1.Dock = System.Windows.Forms.DockStyle.Left;
            this.securityStationColombia1.Location = new System.Drawing.Point(0, 0);
            this.securityStationColombia1.Name = "securityStationColombia1";
            this.securityStationColombia1.Permisos = true;
            this.securityStationColombia1.Roles = true;
            this.securityStationColombia1.RolesUsuario = true;
            this.securityStationColombia1.Size = new System.Drawing.Size(152, 527);
            this.securityStationColombia1.TabIndex = 0;
            this.securityStationColombia1.Usuario = true;
            this.securityStationColombia1.RolesEvent += new Controles.SecurityStationColombia.EventHandler(this.securityStationColombia1_RolesEvent);
            this.securityStationColombia1.UsuarioEvent += new Controles.SecurityStationColombia.EventHandler(this.securityStationColombia1_UsuarioEvent);
            this.securityStationColombia1.RolesUsuarioEvent += new Controles.SecurityStationColombia.EventHandler(this.securityStationColombia1_RolesUsuarioEvent);
            this.securityStationColombia1.CambiarEvent += new Controles.SecurityStationColombia.EventHandler(this.securityStationColombia1_CambiarEvent);
            this.securityStationColombia1.PermisosEvent += new Controles.SecurityStationColombia.EventHandler(this.securityStationColombia1_PermisosEvent);
            this.securityStationColombia1.DesbloquearEvent += new Controles.SecurityStationColombia.EventHandler(this.securityStationColombia1_DesbloquearEvent);
            this.securityStationColombia1.SalirEvent += new Controles.SecurityStationColombia.EventHandler(this.securityStationColombia1_SalirEvent);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.White;
            this.toolStrip2.BackgroundImage = global::SecurityStation.Properties.Resources.BarraInf;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Location = new System.Drawing.Point(152, 565);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1218, 69);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackgroundImage = global::SecurityStation.Properties.Resources.Encabezado3;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1370, 107);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // MainSecurity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 634);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainSecurity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainSecurity_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private PopupNotifier Popup;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel panel1;
        private Controles.SecurityStationColombia securityStationColombia1;
    }
}