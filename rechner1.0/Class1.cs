using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rechner1._0
{
    class CalcElement
    {

        public int? number1;
        public int? number2;
        public string op;

        public int calcPlus()
        {
            return (int)number1 + (int)number2;

        }

        public int calcMinus()
        {
            return (int)number1 - (int)number2;
        }


        public int chooseCalcMethod()
        {
            switch (op)
            {
                case "+":
                    return calcPlus();
                case "-":
                    return calcMinus();
                default:
                    return 0;
            }
        }

    }
}
