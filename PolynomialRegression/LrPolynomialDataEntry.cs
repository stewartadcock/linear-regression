using System;
using System.Windows.Forms;

namespace uk.org.adcock.lr
{
  public partial class LrPolynomialDataEntry : Form
  {
    public LrPolynomialDataEntry()
    {
      InitializeComponent();
    }

    private void fitButton_Click(object sender, EventArgs e)
    {
      int N = (int)orderNumericUpDown.Value;
      double[] y = new double[grid.Rows.Count - 1];
      double[,] x = new double[N + 1, grid.Rows.Count - 1];
      double[] w = new double[grid.Rows.Count - 1];
      for (int i = 0; i < grid.Rows.Count - 1; i++)
      {
        if (grid.Rows[i].Cells[0].Value != null)
        {
          x[0, i] = 1;
          double xx = double.Parse(grid.Rows[i].Cells[2].Value.ToString());
          double term = xx;
          for (int j = 1; j <= N; j++)
          {
            x[j, i] = term;
            term *= xx;
          }
          if (logYCheckBox.Checked)
          {
            y[i] = Math.Log(double.Parse(grid.Rows[i].Cells[3].Value.ToString()));
          }
          else
          {
            y[i] = double.Parse(grid.Rows[i].Cells[3].Value.ToString());
          }
          w[i] = double.Parse(grid.Rows[i].Cells[1].Value.ToString());
        }
      }

      LinearRegression linReg = new LinearRegression();
      linReg.Regression(y, x, w);
      LrResults form = new LrResults();
      form.C = linReg.Coefficients;
      form.SEC = linReg.CoefficientsStandardError;
      form.F = linReg.FisherF;
      form.Coeff = linReg.CorrelationCoefficient;
      form.StdDev = linReg.StandardDeviation;
      form.Aue = linReg.AverageUnsignedError;
      form.ShowDialog();
    }

    private void LrPolynomialDataEntry_Load(object sender, EventArgs e)
    {
      UpdateGrid();
    }

    private void UpdateGrid()
    {
      Random r = new Random();
      for (int i = 0; i < 20; i++)
      {
        int row = grid.Rows.Add();
        grid.Rows[row].Cells[0].Value = i.ToString();
        grid.Rows[row].Cells[1].Value = "1";
        grid.Rows[row].Cells[2].Value = (i / 10.0).ToString();
        grid.Rows[row].Cells[3].Value = (4.0 + 3.0 * i / 10.0 + r.NextDouble() / 10.0).ToString();
      }
    }

    private void logYCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      for (int r = 0; r < grid.Rows.Count - 1; r++)
      {
        if (logYCheckBox.Checked)
        {
          double x = double.Parse(grid.Rows[r].Cells[3].Value.ToString());
          grid.Rows[r].Cells[1].Value = (x * x).ToString();
        }
        else
        {
          grid.Rows[r].Cells[1].Value = "1";
        }
      }
    }
  }
}