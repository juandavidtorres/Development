namespace Controles
{
    partial class gsInicioSesion
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
            this.Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnLogearse = new System.Windows.Forms.Button();
            this.pnlAuxiliar = new System.Windows.Forms.Panel();
            this.pbImagenLogin = new System.Windows.Forms.PictureBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.pnlAuxiliar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // Tooltip
            // 
            this.Tooltip.IsBalloon = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(285, 156);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 26);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnLogearse
            // 
            this.btnLogearse.AutoSize = true;
            this.btnLogearse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnLogearse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogearse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogearse.ForeColor = System.Drawing.Color.White;
            this.btnLogearse.Location = new System.Drawing.Point(198, 156);
            this.btnLogearse.Name = "btnLogearse";
            this.btnLogearse.Size = new System.Drawing.Size(75, 26);
            this.btnLogearse.TabIndex = 3;
            this.btnLogearse.Text = "Aceptar";
            this.btnLogearse.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLogearse.UseCompatibleTextRendering = true;
            this.btnLogearse.UseVisualStyleBackColor = false;
            this.btnLogearse.Click += new System.EventHandler(this.btnLogearse_Click);
            // 
            // pnlAuxiliar
            // 
            this.pnlAuxiliar.BackColor = System.Drawing.Color.White;
            this.pnlAuxiliar.BackgroundImage = global::Controles.Properties.Resources.IniciodeSesion;
            this.pnlAuxiliar.Controls.Add(this.pbImagenLogin);
            this.pnlAuxiliar.Controls.Add(this.btnCancelar);
            this.pnlAuxiliar.Controls.Add(this.btnLogearse);
            this.pnlAuxiliar.Controls.Add(this.lblClave);
            this.pnlAuxiliar.Controls.Add(this.txtClave);
            this.pnlAuxiliar.Controls.Add(this.txtDocumento);
            this.pnlAuxiliar.Controls.Add(this.lblDetalle);
            this.pnlAuxiliar.Controls.Add(this.lblDocumento);
            this.pnlAuxiliar.Location = new System.Drawing.Point(0, 0);
            this.pnlAuxiliar.Name = "pnlAuxiliar";
            this.pnlAuxiliar.Size = new System.Drawing.Size(448, 220);
            this.pnlAuxiliar.TabIndex = 6;
            // 
            // pbImagenLogin
            // 
            this.pbImagenLogin.ErrorImage = global::Controles.Properties.Resources.Security;
            this.pbImagenLogin.Image = global::Controles.Properties.Resources.Security;
            this.pbImagenLogin.InitialImage = global::Controles.Properties.Resources.Security;
            this.pbImagenLogin.Location = new System.Drawing.Point(121, 152);
            this.pbImagenLogin.Name = "pbImagenLogin";
            this.pbImagenLogin.Size = new System.Drawing.Size(34, 40);
            this.pbImagenLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbImagenLogin.TabIndex = 61;
            this.pbImagenLogin.TabStop = false;
            this.pbImagenLogin.Click += new System.EventHandler(this.pbImagenLogin_Click);
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblClave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblClave.Location = new System.Drawing.Point(100, 120);
            this.lblClave.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(69, 16);
            this.lblClave.TabIndex = 58;
            this.lblClave.Text = "Contraseña";
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.Color.White;
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClave.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.Location = new System.Drawing.Point(192, 119);
            this.txtClave.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(177, 20);
            this.txtClave.TabIndex = 2;
            this.txtClave.UseSystemPasswordChar = true;
            this.txtClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClave_KeyPress);
            // 
            // txtDocumento
            // 
            this.txtDocumento.BackColor = System.Drawing.Color.White;
            this.txtDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumento.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumento.Location = new System.Drawing.Point(192, 88);
            this.txtDocumento.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(176, 20);
            this.txtDocumento.TabIndex = 1;
            // 
            // lblDetalle
            // 
            this.lblDetalle.BackColor = System.Drawing.Color.Transparent;
            this.lblDetalle.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.ForeColor = System.Drawing.Color.DimGray;
            this.lblDetalle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDetalle.Location = new System.Drawing.Point(202, 56);
            this.lblDetalle.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(180, 18);
            this.lblDetalle.TabIndex = 27;
            this.lblDetalle.Text = "Autenticación Usuario";
            this.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDocumento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDocumento.Location = new System.Drawing.Point(101, 91);
            this.lblDocumento.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(48, 16);
            this.lblDocumento.TabIndex = 49;
            this.lblDocumento.Text = "Usuario";
            // 
            // gsInicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlAuxiliar);
            this.Name = "gsInicioSesion";
            this.Size = new System.Drawing.Size(450, 221);
            this.pnlAuxiliar.ResumeLayout(false);
            this.pnlAuxiliar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenLogin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAuxiliar;
        private System.Windows.Forms.PictureBox pbImagenLogin;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnLogearse;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.ToolTip Tooltip;
    }
}
