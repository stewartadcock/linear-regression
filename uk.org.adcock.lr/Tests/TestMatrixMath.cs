#region Copyright (c) 2013 Stewart Adcock
//
// Filename: TestMatrixMath.cs
//
// This file is used under the terms of the 2-clause BSD license:
//
// Copyright (c) 2013, Stewart A. Adcock
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
// 1.0      2013-02-12  Stewart     Test MatrixMath class.
//
#endregion

using System;

using uk.org.adcock.lr;

using NUnit.Framework;

namespace Fr.Fc.FcCore.Tests
{
  /// <summary>
  /// Tests the MatrixMath class
  /// </summary>
  [TestFixture]
  public class TestMatrixMath
  {
    /// <summary>
    /// Tests the SymmetricMatrixInvert method.
    /// </summary>
    [Test]
    [ExpectedException(typeof(ArgumentException))]
    public void TestSymmetricMatrixInvertNonSquareMatrixThrowsArgumentException()
    {
      double[,] matrix = new double[2, 4];
      
      Assert.Throws<ArgumentException>(() => {MatrixMath.SymmetricMatrixInvert(matrix);});
    }

    /// <summary>
    /// Tests the SymmetricMatrixInvert method.
    /// </summary>
    [Test]
    public void TestSymmetricMatrixInvertSuccessReturnsTrue()
    {
      double[,] matrix = new double[3, 3] {
        {1.0, 2.0, 2.0},
        {2.0, 1.0, 2.0},
        {2.0, 2.0, 1.0}
       };
      Assert.IsTrue(MatrixMath.SymmetricMatrixInvert(matrix));
    }

    /// <summary>
    /// Tests the SymmetricMatrixInvert method.
    /// </summary>
    [Test]
    public void TestSymmetricMatrixInvertFailReturnsFalse()
    {
      double[,] matrix = new double[3, 3] {
        {0.0, 0.0, 0.0},
        {0.0, 0.0, 0.0},
        {0.0, 0.0, 0.0}
       };
      Assert.IsFalse(MatrixMath.SymmetricMatrixInvert(matrix));
    }

    /// <summary>
    /// Tests the SymmetricMatrixInvert method.
    /// </summary>
    [Test]
    public void TestSymmetricMatrixInvertSimpleSample()
    {
      double[,] matrix = new double[3, 3] {
        {1.0, 2.0, 2.0},
        {2.0, 1.0, 2.0},
        {2.0, 2.0, 1.0}
       };
      double[,] expected = new double[3, 3] {
        {-0.6, 0.4, 0.4},
        {0.4, -0.6, 0.4},
        {0.4, 0.4, -0.6}
       };
      Assert.IsTrue(MatrixMath.SymmetricMatrixInvert(matrix));
      for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
          Assert.AreEqual(expected[i, j], matrix[i, j], 0.01, "Element " + i + ", " + j + " is wrong.");
    }
  }
}

