#region Copyright (c) 2013 Stewart Adcock
//
// Filename: LinearRegression.cs
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

namespace uk.org.adcock.lr
{
  /// <summary>
  /// This class provides a weighted linear regression algorithm, using symmetric matrix inversion to overcome any
  /// non-linearity of the dependent variables and to compute the complete variance-covariance matrix, allowing
  /// estimation of confidence intervals in the determined regression coefficients.
  /// 
  /// Certain statistical measures are automatically calculated as part of the computation, including the Fisher F-statistic.
  /// 
  /// Good general reference:
  /// Draper, N. R. and H. Smith, Applied Regression Analysis, New York: Wiley (1966)
  /// </summary>
  public class LinearRegression
  {
    private double[,] V; // Least squares and variance-covariance matrix
    private double[] C; // Coefficients
    private double[] SEC; // Std Error of coefficients
    private double RYSQ; // Multiple correlation coefficient
    private double SDV; // Standard deviation of errors
    private double FReg; // Fisher F statistic for regression
    private double AUE; // Average unsigned error of calculated values
    private double[] Ycalc; // Calculated values of Y
    private double[] DY; // Residual values of Y

    #region Public methods
    /// <summary>
    /// Regression analysis of the specified Y.
    /// </summary>
    /// <remarks>
    /// A weighted linear regression analysis, using symmetric matrix inversion to overcome any
    /// non-linearity of the dependent variables and to compute the complete variance-covariance matrix, allowing
    /// estimation of confidence intervals in the determined regression coefficients.
    /// </remarks>
    /// <param name="Y">The Y vector (data point values).</param>
    /// <param name="X">The X matrix (dependent variables of each data point).</param>
    /// <param name="W">The W vector (data point weights).</param>
    /// <returns><c>True</c> if regression is successful; Otherwise, <c>false</c>.</returns>
    public bool Regression(double[] Y, double[,] X, double[] W)
    {
      int M = Y.Length; // M = Number of data points

      if (M != W.Length)
      {
        throw new ArgumentException("Length of Y must equal length of W.");
      }

      int N = X.Length / M; // N = Number of linear terms
      int NDF = M - N; // Degrees of freedom
      // If not enough data, don't attempt regression
      if (NDF < 1)
      {
        return false;
      }

      this.Ycalc = new double[M];
      this.DY = new double[M];
      this.V = new double[N, N];
      this.C = new double[N];
      this.SEC = new double[N];
      double[] B = new double[N]; // Vector for LSQ

      // Populate Least Squares Matrix
      for (int i = 0; i < N; i++)
      {
        for (int j = 0; j < N; j++)
        {
          this.V[i, j] = 0;
          for (int k = 0; k < M; k++)
            this.V[i, j] += W[k] * X[i, k] * X[j, k];
        }
        B[i] = 0;
        for (int k = 0; k < M; k++)
          B[i] += W[k] * X[i, k] * Y[k];
      }
      // V now contains the raw least squares matrix
      if (!MatrixMath.SymmetricMatrixInvert(this.V))
      {
        return false;
      }
      // V now contains the inverted least square matrix
      // Matrix multiply to get coefficients C = VB
      for (int i = 0; i < N; i++)
      {
        this.C[i] = 0;
        for (int j = 0; j < N; j++)
          this.C[i] += this.V[i, j] * B[j];
      }

      // Calculate statistics
      double TSS = 0.0;
      double RSS = 0.0;
      double YBAR = 0.0;
      double WSUM = 0.0;
      for (int k = 0; k < M; k++)
      {
        YBAR += W[k] * Y[k];
        WSUM += W[k];
      }
      YBAR /= WSUM;
      this.AUE = 0.0;
      for (int k = 0; k < M; k++)
      {
        this.Ycalc[k] = 0;
        for (int i = 0; i < N; i++)
          this.Ycalc[k] += this.C[i] * X[i, k];
        this.DY[k] = this.Ycalc[k] - Y[k];
        TSS += W[k] * (Y[k] - YBAR) * (Y[k] - YBAR);
        RSS += W[k] * this.DY[k] * this.DY[k];
        this.AUE += this.DY[k];
      }
      this.AUE /= M;
      double SSQ = RSS / NDF;
      this.RYSQ = 1 - RSS / TSS;
      this.FReg = double.MaxValue;
      if (this.RYSQ < 0.9999999)
        this.FReg = this.RYSQ / (1 - this.RYSQ) * NDF / (N - 1);
      this.SDV = Math.Sqrt(SSQ);

      // Calculate variance-covariance matrix and std error of coefficients
      for (int i = 0; i < N; i++)
      {
        for (int j = 0; j < N; j++)
          this.V[i, j] *= SSQ;
        this.SEC[i] = Math.Sqrt(this.V[i, i]);
      }

      return true;
    }
    #endregion

    #region Properties
    public double FisherF
    {
      get { return this.FReg; }
    }

    public double CorrelationCoefficient
    {
      get { return this.RYSQ; }
    }

    public double StandardDeviation
    {
      get { return this.SDV; }
    }

    public double AverageUnsignedError
    {
      get { return this.AUE; }
    }

    public double[] CalculatedValues
    {
      get { return this.Ycalc; }
    }

    public double[] Residuals
    {
      get { return this.DY; }
    }

    public double[] Coefficients
    {
      get { return this.C; }
    }

    public double[] CoefficientsStandardError
    {
      get { return this.SEC; }
    }

    public double[,] VarianceMatrix
    {
      get { return this.V; }
    }
    #endregion

    ////public double RunTest(double[] X)
    ////{
    ////  int NRuns = 1;
    ////  int N1 = 0;
    ////  int N2 = 0;
    ////  if (X[0] > 0)
    ////    N1 = 1;
    ////  else
    ////    N2 = 1;

    ////  for (int k = 1; k < X.Length; k++)
    ////  {
    ////    if (X[k] > 0)
    ////      N1++;
    ////    else
    ////      N2++;
    ////    if (X[k] * X[k - 1] < 0)
    ////      NRuns++;
    ////  }
    ////  return 1;
    ////}
  }
}
