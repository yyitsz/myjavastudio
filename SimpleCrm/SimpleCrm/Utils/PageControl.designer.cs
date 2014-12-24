
using System;
using DevComponents.DotNetBar;
using DevComponents.Editors;
namespace SimpleCrm.Utils
{
    partial class PageControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblResultStatus = new DevComponents.DotNetBar.LabelX();
            this.btnGo = new DevComponents.DotNetBar.ButtonX();
            this.txtPageNumber = new DevComponents.Editors.IntegerInput();
            this.btnLast = new DevComponents.DotNetBar.ButtonX();
            this.btnFirst = new DevComponents.DotNetBar.ButtonX();
            this.btnPrevious = new DevComponents.DotNetBar.ButtonX();
            this.btnNext = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // lblResultStatus
            // 
            this.lblResultStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResultStatus.AutoSize = true;
            // 
            // 
            // 
            this.lblResultStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblResultStatus.Location = new System.Drawing.Point(0, 5);
            this.lblResultStatus.Name = "lblResultStatus";
            this.lblResultStatus.Size = new System.Drawing.Size(14, 16);
            this.lblResultStatus.TabIndex = 63;
            this.lblResultStatus.Text = "A";
            // 
            // btnGo
            // 
            this.btnGo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGo.Enabled = false;
            this.btnGo.Location = new System.Drawing.Point(272, 0);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(35, 25);
            this.btnGo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtPageNumber
            // 
            // 
            // 
            // 
            this.txtPageNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPageNumber.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtPageNumber.Location = new System.Drawing.Point(307, 0);
            this.txtPageNumber.Name = "txtPageNumber";
            this.txtPageNumber.Size = new System.Drawing.Size(36, 20);
            this.txtPageNumber.TabIndex = 1;
            this.txtPageNumber.ValueChanged += new System.EventHandler(this.txtPageNumber_ValueChanged);
            // 
            // btnLast
            // 
            this.btnLast.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLast.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLast.Image = global::SimpleCrm.Properties.Resources.page_last;
            this.btnLast.Location = new System.Drawing.Point(439, 0);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(32, 25);
            this.btnLast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLast.TabIndex = 5;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFirst.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFirst.Image = global::SimpleCrm.Properties.Resources.page_first;
            this.btnFirst.Location = new System.Drawing.Point(343, 0);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(32, 25);
            this.btnFirst.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFirst.TabIndex = 2;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrevious.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPrevious.Image = global::SimpleCrm.Properties.Resources.page_previous;
            this.btnPrevious.Location = new System.Drawing.Point(375, 0);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(32, 25);
            this.btnPrevious.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPrevious.TabIndex = 3;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNext.Image = global::SimpleCrm.Properties.Resources.page_next;
            this.btnNext.Location = new System.Drawing.Point(407, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(32, 25);
            this.btnNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNext.TabIndex = 4;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // PageControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtPageNumber);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.lblResultStatus);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PageControl";
            this.Size = new System.Drawing.Size(471, 25);
            ((System.ComponentModel.ISupportInitialize)(this.txtPageNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ButtonX btnLast;
        private ButtonX btnFirst;
        private ButtonX btnPrevious;
        private ButtonX btnNext;
        private LabelX lblResultStatus;
        private ButtonX btnGo;
        private IntegerInput txtPageNumber;
    }
}
