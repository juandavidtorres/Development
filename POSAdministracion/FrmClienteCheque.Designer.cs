namespace gasolutions.UInterface
{
    partial class FrmClienteCheque
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
            this.gsAgregarCheque = new gasolutions.UInterface.gsAgregarMontoCheque();
            this.SuspendLayout();
            // 
            // gsAgregarCheque
            // 
            this.gsAgregarCheque.BackColor = System.Drawing.Color.White;
            this.gsAgregarCheque.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gsAgregarCheque.Location = new System.Drawing.Point(1, 2);
            this.gsAgregarCheque.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gsAgregarCheque.Name = "gsAgregarCheque";
            this.gsAgregarCheque.Size = new System.Drawing.Size(442, 524);
            this.gsAgregarCheque.TabIndex = 0;
            // 
            // FrmClienteCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(443, 534);
            this.Controls.Add(this.gsAgregarCheque);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmClienteCheque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmClienteCheque_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private gsAgregarMontoCheque gsAgregarCheque;
    }
}