using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCT_ui
{
    public class ExpressionTree
    {

        bool isOperator(char c)
        {
            if (c == '+' || c == '-' || c == '*'
                || c == '/' || c == '^')
            {
                return true;
            }
            return false;
        }

        public TreeNode constructTree(char[] postfix)
        {
            Stack<TreeNode> st = new Stack<TreeNode>();
            TreeNode t, t1, t2;

            // Traverse through every character of
            // input expression
            for (int i = 0; i < postfix.Length; i++)
            {
                //Console.WriteLine(i + " : " + postfix[i]);
                // If operand, simply Push into stack
                if (!isOperator(postfix[i]))
                {
                    t = new TreeNode(postfix[i]);
                    st.Push(t);
                }
                else // operator
                {
                    t = new TreeNode(postfix[i]);
                    //Console.WriteLine(t.value);
                    // Pop two top nodes
                    // Store top
                    t1 = (TreeNode)st.Pop();     // Remove top
                                                 // Console.WriteLine(t1.value);
                    t2 = (TreeNode)st.Pop();
                    //Console.WriteLine(t2.value);
                    // make them children
                    t.right = t1;
                    t.left = t2;

                    // System.out.println(t1 + "" + t2);
                    // Add this subexpression to stack
                    st.Push(t);
                }
            }

            // only element will be root of
            // expression tree
            t = (TreeNode)st.Peek();
            st.Pop();

            return t;
        }

    }
}
