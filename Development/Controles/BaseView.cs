using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace gasolutions.UInterface
{
    public class BaseView : UserControl
    {
        private bool _viewable = true;
        private object _dataSource;

        public BaseView()
        {
            // Initialize
            InitializeComponent();
        }

        #region Public API
        public object DataSource
        {
            get { return _dataSource; }
            set
            {
                _dataSource = value;
                OnSetDataSource(_dataSource);
            }
        }

        public virtual bool Viewable
        {
            get { return _viewable; }
            set
            {
                _viewable = value;

                if (_viewable)
                {
                    // Make visible
                    this.Dock = DockStyle.Fill;
                    this.Visible = true;
                }
                else
                {
                    // Hide
                    this.Visible = false;
                    this.Dock = DockStyle.None;
                    this.Location = new Point(0, 0);
                    this.Size = new Size(100, 100);
                }
            }
        }
        #endregion

        #region Protected API
        protected virtual void OnSetDataSource(object dataSource) { }

        protected override void OnLoad(EventArgs e)
        {
            // Call base
            base.OnLoad(e);
        }
        #endregion

        #region Designer Generated
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseView
            // 
            this.Name = "BaseView";
            this.Size = new System.Drawing.Size(725, 452);
            this.ResumeLayout(false);

        }
        #endregion
    }
}