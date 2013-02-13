#region Copyright (c) 2013 Stewart Adcock
//
// Filename: LrPolyniomialDataEntry.cs
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
      LrPolynomialResults form = new LrPolynomialResults();
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