using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCT_ui
{
    public class Expression
    {
        public List<Variable> expTab = new List<Variable>();

        public Expression()
        {
        }
        public Expression(Variable a)
        {
            expTab.Add(a);
        }

        public void Adds(Variable exp)
        {
            this.expTab.Add(exp);
        }

        public Expression power(Expression b)
        {
            Expression powerTab = new Expression();

            foreach (Variable v in this.expTab)
            {
                foreach (Variable x in b.expTab)
                {
                    if (!(MainWindow.symbols.Contains(x.symbol)) && (MainWindow.symbols.Contains(v.symbol)))
                    {
                        double coefficient = v.coefficient;
                        char symbol = v.symbol;
                        double exponent = x.constant;
                        double constant = 0;

                        Variable vara = new Variable(coefficient, symbol, exponent, constant);
                        powerTab.Adds(vara);

                    }

                    else if (!(MainWindow.symbols.Contains(x.symbol)) && !(MainWindow.symbols.Contains(v.symbol)))
                    {
                        double constant = Math.Pow(v.constant, x.constant);
                        double coefficient = 0;
                        char symbol = '\0';
                        double exponent = 0;

                        Variable vara = new Variable(coefficient, symbol, exponent, constant);
                        powerTab.Adds(vara);
                    }
                }
            }

            return powerTab;
        }


        public static Expression operator *(Expression a, Expression b)
        {
            Expression multiplyTab = new Expression();

            foreach (Variable v in a.expTab)
            {
                foreach (Variable x in b.expTab)
                {
                    if (MainWindow.symbols.Contains(x.symbol) && MainWindow.symbols.Contains(v.symbol))
                    {
                        double coefficient = v.coefficient * x.coefficient;
                        char symbol = x.symbol;
                        double exponent = v.exponent + x.exponent;
                        double constant = 0;

                        Variable vara = new Variable(coefficient, symbol, exponent, constant);
                        multiplyTab.Adds(vara);

                    }

                    else if (MainWindow.symbols.Contains(v.symbol) && !(MainWindow.symbols.Contains(x.symbol)))
                    {
                        double coefficient = v.coefficient * x.constant;
                        char symbol = v.symbol;
                        double exponent = v.exponent;
                        double constant = 0;

                        Variable vara = new Variable(coefficient, symbol, exponent, constant);
                        multiplyTab.Adds(vara);
                    }

                    else if (MainWindow.symbols.Contains(x.symbol) && !(MainWindow.symbols.Contains(v.symbol)))
                    {
                        double coefficient = x.coefficient * v.constant;
                        char symbol = x.symbol;
                        double exponent = x.exponent;
                        double constant = 0;

                        Variable vara = new Variable(coefficient, symbol, exponent, constant);
                        multiplyTab.Adds(vara);
                    }

                    else
                    {
                        double coefficient = 0;
                        char symbol = '\0';
                        double exponent = 0;
                        double constant = x.constant * v.constant;

                        Variable vara = new Variable(coefficient, symbol, exponent, constant);
                        multiplyTab.Adds(vara);
                    }

                    //double coefficient = v.coefficient * x.coefficient * v.constant * x.constant;
                    //char symbol = v.symbol;
                    //double exponent = v.exponent + x.exponent;
                    //double constant = v.constant * x.constant;
                    //Variable vara = new Variable(coefficient, symbol, exponent, constant);
                    //multiplyTab.Adds(vara);
                }
            }
            return multiplyTab;
        }

        public static Expression operator /(Expression a, Expression b)
        {
            Expression divideTab = new Expression();

            foreach (Variable v in a.expTab)
            {
                foreach (Variable x in b.expTab)
                {
                    if (MainWindow.symbols.Contains(x.symbol) && MainWindow.symbols.Contains(v.symbol))
                    {
                        double coefficient = v.coefficient / x.coefficient;
                        char symbol = v.symbol;
                        double exponent = v.exponent - x.exponent;
                        double constant = 0;

                        Variable vara = new Variable(coefficient, symbol, exponent, constant);
                        divideTab.Adds(vara);

                    }

                    else if (MainWindow.symbols.Contains(v.symbol) && !(MainWindow.symbols.Contains(x.symbol)))
                    {
                        double coefficient = v.coefficient / x.constant;
                        char symbol = v.symbol;
                        double exponent = v.exponent;
                        double constant = 0;

                        Variable vara = new Variable(coefficient, symbol, exponent, constant);
                        divideTab.Adds(vara);
                    }

                    else if (MainWindow.symbols.Contains(x.symbol) && !(MainWindow.symbols.Contains(v.symbol)))
                    {
                        double coefficient = x.coefficient / v.constant;
                        char symbol = x.symbol;
                        double exponent = x.exponent;
                        double constant = 0;

                        Variable vara = new Variable(coefficient, symbol, exponent, constant);
                        divideTab.Adds(vara);
                    }

                    else
                    {
                        double coefficient = 0;
                        char symbol = '\0';
                        double exponent = 0;
                        double constant = v.constant / x.constant;

                        Variable vara = new Variable(coefficient, symbol, exponent, constant);
                        divideTab.Adds(vara);
                    }

                    //double coefficient = v.coefficient * x.coefficient * v.constant * x.constant;
                    //char symbol = v.symbol;
                    //double exponent = v.exponent + x.exponent;
                    //double constant = v.constant * x.constant;
                    //Variable vara = new Variable(coefficient, symbol, exponent, constant);
                    //divideTab.Adds(vara);
                }
            }
            return divideTab;
        }

        public static Expression operator +(Expression a, Expression b)
        {
            Expression sumTab = new Expression();
            Expression finalTab = new Expression();
            foreach (Variable v in a.expTab)
            {
                foreach (Variable x in b.expTab)
                {
                    if (MainWindow.symbols.Contains(x.symbol) && MainWindow.symbols.Contains(v.symbol) && x.exponent == v.exponent && x.symbol == v.symbol)
                    {
                        double coefficient = v.coefficient + x.coefficient;
                        char symbol = v.symbol;
                        double exponent = v.exponent;
                        double constant = 0;

                        Variable vara = new Variable(coefficient, symbol, exponent, constant);
                        sumTab.Adds(vara);
                    }

                    else if (MainWindow.symbols.Contains(x.symbol) && MainWindow.symbols.Contains(v.symbol) && x.symbol == v.symbol && x.exponent != v.exponent)
                    {

                        if (a.expTab.Count > 1 && v != a.expTab.Last())
                        {
                            sumTab.Adds(v);
                        }
                        else
                        {
                            sumTab.Adds(v);
                            sumTab.Adds(x);
                        }
                    }


                    else if (!(MainWindow.symbols.Contains(x.symbol)) && !(MainWindow.symbols.Contains(v.symbol)))
                    {
                        double constant = x.constant + v.constant;
                        Variable vara = new Variable(0, '\0', 0, constant);
                        sumTab.Adds(vara);
                    }

                    else if (MainWindow.symbols.Contains(x.symbol) && MainWindow.symbols.Contains(v.symbol) && x.symbol != v.symbol)
                    {
                        if (a.expTab.Count > 1 && v != a.expTab.Last())
                        {
                            sumTab.Adds(v);
                        }
                        else
                        {
                            sumTab.Adds(v);
                            sumTab.Adds(x);

                        }
                    }

                    else
                    {
                        if (a.expTab.Count > 1 && v != a.expTab.Last())
                        {
                            sumTab.Adds(v);
                        }
                        else
                        {
                            sumTab.Adds(v);
                            sumTab.Adds(x);
                        }
                    }
                }
            }

            IEnumerable<Variable> noduplicates = sumTab.expTab.Distinct();
            foreach (Variable n in noduplicates)
            {
                finalTab.Adds(n);
            }
            return finalTab;
        }

        public static Expression operator -(Expression a, Expression b)
        {
            Expression diffTab = new Expression();
            Expression finalTab = new Expression();
            foreach (Variable v in a.expTab)
            {
                foreach (Variable x in b.expTab)
                {
                    if (MainWindow.symbols.Contains(x.symbol) && MainWindow.symbols.Contains(v.symbol) && x.exponent == v.exponent && x.symbol == v.symbol)
                    {
                        double coefficient = v.coefficient - x.coefficient;
                        char symbol = v.symbol;
                        double exponent = v.exponent;
                        double constant = 0;

                        Variable vara = new Variable(coefficient, symbol, exponent, constant);
                        diffTab.Adds(vara);
                    }

                    else if (MainWindow.symbols.Contains(x.symbol) && MainWindow.symbols.Contains(v.symbol) && x.symbol == v.symbol && x.exponent != v.exponent)
                    {
                        double coefficient = -1 * x.coefficient;
                        char symbol = x.symbol;
                        double exponent = x.exponent;
                        double constant = 0;

                        Variable x1 = new Variable(coefficient, symbol, exponent, constant);

                        if (a.expTab.Count > 1 && v != a.expTab.Last())
                        {
                            diffTab.Adds(v);
                        }
                        else
                        {
                            diffTab.Adds(v);
                            diffTab.Adds(x1);
                        }

                    }

                    else if (!(MainWindow.symbols.Contains(x.symbol)) && !(MainWindow.symbols.Contains(v.symbol)))
                    {
                        double constant = v.constant - x.constant;
                        Variable vara = new Variable(0, '\0', 0, constant);
                        diffTab.Adds(vara);
                    }

                    else if (MainWindow.symbols.Contains(v.symbol) && !(MainWindow.symbols.Contains(x.symbol)))
                    {
                        double coefficient = 0;
                        char symbol = '\0';
                        double exponent = 0;
                        double constant = -1 * x.constant;

                        Variable x1 = new Variable(coefficient, symbol, exponent, constant);

                        if (a.expTab.Count > 1 && v != a.expTab.Last())
                        {
                            diffTab.Adds(v);
                        }
                        else
                        {
                            diffTab.Adds(v);
                            diffTab.Adds(x1);
                        }
                    }

                    else if (!(MainWindow.symbols.Contains(v.symbol)) && MainWindow.symbols.Contains(x.symbol))
                    {
                        double coefficient = -1 * x.coefficient;
                        char symbol = x.symbol;
                        double exponent = x.exponent;
                        double constant = 0;

                        Variable x1 = new Variable(coefficient, symbol, exponent, constant);

                        if (a.expTab.Count > 1 && v != a.expTab.Last())
                        {
                            diffTab.Adds(v);
                        }
                        else
                        {
                            diffTab.Adds(v);
                            diffTab.Adds(x1);
                        }
                    }
                    
                    else if (MainWindow.symbols.Contains(x.symbol) && MainWindow.symbols.Contains(v.symbol) && x.symbol != v.symbol)
                    {
                        double coefficient = -1 * x.coefficient;
                        char symbol = x.symbol;
                        double exponent = x.exponent;
                        double constant = 0;

                        Variable x1 = new Variable(coefficient, symbol, exponent, constant);

                        if (a.expTab.Count > 1 && v != a.expTab.Last())
                        {
                            diffTab.Adds(v);
                        }
                        else
                        {
                            diffTab.Adds(v);
                            diffTab.Adds(x1);
                        }
                    }
                    
                }
            }

            IEnumerable<Variable> noduplicates = diffTab.expTab.Distinct();
            foreach (Variable n in noduplicates)
            {
                finalTab.Adds(n);
            }
            return finalTab;
        }

        public static Expression operator -(Expression a)
        {
            Expression diffTab = new Expression();

            foreach (Variable v in a.expTab)
            {
                if (MainWindow.symbols.Contains(v.symbol))
                {
                    double coefficient = v.coefficient;
                    Variable vara = new Variable(-coefficient, v.symbol, v.exponent, v.constant);
                    diffTab.Adds(vara);
                }
                else
                {
                    double constant = v.constant;
                    Variable vara = new Variable(0, '\0', 0, -constant);
                    diffTab.Adds(vara);
                }

            }
            return diffTab;
        }

        public override string ToString()
        {
            string napis = "";
            foreach (Variable v in this.expTab)
            {
                if (v.coefficient > 0 || v.constant > 0)
                {
                    napis += "+";
                }

                if (MainWindow.symbols.Contains(v.symbol))
                {
                    if (v.coefficient == 1 && v.exponent == 1)
                    {
                        napis += v.symbol.ToString() + " ";
                    }
                    else if (v.coefficient != 1 && v.exponent == 1)
                    {
                        napis += v.coefficient.ToString() + "*" + v.symbol.ToString() + " ";
                    }
                    else if (v.coefficient == 1 && v.exponent != 1)
                    {
                        napis += v.symbol.ToString() + "^" + v.exponent.ToString() + " ";
                    }
                    else
                    {
                        napis += v.coefficient.ToString() + "*" + v.symbol.ToString() + "^" + v.exponent.ToString() + " ";
                    }
                }
                else
                {
                    napis += v.constant.ToString() + " ";
                }

            }

            if (napis[0].Equals('+'))
            {
                napis = napis.Substring(1);
            }

            return napis;
        }
        
        public string DescString()
        {
            expTab = expTab.OrderByDescending(x => x.exponent).ToList();
            string napis = "";
            foreach (Variable v in this.expTab)
            {
                if (v.coefficient > 0 || v.constant > 0)
                {
                    napis += "+";
                }

                if (MainWindow.symbols.Contains(v.symbol))
                {
                    if (v.coefficient == 1 && v.exponent == 1)
                    {
                        napis += v.symbol.ToString() + " ";
                    }
                    else if (v.coefficient != 1 && v.exponent == 1)
                    {
                        napis += v.coefficient.ToString() + "*" + v.symbol.ToString() + " ";
                    }
                    else if (v.coefficient == 1 && v.exponent != 1)
                    {
                        napis += v.symbol.ToString() + "^" + v.exponent.ToString() + " ";
                    }
                    else
                    {
                        napis += v.coefficient.ToString() + "*" + v.symbol.ToString() + "^" + v.exponent.ToString() + " ";
                    }
                }
                else
                {
                    napis += v.constant.ToString() + " ";
                }

            }

            if (napis[0].Equals('+'))
            {
                napis = napis.Substring(1);
            }

            return napis;
        }
    }

}
