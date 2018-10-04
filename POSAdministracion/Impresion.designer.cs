namespace gasolutions.UInterface
{
    partial class Impresion
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.impresionConsignacion = new gasolutions.UInterface.ImpresionConsignacion();
            this.recuperarConsignacionTransporIdTableAdapter = new gasolutions.UInterface.ImpresionConsignacionTableAdapters.RecuperarConsignacionTransporIdTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.impresionConsignacion)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "RecuperarConsignacionTransporId";
            this.bindingSource1.DataSource = this.impresionConsignacion;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "HadiTerpelFusionColombiaDataSet_RecuperarConsignacionTransporId";
            reportDataSource3.Value = this.bindingSource1;
            reportDataSource4.Name = "ImpresionConsignacion_RecuperarConsignacionTransporId";
            reportDataSource4.Value = this.bindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "gasolutions.UInterface.ConsignacionTransportadora.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(691, 595);
            this.reportViewer1.TabIndex = 0;
            // 
            // impresionConsignacion
            // 
            this.impresionConsignacion.DataSetName = "ImpresionConsignacion";
            this.impresionConsignacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // recuperarConsignacionTransporIdTableAdapter
            // 
            this.recuperarConsignacionTransporIdTableAdapter.ClearBeforeFill = true;
            // 
            // Impresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 595);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Impresion";
            this.Text = "Impresion";
            this.Load += new System.EventHandler(this.Impresion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.impresionConsignacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private ImpresionConsignacion impresionConsignacion;
        private ImpresionConsignacionTableAdapters.RecuperarConsignacionTransporIdTableAdapter recuperarConsignacionTransporIdTableAdapter;
        
       
    }
}