using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCT_ui
{
    public class Eval
    {
        public Expression wynik;

        public Eval(TreeNode node, char[] s)
        {
            wynik = Evaluate(node, s);
        }

        public static Expression Evaluate(TreeNode root, char[] symbol)
        {
            if (root == null)
            {
                return new Expression(new Variable(1, '\0', 0, double.Parse(root.value.ToString()))); ;
            }

            if (root.left == null && root.right == null)
            {
                if (symbol.Contains(root.value))
                {
                    return new Expression(new Variable(root.value));
                }
                //return double.Parse(root.value.ToString());
                return new Expression(new Variable(1, '\0', 0, double.Parse(root.value.ToString())));
            }

            Expression l_val = Evaluate(root.left, symbol);

            Expression r_val = Evaluate(root.right, symbol);

            if (root.value == '+')
            {
                return l_val + r_val;
            }

            if (root.value == '-')
            {
                return l_val - r_val;
            }

            if (root.value == '*')
            {
                return l_val * r_val;
            }

            if (root.value == '/')
            {
                return l_val / r_val;
            }
            if (root.value == '^')
            {
                return l_val.power(r_val);
            }
            /*
            return Math.Pow(l_val, r_val);
            */
            return new Expression(new Variable(1, '\0', 0, 0));

        }


    }
}

