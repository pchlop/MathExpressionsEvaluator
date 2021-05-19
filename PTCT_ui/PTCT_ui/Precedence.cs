using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCT_ui
{
    public class Precedence
    {
        private int _precedence;
        private bool _rightAssociativity;

        public Precedence(int p, bool right)
        {
            this._precedence = p;
            this._rightAssociativity = right;
        }

        public int precedence
        {
            get => _precedence;
        }

        public bool rightAssociativity
        {
            get => _rightAssociativity;
        }
    }


}