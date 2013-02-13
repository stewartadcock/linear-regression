#region Copyright (c) 2013 Stewart Adcock
//
// Filename: LrMultivariateDataEntry.cs
//
// Copyright (c) 2013, Stewart A. Adcock
// Parts Copyright (c) 2008 Walt Fair, Jr. used under terms of CPOL 1.02, see License file.
// All rights reserved.
//
// The latest version will be available at https://code.google.com/p/linear-regression/
//
// This file is provided under the terms of the 2-clause BSD license:
//
// Redistribution and use in source and binary forms, with or without modification, are
// permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, this list
//      of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, this
//      list of conditions and the following disclaimer in the documentation and/or other
//      materials provided with the distribution.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY
// EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
// OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT
// SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
// PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT,
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF
// THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// Revision History
// Version  date        author      changes
// 1.0      2013-02-12  Stewart     Initial version, based on http://www.codeproject.com/Articles/25335/An-Algorithm-for-Weighted-Linear-Regression.
//
#endregion

using System;
using System.Windows.Forms;

namespace uk.org.adcock.lr
{
  public partial class LrMultivariateDataEntry : Form
  {
    public LrMultivariateDataEntry()
    {
      InitializeComponent();
    }

    private void fitButton_Click(object sender, EventArgs e)
    {
      int N = (int)variablesNumericUpDown.Value;
      double[] y = new double[grid.Rows.Count - 1];
      double[,] x = new double[N + 1, grid.Rows.Count - 1];
      double[] w = new double[grid.Rows.Count - 1];
      for (int i = 0; i < grid.Rows.Count - 1; i++)
      {
        if (grid.Rows[i].Cells[0].Value != null)
        {
          x[0, i] = 1;
          for (int j = 0; j < N; j++)
          {
            double term = double.Parse(grid.Rows[i].Cells[j+2].Value.ToString());
            x[j+1, i] = term;
          }
          if (logYCheckBox.Checked)
          {
            y[i] = Math.Log(double.Parse(grid.Rows[i].Cells[N+2].Value.ToString()));
          }
          else
          {
            y[i] = double.Parse(grid.Rows[i].Cells[N+2].Value.ToString());
          }
          w[i] = double.Parse(grid.Rows[i].Cells[1].Value.ToString());
        }
      }

      LinearRegression linReg = new LinearRegression();
      linReg.Regression(y, x, w);
      LrMultivariateResults form = new LrMultivariateResults();
      form.C = linReg.Coefficients;
      form.SEC = linReg.CoefficientsStandardError;
      form.F = linReg.FisherF;
      form.Coeff = linReg.CorrelationCoefficient;
      form.StdDev = linReg.StandardDeviation;
      form.Aue = linReg.AverageUnsignedError;
      form.ShowDialog();
    }

    private void LrMultivariateDataEntry_Load(object sender, EventArgs e)
    {
      UpdateGrid();
    }

    private void UpdateGrid()
    {
      Random r = new Random();
      int N = (int)variablesNumericUpDown.Value;

      grid.Rows.Clear();
      grid.Columns.Clear();

      grid.Columns.Add("i", "i");
      grid.Columns.Add("Weight", "Weight");
      for (int c = 0; c < N; c++)
        grid.Columns.Add("X" + (c + 1).ToString(), "X" + (c + 1).ToString());
      grid.Columns.Add("Y", "Y");
      for (int c = 0; c < N + 3; c++)
        grid.Columns[c].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

      for (int i = 0; i < 20; i++)
      {
        int row = grid.Rows.Add();
        grid.Rows[row].Cells[0].Value = i.ToString();
        grid.Rows[row].Cells[1].Value = "1";
        for (int c = 0; c < N; c++)
        {
          grid.Rows[row].Cells[2+c].Value = (2.0 * i / (5.0 + c)).ToString();
        }
        grid.Rows[row].Cells[N+2].Value = (5.0 + 2.0 * i / 10.0 + r.NextDouble() / 5.0).ToString();
      }

      grid.Invalidate();
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

    private void variablesNumericUpDown_ValueChanged(object sender, EventArgs e)
    {
      UpdateGrid();
    }
  }
}