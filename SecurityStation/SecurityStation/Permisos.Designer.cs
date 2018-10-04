namespace SecurityStation
{
    partial class Permisos
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkTodas = new System.Windows.Forms.CheckBox();
            this.grdPermisos = new System.Windows.Forms.DataGridView();
            this.Valor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IdAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PopUp = new PopupNotifier();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuCerrar = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPermisos)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbRole);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 73);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones permitidas";
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(57, 29);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(383, 24);
            this.cmbRole.TabIndex = 5;
            this.cmbRole.SelectedIndexChanged += new System.EventHandler(this.cmbRole_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label3.Location = new System.Drawing.Point(23, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Role";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkTodas);
            this.panel1.Controls.Add(this.grdPermisos);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(25, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 372);
            this.panel1.TabIndex = 13;
            // 
            // chkTodas
            // 
            this.chkTodas.AutoSize = true;
            this.chkTodas.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTodas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.chkTodas.Location = new System.Drawing.Point(5, 84);
            this.chkTodas.Name = "chkTodas";
            this.chkTodas.Size = new System.Drawing.Size(87, 20);
            this.chkTodas.TabIndex = 7;
            this.chkTodas.Text = "Elegir Todas";
            this.chkTodas.UseVisualStyleBackColor = true;
            this.chkTodas.Click += new System.EventHandler(this.chkTodas_Click);
            // 
            // grdPermisos
            // 
            this.grdPermisos.AllowUserToAddRows = false;
            this.grdPermisos.AllowUserToDeleteRows = false;
            this.grdPermisos.AllowUserToOrderColumns = true;
            this.grdPermisos.BackgroundColor = System.Drawing.Color.White;
            this.grdPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPermisos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Valor,
            this.IdAccion,
            this.IdRole,
            this.Accion,
            this.Descripcion});
            this.grdPermisos.Location = new System.Drawing.Point(5, 113);
            this.grdPermisos.Name = "grdPermisos";
            this.grdPermisos.RowHeadersVisible = false;
            this.grdPermisos.Size = new System.Drawing.Size(471, 254);
            this.grdPermisos.TabIndex = 6;
            this.grdPermisos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPermisos_CellValueChanged);
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            this.Valor.HeaderText = "Es Permitido";
            this.Valor.Name = "Valor";
            this.Valor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IdAccion
            // 
            this.IdAccion.DataPropertyName = "IdAccion";
            this.IdAccion.HeaderText = "IdAccion";
            this.IdAccion.Name = "IdAccion";
            this.IdAccion.ReadOnly = true;
            this.IdAccion.Visible = false;
            this.IdAccion.Width = 200;
            // 
            // IdRole
            // 
            this.IdRole.DataPropertyName = "IdRole";
            this.IdRole.HeaderText = "IdRole";
            this.IdRole.Name = "IdRole";
            this.IdRole.ReadOnly = true;
            this.IdRole.Visible = false;
            // 
            // Accion
            // 
            this.Accion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Accion.DataPropertyName = "Accion";
            this.Accion.HeaderText = "Accion";
            this.Accion.Name = "Accion";
            this.Accion.ReadOnly = true;
            this.Accion.Width = 65;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 88;
            // 
            // PopUp
            // 
            this.PopUp.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            this.PopUp.ContentText = null;
            this.PopUp.Image = null;
            this.PopUp.ImagePosition = new System.Drawing.Point(12, 21);
            this.PopUp.ImageSize = new System.Drawing.Size(32, 32);
            this.PopUp.OptionsMenu = null;
            this.PopUp.Size = new System.Drawing.Size(400, 100);
            this.PopUp.TextPadding = new System.Windows.Forms.Padding(0);
            this.PopUp.TitleFont = new System.Drawing.Font("Segoe UI", 9F);
            this.PopUp.TitleText = null;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCerrar});
            this.toolStrip1.Location = new System.Drawing.Point(473, 12);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(74, 40);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuCerrar
            // 
            this.mnuCerrar.AutoSize = false;
            this.mnuCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(143)))), ((int)(((byte)(26)))));
            this.mnuCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuCerrar.Image = global::SecurityStation.Properties.Resources.Cancel;
            this.mnuCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.mnuCerrar.Name = "mnuCerrar";
            this.mnuCerrar.Size = new System.Drawing.Size(36, 36);
            this.mnuCerrar.Text = "Cerrar";
            this.mnuCerrar.Click += new System.EventHandler(this.mnuCerrar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label2.Location = new System.Drawing.Point(91, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(348, 27);
            this.label2.TabIndex = 55;
            this.label2.Text = "REGISTRO DE ACCIONES POR ROLE";
            // 
            // Permisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Permisos";
            this.Size = new System.Drawing.Size(536, 523);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPermisos)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grdPermisos;
        private PopupNotifier PopUp;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuCerrar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkTodas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdAccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn Accion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.Label label2;
    }
}
