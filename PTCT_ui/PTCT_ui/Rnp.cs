using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCT_ui
{
    class Rnp
    {
        public string _wyrazenie_rnp;
        Stack<char> stos = new Stack<char>();
        List<string> output = new List<string>();

        private readonly Dictionary<char, Precedence> operators = new Dictionary<char, Precedence>
        {
            {'^', new Precedence(4, true)},
            {'*', new Precedence(3, false)},
            {'/', new Precedence(3, false)},
            {'+', new Precedence(2, false)},
            {'-', new Precedence(2, false)},
           // {'(', new Precedence(0, false)},
           // {')', new Precedence(0, false)},
        };

        public Rnp(string wyrazenie_infix, char[] v)
        {
            char[] symbol = v;
            char[] tokens = wyrazenie_infix.ToCharArray();
            //string[] tokens = wyrazenie_infix.Split();
            foreach (char s in tokens)
            {
                //if(int.TryParse(s, out _) || s.Equals(symbol.ToString()))
                if (int.TryParse(s.ToString(), out _) || symbol.Contains(s))
                {
                    output.Add(s.ToString());
                }
                else if (operators.TryGetValue(s, out var op1))
                {
                    while (stos.Count > 0 && operators.TryGetValue(stos.Peek(), out var op2))
                    {
                        int c = op1.precedence.CompareTo(op2.precedence);
                        if (c < 0 || !op1.rightAssociativity && c <= 0)
                        {
                            output.Add(stos.Pop().ToString());
                        }
                        else
                        {
                            break;
                        }
                    }
                    stos.Push(s);
                }
                else if (s == '(')
                {
                    stos.Push(s);
                }
                else if (s == ')')
                {
                    char top = ' ';
                    while (stos.Count > 0 && (top = stos.Pop()) != '(')
                    {
                        output.Add(top.ToString());
                    }
                    if (top != '(') throw new ArgumentException("No matching left parenthesis");
                }
            }
            while (stos.Count > 0)
            {
                var top = stos.Pop();
                if (!operators.ContainsKey(top)) throw new ArgumentException("No maching right parenthesis");
                output.Add(top.ToString());
            }
            _wyrazenie_rnp = string.Join("", output);
        }

        public string wyrazenie_rnp
        {
            get => _wyrazenie_rnp;
        }
    }

}
