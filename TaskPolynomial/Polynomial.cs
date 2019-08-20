using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPolynomial
{
    public sealed class Polynomial
    {

        private const double eps = double.Epsilon;

        /// <summary>
        /// Constructor
        /// </summary>
        public Polynomial(double[] coefficients)
        {
            this._coefficients = coefficients;
        }

        /// <summary>
        /// Order property
        /// </summary>
        public int Order
        {
            get
            {
                for (int i = _coefficients.Length - 1; i >= 0; i--)
                    if (Math.Abs(_coefficients[i]) > eps)
                        return 1;
                return 0;
            }
        }

        /// <summary>
        /// Property for index
        /// </summary>
        public double[] _coefficients { get; private set; }
        /// <summary>
        /// Indexator
        /// </summary>
        public double this[int factor]
        {
            get
            {
                if (factor < 0) throw new ArgumentOutOfRangeException();
                if (factor >= _coefficients.Length) return 0;
                return _coefficients[factor];
            }
        }

        /// <summary>
        /// Overload +
        /// </summary>
        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            int maxLength = 1 + (first.Order > second.Order ? first.Order : second.Order);
            int minLength = 1 + (first.Order < second.Order ? first.Order : second.Order);

            double[] resultFactors = new double[maxLength];
            for (int i = 0; i < minLength; i++)
                resultFactors[i] = first[i] + second[i];

            if (first.Order > second.Order)
                Array.Copy(first._coefficients, minLength, resultFactors, minLength, maxLength - minLength);
            else
                Array.Copy(second._coefficients, minLength, resultFactors, minLength, maxLength - minLength);

            return new Polynomial(resultFactors);
        }

        /// <summary>
        /// Overload -
        /// </summary>
        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            int maxLength = 1 + (first.Order > second.Order ? first.Order : second.Order);
            int minLength = 1 + (first.Order < second.Order ? first.Order : second.Order);

            double[] resultFactors = new double[maxLength];
            for (int i = 0; i < minLength; i++)
                resultFactors[i] = first[i] - second[i];

            if (first.Order > second.Order)
                Array.Copy(first._coefficients, minLength, resultFactors, minLength, maxLength - minLength);
            else
                for (int i = minLength; i < maxLength; i++)
                    resultFactors[i] = -second[i];

            return new Polynomial(resultFactors);
        }

        /// <summary>
        /// Overloads *
        /// </summary>
        public static Polynomial operator *(Polynomial polinomial, int multiplier)
        {
            double[] resultFactors = new double[polinomial.Order + 1];
            for (int i = 0; i < polinomial.Order + 1; i++)
                resultFactors[i] = polinomial[i] * multiplier;
            return new Polynomial(resultFactors);
        }

        public static Polynomial operator *(int multiplier, Polynomial polinomial)
        {
            return polinomial * multiplier;
        }

        public static Polynomial operator *(Polynomial polinomial, double multiplier)
        {
            double[] resultFactors = new double[polinomial.Order + 1];
            for (int i = 0; i < polinomial.Order + 1; i++)
                resultFactors[i] = polinomial[i] * multiplier;
            return new Polynomial(resultFactors);
        }

        public static Polynomial operator *(double multiplier, Polynomial polinomial)
        {
            return polinomial * multiplier;
        }

        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            int resultOrder = first.Order + second.Order + 1;
            double[] resultForces = new double[resultOrder];

            for (int i = 0; i <= first.Order; i++)
            {
                if (Math.Abs(first[i]) > eps)
                {
                    for (int j = 0; j <= second.Order; j++)
                        resultForces[i + j] += first[i] * second[j];
                }
            }

            return new Polynomial(resultForces);
        }

        /// <summary>
        /// Overloads /
        /// </summary>
        public static Polynomial operator /(Polynomial polinomial, int multiplier)
        {
            double[] resultFactors = new double[polinomial.Order + 1];
            for (int i = 0; i < polinomial.Order + 1; i++)
                resultFactors[i] = polinomial[i] / multiplier;
            return new Polynomial(resultFactors);
        }

        public static Polynomial operator /(int multiplier, Polynomial polinomial)
        {
            return polinomial / multiplier;
        }


        /// <summary>
        /// Overload ==
        /// </summary>

        public static bool operator ==(Polynomial first, Polynomial second)
        {
            if (first._coefficients.Length != second._coefficients.Length)
            {
                return false;
            }
            for (int i = 0; i < first._coefficients.Length; i++)
            {
                if (first[i] != second[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Overload !=
        /// </summary>
        public static bool operator !=(Polynomial first, Polynomial second)
        {
            return !(first == second);
        }


        /// <summary>
        /// Provides string representation of polynomial
        /// </summary>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < _coefficients.Length; i++)
            {
                if (i == 0 && Math.Abs(_coefficients[i]) > eps)
                {
                    str.AppendFormat($"{_coefficients[i]}");
                    continue;
                }

                if (Math.Abs(_coefficients[i]) > eps)
                    if (_coefficients[i] > 0 && str.Length > 0)
                        str.AppendFormat($" + {_coefficients[i]}*x^{i}");
                    else
                        str.AppendFormat($" {_coefficients[i]}*x^{i}");
            }

            return str.ToString().Trim();
        }

        public override bool Equals(object obj)
        {
            Polynomial p = obj as Polynomial;

            if (p?.Order != this.Order)
                return false;

            for (int i = 0; i <= this.Order; i++)
            {
                if (Math.Abs(this[i] - p[i]) > eps)
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return GetCoefficients().GetHashCode();
        }


        public double[] GetCoefficients()
        {
            double[] coeffs = new double[_coefficients.Length];

            _coefficients.CopyTo(coeffs, 0);

            return coeffs;
        }
    }
}
