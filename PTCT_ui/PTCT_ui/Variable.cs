using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCT_ui
{
    public class Variable : IEquatable<Variable>
    {
        private char _symbol;
        private double _coefficient = 1;
        private double _exponent = 1;
        private double _constant = 1;

        public Variable(char symbol)
        {
            this._symbol = symbol;
        }

        public Variable(double coe, char symbol)
        {
            this._coefficient = coe;
            this._symbol = symbol;
        }

        public Variable(double coe, char symbol, double exp, double constant)
        {
            this._coefficient = coe;
            this._symbol = symbol;
            this._exponent = exp;
            this._constant = constant;
        }

        public char symbol
        {
            get => _symbol;
        }
        public double coefficient
        {
            get => _coefficient;
            set
            {
                _coefficient = value;
            }
        }

        public double constant
        {
            get => _constant;
            set
            {
                _constant = value;
            }
        }

        public double exponent
        {
            get => _exponent;
            set
            {
                _exponent = value;
            }
        }

        public override int GetHashCode()
        {

            //Get hash code for the Name field if it is not null.
            int hashSymbol = symbol.GetHashCode();

            //Get hash code for the Code field.
            int hashCoefficient = coefficient.GetHashCode();

            //Get hash code for the Code field.
            int hashExponent = exponent.GetHashCode();

            //Get hash code for the Code field.
            int hashConstant = constant.GetHashCode();

            //Calculate the hash code for the product.
            return hashSymbol ^ hashCoefficient ^ hashExponent ^ hashConstant;
        }

        public bool Equals(Variable other)
        {

            //Check whether the compared object is null.
            if (Object.ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (Object.ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal.
            return symbol == other.symbol && coefficient == other.coefficient && exponent == other.exponent && constant == other.constant;
        }

        public string rVariable()
        {
            string zmienna = Convert.ToString(this._coefficient) + Convert.ToString(this._symbol) + "^" + Convert.ToString(this._exponent);
            return zmienna;
        }
    }
}