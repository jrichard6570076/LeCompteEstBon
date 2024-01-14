using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LeCompteEstBon
{
    public class Operation : IOperand

    {
        public int A {  get; set; }
        public int B { get; set; }

        public OperandEnum Operand { get; set; }

        public int? Getresult()
        {
            switch (Operand)
            {
                case OperandEnum.add:
                    return Add();
                case OperandEnum.minus:
                    return Minus();
                case OperandEnum.divide:
                    return Divide();
                case OperandEnum.multiply:
                    return Multiply();
                default:
                    return null;

            }
            
        }
        private int? Add()
        {
            return A + B;
        }
        private int? Minus()
        {
            return A - B  > 0 ? A-B : B-A ;
            
        }

        private int? Divide()
        {

            if (A < B)
                return null;
            else
            {
                
                if (Math.DivRem(A, B).Remainder == 0)
                    return A/B;
                else
                    return null;
            }
        }

        private int? Multiply()
        {

            return (A == 1 | B == 1) ? null : A * B;
        }
    }
}
 

