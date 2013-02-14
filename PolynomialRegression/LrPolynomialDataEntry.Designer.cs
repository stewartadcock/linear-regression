namespace Uk.Org.Adcock.Lr
{
  partial class LrPolynomialDataEntry
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
      this.fitButton = new System.Windows.Forms.Button();
      this.grid = new System.Windows.Forms.DataGridView();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.logYCheckBox = new System.Windows.Forms.CheckBox();
      this.label1 = new System.Windows.Forms.Label();
      this.orderNumericUpDown = new System.Windows.Forms.NumericUpDown();
      ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.orderNumericUpDown)).BeginInit();
      this.SuspendLayout();
      // 
      // fitButton
      // 
      this.fitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.fitButton.Location = new System.Drawing.Point(105, 238);
      this.fitButton.Name = "fitButton";
      this.fitButton.Size = new System.Drawing.Size(75, 23);
      this.fitButton.TabIndex = 0;
      this.fitButton.Text = "Fit";
      this.fitButton.UseVisualStyleBackColor = true;
      this.fitButton.Click += new System.EventHandler(this.fitButton_Click);
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
            this.Column3,
            this.Column4});
      this.grid.Location = new System.Drawing.Point(12, 43);
      this.grid.Name = "grid";
      this.grid.Size = new System.Drawing.Size(268, 189);
      this.grid.TabIndex = 1;
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
      this.Column2.HeaderText = "Weight";
      this.Column2.Name = "Column2";
      // 
      // Column3
      // 
      this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Column3.HeaderText = "X";
      this.Column3.Name = "Column3";
      // 
      // Column4
      // 
      this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Column4.HeaderText = "Y";
      this.Column4.Name = "Column4";
      // 
      // logYCheckBox
      // 
      this.logYCheckBox.AutoSize = true;
      this.logYCheckBox.Location = new System.Drawing.Point(12, 20);
      this.logYCheckBox.Name = "logYCheckBox";
      this.logYCheckBox.Size = new System.Drawing.Size(79, 17);
      this.logYCheckBox.TabIndex = 2;
      this.logYCheckBox.Text = "Use Log(Y)";
      this.logYCheckBox.UseVisualStyleBackColor = true;
      this.logYCheckBox.CheckedChanged += new System.EventHandler(this.logYCheckBox_CheckedChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(112, 21);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(89, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Polynomial Order:";
      // 
      // orderNumericUpDown
      // 
      this.orderNumericUpDown.Location = new System.Drawing.Point(217, 19);
      this.orderNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.orderNumericUpDown.Name = "orderNumericUpDown";
      this.orderNumericUpDown.Size = new System.Drawing.Size(63, 20);
      this.orderNumericUpDown.TabIndex = 4;
      this.orderNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
      // 
      // LrPolynomialDataEntry
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 265);
      this.Controls.Add(this.orderNumericUpDown);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.logYCheckBox);
      this.Controls.Add(this.grid);
      this.Controls.Add(this.fitButton);
      this.Name = "LrPolynomialDataEntry";
      this.Text = "Regression Data Entry";
      this.Load += new System.EventHandler(this.LrPolynomialDataEntry_Load);
      ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.orderNumericUpDown)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button fitButton;
    private System.Windows.Forms.DataGridView grid;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    private System.Windows.Forms.CheckBox logYCheckBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown orderNumericUpDown;
  }
}

