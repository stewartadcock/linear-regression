using System;
using System.Windows.Forms;

namespace uk.org.adcock.lr
{
  public partial class LrResults : Form
  {
    public double[] C;
    public double[] SEC;
    public double F;
    public double Coeff;
    public double StdDev;
    public double Aue;

    public LrResults()
    {
      InitializeComponent();
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void LrResults_Load(object sender, EventArgs e)
    {
      if (C != null)
      {
        for (int i = 0; i < C.Length; i++)
        {
          int row = grid.Rows.Add();
          grid.Rows[row].Cells[0].Value = i.ToString();
          grid.Rows[row].Cells[1].Value = C[i].ToString();
          grid.Rows[row].Cells[2].Value = SEC[i].ToString();
        }
      }
      this.fValueLabel.Text = this.F.ToString();
      this.corrCoValueLabel.Text = this.Coeff.ToString();
      this.stdevValueLabel.Text = this.StdDev.ToString();
      this.aueValueLabel.Text = this.Aue.ToString();
    }
  }
}