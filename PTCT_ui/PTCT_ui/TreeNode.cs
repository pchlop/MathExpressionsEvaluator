using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCT_ui
{
    public class TreeNode
    {
        public char value;
        public TreeNode left, right;

        public TreeNode(char item)
        {
            value = item;
            left = right = null;
        }

        public string wyswietl()

        {
            return ("Wierchołek:" + value.ToString());
        }
    }
}

