using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Globalization;

namespace Polynomials
{
    public class Polynomial : ICloneable
    {
        #region Private members
        private double[] _coefficients;
        private const double _epsilon = 0.000000001;
        private int _degree;

        /// <summary>
        /// Constructor for creating new Polynomial object with given coefficients
        /// </summary>
        /// <param name="coefficients">Polynomial's coefficients</param>
        public Polynomial(params double[] coefficients)
        {
            if (ReferenceEquals(coefficients, null))
                throw new ArgumentNullException("Referense of array of coefficients is null.");

            if (coefficients.Length == 0)
                throw new ArgumentOutOfRangeException("Array of coefficients is empty.");

            _degree = coefficients.Length - 1;
            while (Math.Abs(coefficients[_degree]) < _epsilon && _degree > 0)
            {
                _degree--;
            }

            _coefficients = new double[_degree + 1];
            Array.Copy(coefficients, _coefficients, _degree + 1);
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Calculates the result of the expression for variable
        /// </summary>
        /// <param name="value">Source variable to calculate the result of the polynomial expression</param>
        /// <returns>The result of the expression</returns>
        public double Calculate(double value)
        {
            int n = _coefficients.Length - 1;
            double result = _coefficients[n];
            for (int i = n - 1; i >= 0; i--)
            {
                if (Math.Abs(_coefficients[i]) < _epsilon)
                    result = value * result + 0;
                else
                    result = value * result + _coefficients[i];
            }
            return result;
        }

        /// <summary>
        /// Adds two polynomials
        /// </summary>
        /// <param name="lhs">First polynomial</param>
        /// <param name="rhs">Second polynomial</param>
        /// <returns>Sum of polynomials</returns>
        public static Polynomial Add(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
                throw new ArgumentNullException("One of references is null.");

            if (lhs._coefficients.Length >= rhs._coefficients.Length)
            {
                double[] newCoefficients = new double[lhs._coefficients.Length];
                Array.Copy(lhs._coefficients, newCoefficients, lhs._coefficients.Length);
                for (int i = 0; i < rhs._coefficients.Length; i++)
                {
                    newCoefficients[i] += rhs._coefficients[i];
                }
                return new Polynomial(newCoefficients);
            }
            else
            {
                double[] newCoefficients = new double[rhs._coefficients.Length];
                Array.Copy(rhs._coefficients, newCoefficients, rhs._coefficients.Length);
                for (int i = 0; i < lhs._coefficients.Length; i++)
                {
                    newCoefficients[i] += lhs._coefficients[i];
                }
                return new Polynomial(newCoefficients);
            }
        }

        /// <summary>
        /// Calculates the negation of the polynomial
        /// </summary>
        /// <param name="value">Source polynomial</param>
        /// <returns>The negation of the polynomial</returns>
        public static Polynomial Negation(Polynomial value)
        {
            if (ReferenceEquals(value, null)) throw new ArgumentNullException("Value is null.");

            double[] newCoefficients = new double[value._degree + 1];
            for (int i = 0; i < newCoefficients.Length; i++)
                newCoefficients[i] = -value._coefficients[i];
            return new Polynomial(newCoefficients);
        }

        /// <summary>
        /// Calculates the substraction of two polynomials
        /// </summary>
        /// <param name="lhs">First polynomial</param>
        /// <param name="rhs">Second polynomial</param>
        /// <returns>Substraction of polynomials</returns>
        public static Polynomial Sub(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) throw new ArgumentNullException("One of references is null.");

            return Add(lhs, Negation(rhs));
        }

        /// <summary>
        /// Mutliplies two polynomials
        /// </summary>
        /// <param name="lhs">First polynomial</param>
        /// <param name="rhs">Second polynomial</param>
        /// <returns>Multiplication of polynomials</returns>
        public static Polynomial Mul(Polynomial lhs, Polynomial rhs)
        {
            if (lhs == null || rhs == null) throw new ArgumentNullException("One of polynomials is null.");
            int tempDegree = lhs._degree + rhs._degree;
            double[] newPolynomial = new double[tempDegree + 1];
            for (int i = lhs._degree; i >= 0; i--)
                for (int j = rhs._degree; j >= 0; j--)
                    newPolynomial[i + j] += lhs._coefficients[i] * rhs._coefficients[j];

            return new Polynomial(newPolynomial);
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance
        /// </summary>
        /// <returns>New object that is a copy of the current instance</returns>
        object ICloneable.Clone() => MemberwiseClone();

        /// <summary>
        /// Creates a new polynomial that is a copy of the current Polynomial.
        /// </summary>
        /// <returns>New polynomial that is a copy of the current Polynomial.</returns>
        public Polynomial Clone() => new Polynomial(_coefficients);

        #region Overloaded Object's methods
        /// <summary>
        /// Determines whether the specified object is equal to the current object
        /// </summary>
        /// <param name="obj">The object to compare with the current object</param>
        /// <returns>True if the specified object is equal to the current Polynomial object. Otherwise, false</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((Polynomial)obj);
        }
        /// <summary>
        /// Determines whether the specified object is equal to the current Polynomial object
        /// </summary>
        /// <param name="obj">The object to compare with the current Polynomial object</param>
        /// <returns>True if the specified object is equal to the current Polynomial object; otherwise, false</returns>
        public bool Equals(Polynomial obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (_coefficients.Length != obj._coefficients.Length) return false;

            for (int i = 0; i < _coefficients.Length; i++)
            {
                if (!_coefficients[i].Equals(obj._coefficients[i])) return false;
            }
            return true;
        }

        /// <summary>
        /// Represents the current polynomial
        /// </summary>
        /// <returns>String representation of polynomial</returns>
        public override string ToString()
        {
            if (_degree == 0) return _coefficients[0].ToString();

            StringBuilder temp = new StringBuilder();
            temp.Append(_coefficients[_degree] + "x^" + _degree);

            for (int i = _degree - 1; i > 0; i--)
                if (_coefficients[i] > _epsilon)
                    temp.Append("+" + _coefficients[i] + "x^" + i);
                else if (_coefficients[i] < -_epsilon)
                {
                    temp.Append(_coefficients[i] + "x^" + i);
                }

            if (_coefficients[0] > _epsilon)
                temp.Append("+" + _coefficients[0]);
            else if (_coefficients[0] < -_epsilon)
                temp.Append(_coefficients[0]);

            return temp.ToString();
        }

        /// <summary>
        /// Calculates the hash code of current polynomial
        /// </summary>
        /// <returns>Hash code of the Polynomial object</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < _coefficients.Length; i++)
                hash += (_coefficients[i] + i).GetHashCode();
            return hash;
        }
        #endregion

        #endregion

        #region Overloaded operators
        /// <summary>
        /// Adds two polynomials
        /// </summary>
        /// <param name="lhs">First polynomial</param>
        /// <param name="rhs">Second polynomial</param>
        /// <returns>Sum of polynomials</returns>
        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            return Polynomial.Add(lhs, rhs);
        }

        /// <summary>
        /// Calculates the negation of two polynomial
        /// </summary>
        /// <param name="value">Source polynomial</param>
        /// <returns>Negation of polynomial</returns>
        public static Polynomial operator -(Polynomial value)
        {
            return Polynomial.Negation(value);
        }

        /// <summary>
        /// Calculates the substraction of two polynomials
        /// </summary>
        /// <param name="lhs">First polynomial</param>
        /// <param name="rhs">Second polynomial</param>
        /// <returns>Substraction of polynomials</returns>
        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {
            return Polynomial.Sub(lhs, rhs);
        }

        /// <summary>
        /// Mutliplies two polynomials
        /// </summary>
        /// <param name="lhs">First polynomial</param>
        /// <param name="rhs">Second polynomial</param>
        /// <returns>Multiplication of polynomials</returns>
        public static Polynomial operator *(Polynomial lhs, Polynomial rhs)
        {
            return Polynomial.Mul(lhs, rhs);
        }

        /// <summary>
        /// Compares two Polynomial variables
        /// </summary>
        /// <param name="lhs">First Polynomial variable</param>
        /// <param name="rhs">Second Polynomial variable</param>
        /// <returns>Result of comparison: true if variables are equal, false if they are not</returns>
        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, rhs)) return true;
            if (ReferenceEquals(lhs, null)) return false;

            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Compares two Polynomial variables
        /// </summary>
        /// <param name="lhs">First Polynomial variable</param>
        /// <param name="rhs">Second Polynomial variable</param>
        /// <returns>Result of comparison: true if variables are not equal, false if the are</returns>
        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            return !(lhs == rhs);
        }
        #endregion

    }
}
