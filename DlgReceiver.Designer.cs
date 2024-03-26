using System.ComponentModel;

namespace Expenses
{
    partial class DlgReceiver
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.btnSave = new System.Windows.Forms.Button();
            this.tbRecordReceiver = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRecordPurpose = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPurposeTemplate = new System.Windows.Forms.TextBox();
            this.btnValidate = new System.Windows.Forms.Button();
            this.tbMatchResult = new System.Windows.Forms.TextBox();
            this.chbMatch = new System.Windows.Forms.CheckBox();
            this.lbMasterExpenceType = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPercent = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbOtherPercentage = new System.Windows.Forms.TextBox();
            this.lbOtherExpenceType = new System.Windows.Forms.ListBox();
            this.btnTemplate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(713, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbRecordReceiver
            // 
            this.tbRecordReceiver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRecordReceiver.Location = new System.Drawing.Point(118, 12);
            this.tbRecordReceiver.Name = "tbRecordReceiver";
            this.tbRecordReceiver.ReadOnly = true;
            this.tbRecordReceiver.Size = new System.Drawing.Size(670, 20);
            this.tbRecordReceiver.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Record receiver";
            // 
            // tbRecordPurpose
            // 
            this.tbRecordPurpose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRecordPurpose.Location = new System.Drawing.Point(118, 38);
            this.tbRecordPurpose.Name = "tbRecordPurpose";
            this.tbRecordPurpose.ReadOnly = true;
            this.tbRecordPurpose.Size = new System.Drawing.Size(670, 20);
            this.tbRecordPurpose.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Record purpose";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(118, 64);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(670, 20);
            this.tbName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Template";
            // 
            // tbPurposeTemplate
            // 
            this.tbPurposeTemplate.Location = new System.Drawing.Point(118, 90);
            this.tbPurposeTemplate.Name = "tbPurposeTemplate";
            this.tbPurposeTemplate.Size = new System.Drawing.Size(670, 20);
            this.tbPurposeTemplate.TabIndex = 8;
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(118, 116);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 9;
            this.btnValidate.Text = "Validate template";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // tbMatchResult
            // 
            this.tbMatchResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMatchResult.Location = new System.Drawing.Point(199, 118);
            this.tbMatchResult.Name = "tbMatchResult";
            this.tbMatchResult.ReadOnly = true;
            this.tbMatchResult.Size = new System.Drawing.Size(527, 20);
            this.tbMatchResult.TabIndex = 10;
            this.tbMatchResult.TabStop = false;
            // 
            // chbMatch
            // 
            this.chbMatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbMatch.Enabled = false;
            this.chbMatch.Location = new System.Drawing.Point(732, 118);
            this.chbMatch.Name = "chbMatch";
            this.chbMatch.Size = new System.Drawing.Size(56, 24);
            this.chbMatch.TabIndex = 11;
            this.chbMatch.TabStop = false;
            this.chbMatch.Text = "Match";
            this.chbMatch.UseVisualStyleBackColor = true;
            // 
            // lbMasterExpenceType
            // 
            this.lbMasterExpenceType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMasterExpenceType.DisplayMember = "Name";
            this.lbMasterExpenceType.FormattingEnabled = true;
            this.lbMasterExpenceType.Location = new System.Drawing.Point(6, 19);
            this.lbMasterExpenceType.Name = "lbMasterExpenceType";
            this.lbMasterExpenceType.Size = new System.Drawing.Size(237, 199);
            this.lbMasterExpenceType.TabIndex = 13;
            this.lbMasterExpenceType.ValueMember = "Id";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbPercent);
            this.groupBox1.Controls.Add(this.lbMasterExpenceType);
            this.groupBox1.Location = new System.Drawing.Point(12, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 262);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Master expence";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(6, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Percentage";
            // 
            // tbPercent
            // 
            this.tbPercent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPercent.Location = new System.Drawing.Point(73, 236);
            this.tbPercent.Name = "tbPercent";
            this.tbPercent.Size = new System.Drawing.Size(170, 20);
            this.tbPercent.TabIndex = 14;
            this.tbPercent.Text = "100";
            this.tbPercent.TextChanged += new System.EventHandler(this.tbPercent_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbOtherPercentage);
            this.groupBox2.Controls.Add(this.lbOtherExpenceType);
            this.groupBox2.Location = new System.Drawing.Point(277, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 262);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Other expence";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(6, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "Percentage";
            // 
            // tbOtherPercentage
            // 
            this.tbOtherPercentage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOtherPercentage.Location = new System.Drawing.Point(78, 236);
            this.tbOtherPercentage.Name = "tbOtherPercentage";
            this.tbOtherPercentage.ReadOnly = true;
            this.tbOtherPercentage.Size = new System.Drawing.Size(160, 20);
            this.tbOtherPercentage.TabIndex = 1;
            // 
            // lbOtherExpenceType
            // 
            this.lbOtherExpenceType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOtherExpenceType.DisplayMember = "Name";
            this.lbOtherExpenceType.FormattingEnabled = true;
            this.lbOtherExpenceType.Location = new System.Drawing.Point(6, 19);
            this.lbOtherExpenceType.Name = "lbOtherExpenceType";
            this.lbOtherExpenceType.Size = new System.Drawing.Size(232, 199);
            this.lbOtherExpenceType.TabIndex = 0;
            this.lbOtherExpenceType.ValueMember = "Id";
            // 
            // btnTemplate
            // 
            this.btnTemplate.Location = new System.Drawing.Point(77, 88);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(35, 23);
            this.btnTemplate.TabIndex = 16;
            this.btnTemplate.Text = "T->";
            this.btnTemplate.UseVisualStyleBackColor = true;
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // DlgReceiver
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btnTemplate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chbMatch);
            this.Controls.Add(this.tbMatchResult);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.tbPurposeTemplate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbRecordPurpose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbRecordReceiver);
            this.Controls.Add(this.btnSave);
            this.Name = "DlgReceiver";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receiver";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnTemplate;

        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.TextBox tbOtherPercentage;

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbOtherExpenceType;

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.TextBox tbPercent;

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.ListBox lbMasterExpenceType;

        private System.Windows.Forms.CheckBox chbMatch;

        private System.Windows.Forms.TextBox tbMatchResult;

        private System.Windows.Forms.Button btnValidate;

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPurposeTemplate;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;

        private System.Windows.Forms.TextBox tbRecordPurpose;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox tbRecordReceiver;

        private System.Windows.Forms.Button btnSave;

        #endregion
    }
}