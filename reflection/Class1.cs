using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTorrent
{
    [Serializable]
    public class OpAttribute : Attribute
    {
        char op;
        public OpAttribute(char op)
        {
            this.op = op;
        }
        public char Op
        {
            get { return op; }
            set { op = value; }
        }
    }
    [Serializable]
    [Op('+')]
    public class Op1
    {
        double x, y;

        public Op1(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public string sum()
        {
            return x + " + " + y + " = " + (x+y);
        }
    }
    [Serializable]
    [Op('-')]
    public class Op2
    {
        double x, y;

        public Op2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public string sub()
        {
            return x + " - " + y + " = " + (x - y);
        }
    }
    [Serializable]
    [Op('*')]
    public class Op3
    {
        double x, y;

        public Op3(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public string mult()
        {
            return x + " * " + y + " = " + (x * y);
        }
    }
}
