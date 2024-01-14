using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeCompteEstBon
{
    public class OperationResult
    {
        public int A {  get; set; }
        public int B { get; set; }

        public OperandEnum Operand { get; set; }
        public int Result { get; set; }
    }
}
