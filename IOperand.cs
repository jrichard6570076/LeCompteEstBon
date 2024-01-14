using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeCompteEstBon
{
    internal interface IOperand
    {
        int A { get; set; }
        int B { get; set; }        
        OperandEnum Operand { get; set; }
        int? Getresult();
    }
}
