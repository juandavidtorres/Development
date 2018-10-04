namespace gasolutions
{
    partial class ClienteBuscar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdClientes = new System.Windows.Forms.DataGridView();
            this.IdClienteGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentificacionGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonaContactoGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DireccionGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelefonoGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CiudadGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblProducto = new System.Windows.Forms.Label();
            this.Popup = new PopupNotifier();
            ((System.ComponentModel.ISupportInitialize)(this.grdClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // grdClientes
            // 
            this.grdClientes.AllowUserToAddRows = false;
            this.grdClientes.AllowUserToDeleteRows = false;
            this.grdClientes.AllowUserToResizeColumns = false;
            this.grdClientes.AllowUserToResizeRows = false;
            this.grdClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdClientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdClientes.BackgroundColor = System.Drawing.Color.White;
            this.grdClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.grdClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdClienteGrilla,
            this.IdentificacionGrilla,
            this.NombreGrilla,
            this.PersonaContactoGrilla,
            this.DireccionGrilla,
            this.TelefonoGrilla,
            this.CiudadGrilla});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdClientes.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdClientes.Location = new System.Drawing.Point(0, 14);
            this.grdClientes.MultiSelect = false;
            this.grdClientes.Name = "grdClientes";
            this.grdClientes.ReadOnly = true;
            this.grdClientes.RowHeadersVisible = false;
            this.grdClientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.grdClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdClientes.Size = new System.Drawing.Size(632, 233);
            this.grdClientes.TabIndex = 32;
            this.grdClientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdClientes_CellDoubleClick);
            // 
            // IdClienteGrilla
            // 
            this.IdClienteGrilla.DataPropertyName = "IdCliente";
            this.IdClienteGrilla.HeaderText = "IdCliente";
            this.IdClienteGrilla.Name = "IdClienteGrilla";
            this.IdClienteGrilla.ReadOnly = true;
            this.IdClienteGrilla.Visible = false;
            this.IdClienteGrilla.Width = 73;
            // 
            // IdentificacionGrilla
            // 
            this.IdentificacionGrilla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IdentificacionGrilla.DataPropertyName = "Identificacion";
            this.IdentificacionGrilla.FillWeight = 85F;
            this.IdentificacionGrilla.HeaderText = "Identificacion";
            this.IdentificacionGrilla.MinimumWidth = 85;
            this.IdentificacionGrilla.Name = "IdentificacionGrilla";
            this.IdentificacionGrilla.ReadOnly = true;
            this.IdentificacionGrilla.Width = 85;
            // 
            // NombreGrilla
            // 
            this.NombreGrilla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NombreGrilla.DataPropertyName = "Nombre";
            this.NombreGrilla.FillWeight = 220F;
            this.NombreGrilla.HeaderText = "Nombre";
            this.NombreGrilla.MinimumWidth = 20;
            this.NombreGrilla.Name = "NombreGrilla";
            this.NombreGrilla.ReadOnly = true;
            this.NombreGrilla.Width = 220;
            // 
            // PersonaContactoGrilla
            // 
            this.PersonaContactoGrilla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PersonaContactoGrilla.DataPropertyName = "PersonaContacto";
            this.PersonaContactoGrilla.FillWeight = 120F;
            this.PersonaContactoGrilla.HeaderText = "Persona de Contacto";
            this.PersonaContactoGrilla.MinimumWidth = 90;
            this.PersonaContactoGrilla.Name = "PersonaContactoGrilla";
            this.PersonaContactoGrilla.ReadOnly = true;
            this.PersonaContactoGrilla.Width = 120;
            // 
            // DireccionGrilla
            // 
            this.DireccionGrilla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DireccionGrilla.DataPropertyName = "Direccion";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DireccionGrilla.DefaultCellStyle = dataGridViewCellStyle5;
            this.DireccionGrilla.FillWeight = 60F;
            this.DireccionGrilla.HeaderText = "Dirección";
            this.DireccionGrilla.MaxInputLength = 3;
            this.DireccionGrilla.MinimumWidth = 60;
            this.DireccionGrilla.Name = "DireccionGrilla";
            this.DireccionGrilla.ReadOnly = true;
            this.DireccionGrilla.Width = 60;
            // 
            // TelefonoGrilla
            // 
            this.TelefonoGrilla.DataPropertyName = "Telefono";
            this.TelefonoGrilla.HeaderText = "Teléfono";
            this.TelefonoGrilla.Name = "TelefonoGrilla";
            this.TelefonoGrilla.ReadOnly = true;
            this.TelefonoGrilla.Width = 74;
            // 
            // CiudadGrilla
            // 
            this.CiudadGrilla.DataPropertyName = "Ciudad";
            this.CiudadGrilla.HeaderText = "Ciudad";
            this.CiudadGrilla.Name = "CiudadGrilla";
            this.CiudadGrilla.ReadOnly = true;
            this.CiudadGrilla.Width = 65;
            // 
            // lblProducto
            // 
            this.lblProducto.BackColor = System.Drawing.Color.White;
            this.lblProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProducto.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblProducto.Location = new System.Drawing.Point(0, 0);
            this.lblProducto.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(632, 14);
            this.lblProducto.TabIndex = 31;
            this.lblProducto.Text = "CLIENTES";
            this.lblProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Popup
            // 
            this.Popup.BodyColor = System.Drawing.Color.DarkGreen;
            this.Popup.CloseButton = false;
            this.Popup.ContentColor = System.Drawing.Color.White;
            this.Popup.ContentFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Popup.ContentText = null;
            this.Popup.HeaderColor = System.Drawing.Color.Green;
            this.Popup.Image = null;
            this.Popup.ImagePosition = new System.Drawing.Point(12, 21);
            this.Popup.ImageSize = new System.Drawing.Size(32, 32);
            this.Popup.OptionsMenu = null;
            this.Popup.Size = new System.Drawing.Size(400, 100);
            this.Popup.TextPadding = new System.Windows.Forms.Padding(0);
            this.Popup.TitleFont = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.Popup.TitleText = null;
            // 
            // ClienteBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 247);
            this.Controls.Add(this.grdClientes);
            this.Controls.Add(this.lblProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ClienteBuscar";
            this.ShowIcon = false;
            this.Text = "Búsqueda de Clientes";
            this.Load += new System.EventHandler(this.ClienteBuscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdClientes;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdClienteGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentificacionGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonaContactoGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn DireccionGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn TelefonoGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn CiudadGrilla;
        internal PopupNotifier Popup;
    }
}