#region Copyright (c) 2013 Stewart Adcock
//
// Filename: LinearRegression.cs
//
// This file is used under the terms of the 2-clause BSD license:
//
// Copyright (c) 2013, Stewart A. Adcock
// Parts Copyright (c) 2008 Walt Fair, Jr. used under terms of CPOL 1.02, see license file.
// All rights reserved.
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
  /// General Maths-based utility methods.
  /// </summary>
  public static class MatrixMath
  {
    /// <summary>
    /// Inverts a symmetric matrix.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns><c>True</c> if inversion successful; Otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentException">Thrown if input matrix is not square.</exception>
    public static bool SymmetricMatrixInvert(double[,] matrix)
    {
      int N = matrix.GetLength(0);
      if (Math.Sqrt(matrix.Length) != N)
      {
        throw new ArgumentException("The input matrix must be square.", "matrix");
      }

      double[] t = new double[N];
      double[] Q = new double[N];
      double[] R = new double[N];

      // Invert a symmetric matrix in V
      for (int M = 0; M < N; M++)
        R[M] = 1;
      int K = 0;
      for (int M = 0; M < N; M++)
      {
        double Big = 0;
        for (int L = 0; L < N; L++)
        {
          double AB = Math.Abs(matrix[L, L]);
          if ((AB > Big) && (R[L] != 0))
          {
            Big = AB;
            K = L;
          }
        }
        if (Big == 0)
        {
          return false;
        }
        R[K] = 0;
        Q[K] = 1 / matrix[K, K];
        t[K] = 1;
        matrix[K, K] = 0;
        if (K != 0)
        {
          for (int L = 0; L < K; L++)
          {
            t[L] = matrix[L, K];
            if (R[L] == 0)
              Q[L] = matrix[L, K] * Q[K];
            else
              Q[L] = -matrix[L, K] * Q[K];
            matrix[L, K] = 0;
          }
        }
        if (K <= N)
        {
          for (int L = K + 1; L < N; L++)
          {
            if (R[L] != 0)
              t[L] = matrix[K, L];
            else
              t[L] = -matrix[K, L];
            Q[L] = -matrix[K, L] * Q[K];
            matrix[K, L] = 0;
          }
        }
        for (int L = 0; L < N; L++)
          for (K = L; K < N; K++)
            matrix[L, K] += t[L] * Q[K];
      }
      int m = N;
      for (K = 1; K < N; K++)
      {
        m--;
        for (int J = 0; J < m; J++)
          matrix[m, J] = matrix[J, m];
      }
      return true;
    }
  }
}
