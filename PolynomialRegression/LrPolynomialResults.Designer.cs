namespace uk.org.adcock.lr
{
    partial class LrPolynomialResults
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
      this.grid = new System.Windows.Forms.DataGridView();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.closeButton = new System.Windows.Forms.Button();
      this.fLabel = new System.Windows.Forms.Label();
      this.corrCoLabel = new System.Windows.Forms.Label();
      this.stdevLabel = new System.Windows.Forms.Label();
      this.stdevValueLabel = new System.Windows.Forms.Label();
      this.corrCoValueLabel = new System.Windows.Forms.Label();
      this.fValueLabel = new System.Windows.Forms.Label();
      this.aueValueLabel = new System.Windows.Forms.Label();
      this.aueLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
      this.SuspendLayout();
      // 
      // grid
      // 
      this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
      this.grid.Location = new System.Drawing.Point(12, 12);
      this.grid.Name = "grid";
      this.grid.RowHeadersVisible = false;
      this.grid.Size = new System.Drawing.Size(268, 151);
      this.grid.TabIndex = 0;
      // 
      // Column1
      // 
      this.Column1.HeaderText = "i";
      this.Column1.Name = "Column1";
      this.Column1.Width = 40;
      // 
      // Column2
      // 
      this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Column2.HeaderText = "C";
      this.Column2.Name = "Column2";
      // 
      // Column3
      // 
      this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Column3.HeaderText = "Std Error";
      this.Column3.Name = "Column3";
      // 
      // closeButton
      // 
      this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.closeButton.Location = new System.Drawing.Point(114, 237);
      this.closeButton.Name = "closeButton";
      this.closeButton.Size = new System.Drawing.Size(75, 23);
      this.closeButton.TabIndex = 1;
      this.closeButton.Text = "&Close";
      this.closeButton.UseVisualStyleBackColor = true;
      this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
      // 
      // fLabel
      // 
      this.fLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.fLabel.AutoSize = true;
      this.fLabel.Location = new System.Drawing.Point(9, 166);
      this.fLabel.Name = "fLabel";
      this.fLabel.Size = new System.Drawing.Size(47, 13);
      this.fLabel.TabIndex = 2;
      this.fLabel.Text = "Fisher F:";
      // 
      // corrCoLabel
      // 
      this.corrCoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.corrCoLabel.AutoSize = true;
      this.corrCoLabel.Location = new System.Drawing.Point(9, 179);
      this.corrCoLabel.Name = "corrCoLabel";
      this.corrCoLabel.Size = new System.Drawing.Size(113, 13);
      this.corrCoLabel.TabIndex = 3;
      this.corrCoLabel.Text = "Correlation Coefficient:";
      // 
      // stdevLabel
      // 
      this.stdevLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.stdevLabel.AutoSize = true;
      this.stdevLabel.Location = new System.Drawing.Point(9, 192);
      this.stdevLabel.Name = "stdevLabel";
      this.stdevLabel.Size = new System.Drawing.Size(143, 13);
      this.stdevLabel.TabIndex = 4;
      this.stdevLabel.Text = "Standard Deviation of Errors:";
      // 
      // stdevValueLabel
      // 
      this.stdevValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.stdevValueLabel.AutoSize = true;
      this.stdevValueLabel.Location = new System.Drawing.Point(165, 192);
      this.stdevValueLabel.Name = "stdevValueLabel";
      this.stdevValueLabel.Size = new System.Drawing.Size(19, 13);
      this.stdevValueLabel.TabIndex = 7;
      this.stdevValueLabel.Text = "<>";
      // 
      // corrCoValueLabel
      // 
      this.corrCoValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.corrCoValueLabel.AutoSize = true;
      this.corrCoValueLabel.Location = new System.Drawing.Point(165, 179);
      this.corrCoValueLabel.Name = "corrCoValueLabel";
      this.corrCoValueLabel.Size = new System.Drawing.Size(19, 13);
      this.corrCoValueLabel.TabIndex = 6;
      this.corrCoValueLabel.Text = "<>";
      // 
      // fValueLabel
      // 
      this.fValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.fValueLabel.AutoSize = true;
      this.fValueLabel.Location = new System.Drawing.Point(165, 166);
      this.fValueLabel.Name = "fValueLabel";
      this.fValueLabel.Size = new System.Drawing.Size(19, 13);
      this.fValueLabel.TabIndex = 5;
      this.fValueLabel.Text = "<>";
      // 
      // aueValueLabel
      // 
      this.aueValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.aueValueLabel.AutoSize = true;
      this.aueValueLabel.Location = new System.Drawing.Point(165, 205);
      this.aueValueLabel.Name = "aueValueLabel";
      this.aueValueLabel.Size = new System.Drawing.Size(19, 13);
      this.aueValueLabel.TabIndex = 9;
      this.aueValueLabel.Text = "<>";
      // 
      // aueLabel
      // 
      this.aueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.aueLabel.AutoSize = true;
      this.aueLabel.Location = new System.Drawing.Point(9, 205);
      this.aueLabel.Name = "aueLabel";
      this.aueLabel.Size = new System.Drawing.Size(121, 13);
      this.aueLabel.TabIndex = 8;
      this.aueLabel.Text = "Average Unsigned Error:";
      // 
      // LrPolynomialResults
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 265);
      this.Controls.Add(this.aueValueLabel);
      this.Controls.Add(this.aueLabel);
      this.Controls.Add(this.stdevValueLabel);
      this.Controls.Add(this.corrCoValueLabel);
      this.Controls.Add(this.fValueLabel);
      this.Controls.Add(this.stdevLabel);
      this.Controls.Add(this.corrCoLabel);
      this.Controls.Add(this.fLabel);
      this.Controls.Add(this.closeButton);
      this.Controls.Add(this.grid);
      this.Name = "LrPolynomialResults";
      this.Text = "Regression Results";
      this.Load += new System.EventHandler(this.LrPolynomialResults_Load);
      ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label fLabel;
        private System.Windows.Forms.Label corrCoLabel;
        private System.Windows.Forms.Label stdevLabel;
        private System.Windows.Forms.Label stdevValueLabel;
        private System.Windows.Forms.Label corrCoValueLabel;
        private System.Windows.Forms.Label fValueLabel;
        private System.Windows.Forms.Label aueValueLabel;
        private System.Windows.Forms.Label aueLabel;
    }
}