using System;
using NUnit.Framework;

namespace Polynomials.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        [TestCase(83, 7, 8, 9, 3, 0)]
        [TestCase(6, 2, 2)]
        [TestCase(4, 0, 2)]
        [TestCase(2, 2, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(10, 2, 4)]
        [TestCase(-6, 2, -4)]
        [TestCase(-14, -2, -2, -2)]
        [TestCase(-4, 0, 2, -2)]
        [TestCase(6, -2, 0, 2)]
        [TestCase(-8, 0, 0, -2)]
        [TestCase(0, 0, 0, 0)]
        [TestCase(2, 2, -4, 2)]
        [TestCase(81, 1, -2, 3, 5, 2)]
        [TestCase(144, 2, 5, 1, -2, 3, 3)]
        [TestCase(160, 0, 0, 0, 0, 0, 5)]
        [TestCase(27, 3, 4, 0, 2)]
        [TestCase(0, 0, 0, 0, 0, 0)]
        public void Calculate_Value2_PositiveResults (double expected, params double[] coefficients)
        {
            double value = 2;
            var polynomial = new Polynomial(coefficients);
            Assert.AreEqual(expected, polynomial.Calculate(value));
        }

        [TestCase(2.95, 1.25, 5.2, -7.6, 8)]
        [TestCase(0, 0, 0, 0, 0, 0)]
        public void Calculate_Value0_5_PositiveResults(double expected, params double[] coefficients)
        {
            double value = 0.5;
            var polynomial = new Polynomial(coefficients);
            Assert.AreEqual(expected, polynomial.Calculate(value));
        }

        [TestCase(297, new double[] { 1, -2, 3, 4 }, new double[] { 0, 0, 0 }, 4)]
        [TestCase(215, new double[] { 0, 0 }, new double[] { 2, 5, 1, -2, 3 }, 3)]
        [TestCase(0, new double[] { 1, 2, 3, 5 }, new double[] { -1, -2, -3, -5 }, 6)]
        [TestCase(1, new double[] { 5, 2, 3, 5 }, new double[] { -4, -2, -3, -5 }, 7)]
        [TestCase(15, new double[] { 6 }, new double[] { 1, -2, 3 }, 2)]
        public void AddAndCalculate_TwoPolynomials_PositiveResult(double expected, double[] coefficients1, double[] coefficients2, double value)
        {
            Assert.AreEqual(expected, (new Polynomial(coefficients1) + new Polynomial(coefficients2)).Calculate(value));
        }

        [TestCase(9, new double[] { 1, -2, 3 }, new double[] { 0, 0, 0 }, 2)]
        [TestCase(-32, new double[] { 1, -2, -3 }, new double[] { 0, 0, 0 }, 3)]
        [TestCase(-678, new double[] { 0, 0, 0 }, new double[] { 2, 5, 1, -2, 3 }, 4)]
        [TestCase(23.75, new double[] { 9, 15 }, new double[] { 1, -2, 3 }, 4.5)]
        [TestCase(0, new double[] { 1, 2, 3, 5 }, new double[] { 1, 2, 3, 5 }, 5)]
        [TestCase(-1, new double[] { 1, 2, 3, 5 }, new double[] { 2, 2, 3, 5 }, 6)]
        public void SubstractAndCalculate_TwoPolynomials_PositiveResult(double expected, double[] coefficients1, double[] coefficients2, double value)
        {
            Assert.AreEqual(expected, (new Polynomial(coefficients1) - new Polynomial(coefficients2)).Calculate(value));
        }

        [TestCase(0, new double[] { 1, -2, 3, 4 }, new double[] { 0, 0, 0 }, 2)]
        [TestCase(0, new double[] { 0, 0, 0 }, new double[] { 2, 5, 1, -2, 3 }, 3)]
        [TestCase(2712, new double[] { 0, 1, 0 }, new double[] { 2, 5, 1, -2, 3 }, 4)]
        [TestCase(7326, new double[] { 6, 21 }, new double[] { 1, -2, 3 }, 5)]
        public void MultiplyAndCalculate_TwoPolynomials_PositiveResult(double expected, double[] coefficients1, double[] coefficients2, double value)
        {
            Assert.AreEqual(expected, (new Polynomial(coefficients1) * new Polynomial(coefficients2)).Calculate(value));
        }

        [TestCase(false, new double[] { 1, -2, 3 }, new double[] { 0, 0, 0 })]
        [TestCase(true, new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 })]
        [TestCase(true, new double[] { 0, 0, 0 }, new double[] { 0, 0 })]
        [TestCase(true, new double[] { 1, -2, 3 }, new double[] { 1, -2, 3 })]
        public void OperatorEqual_CompareTwoPolynomials(bool expected, double[] coefficients1, double[] coefficients2)
        {
            Assert.AreEqual(expected, new Polynomial(coefficients1) == new Polynomial(coefficients2));
        }

        [TestCase(true, new double[] { 1, -2, 3 }, new double[] { 0, 0, 0 })]
        [TestCase(true, new double[] { 0, 0 }, new double[] { 2, 5, 1, -2, 3 })]
        [TestCase(false, new double[] { 1, -2, 3 }, new double[] { 1, -2, 3 })]
        public void OperatorNotEqual_CompareTwoPolynomials(bool expected, double[] coefficients1, double[] coefficients2)
        {
            Assert.AreEqual(expected, new Polynomial(coefficients1) != new Polynomial(coefficients2));
        }

        [TestCase(new double[] { })]
        public void Constructor_EmptyArray_ThrowsArgumentException(double[] coefficients)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Polynomial(coefficients));
        }

        [TestCase(null, null)]
        [TestCase(null, new double[] { 1, -2, 3 })]
        [TestCase(new double[] { 1, -2, 3 }, null)]
        public void OperatorAdd_OneOfArrayIsNull_ThrowsArgumentNullException(double[] coefficients1, double[] coefficients2)
        {
            Polynomial polynomial1 = null;
            Polynomial polynomial2 = null;
            if (coefficients1 != null) polynomial1 = new Polynomial(coefficients1);
            if (coefficients2 != null) polynomial2 = new Polynomial(coefficients2);

            Assert.Throws<ArgumentNullException>(() => polynomial1 = polynomial1 + polynomial2);
        }

        [TestCase(null, null)]
        [TestCase(null, new double[] { 1, -2, 3 })]
        [TestCase(new double[] { 1, -2, 3 }, null)]
        public void OperatorSub_OneOfArgumetsIsNull_ThrowsArgumentNullException(double[] coefficients1, double[] coefficients2)
        {
            Polynomial polynomial1 = null;
            Polynomial polynomial2 = null;
            if (coefficients1 != null) polynomial1 = new Polynomial(coefficients1);
            if (coefficients2 != null) polynomial2 = new Polynomial(coefficients2);

            Assert.Throws<ArgumentNullException>(() => polynomial1 = polynomial1 - polynomial2);
        }

        [TestCase(null, null)]
        [TestCase(null, new double[] { 1, -2, 3 })]
        [TestCase(new double[] { 1, -2, 3 }, null)]
        public void OperatorMul_OneOfArgumetsIsNull_ThrowsArgumentNullException(double[] coefficients1, double[] coefficients2)
        {
            Polynomial polynomial1 = null;
            Polynomial polynomial2 = null;
            if (coefficients1 != null) polynomial1 = new Polynomial(coefficients1);
            if (coefficients2 != null) polynomial2 = new Polynomial(coefficients2);

            Assert.Throws<ArgumentNullException>(() => polynomial1 = polynomial1 * polynomial2);
        }

        [TestCase(false, new double[] { 1, -2, 3 }, null)]
        [TestCase(false, new double[] { 1, -2, 3 }, new double[] { 0, 0, 0 })]
        [TestCase(false, new double[] { 0, 0 }, new double[] { 2, 5, 1, -2, 3 })]
        [TestCase(true, new double[] { 1, -2, 3 }, new double[] { 1, -2, 3 })]
        public void Equals_TwoPolynomials_ComparePolynomials(bool expected, double[] coefficients1, double[] coefficients2)
        {
            Polynomial polynomial1 = null;
            Polynomial polynomial2 = null;
            if (coefficients1 != null) polynomial1 = new Polynomial(coefficients1);
            if (coefficients2 != null) polynomial2 = new Polynomial(coefficients2);

            Assert.AreEqual(expected, polynomial1.Equals(polynomial2));
        }

        [TestCase(false, new double[] { 1, -2, 3 }, null)]
        [TestCase(false, new double[] { 1, -2, 3 }, new double[] { 0, 0, 0 })]
        [TestCase(false, new double[] { 0, 0 }, new double[] { 2, 5, 1, -2, 3 })]
        [TestCase(true, new double[] { 1, -2, 3 }, new double[] { 1, -2, 3 })]
        public void Equals_TwoObjects_ComparePolynomials(bool expected, double[] coefficients1, double[] coefficients2)
        {
            Polynomial polynomial1 = null;
            Polynomial polynomial2 = null;
            if (coefficients1 != null) polynomial1 = new Polynomial(coefficients1);
            if (coefficients2 != null) polynomial2 = new Polynomial(coefficients2);

            object objPol1 = polynomial1;
            object onjPol2 = polynomial2;

            Assert.AreEqual(expected, objPol1.Equals(onjPol2));
        }

    }
}
