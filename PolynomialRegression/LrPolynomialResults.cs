#region Copyright (c) 2013 Stewart Adcock
//
// Filename: LrPolyniomialResults.cs
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
  public partial class LrPolynomialResults : Form
  {
    public double[] C;
    public double[] SEC;
    public double F;
    public double Coeff;
    public double StdDev;
    public double Aue;

    public LrPolynomialResults()
    {
      InitializeComponent();
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void LrPolynomialResults_Load(object sender, EventArgs e)
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