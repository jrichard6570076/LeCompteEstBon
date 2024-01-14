using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeCompteEstBon
{
    public class GetBestResult
    {
        private List<int> nunbers;
        private Dictionary<int, OperandEnum> tempsoperand;
        private List<String> result = new List<String>();
        private List<String> bestresult = new List<String>();
        public GetBestResult(List<int> Numbers,int ExpectedResult, int MaxTry = 1000000000)
        {
            int? BestResult = 0;
            List<String> bestoperations = new List<String>();
            List<String> Operations = new List<String>();
            InitOperands();
            List<int> numbers = new List<int>(Numbers);
            OperationResult Res = DoRandomOperation(numbers, ExpectedResult);
            for (int I = 0; I < MaxTry; I++)
            {
                Operations = new List<String>();
                numbers = new List<int>(Numbers);
                InitOperands();
                while (Res.Result != ExpectedResult)
                {
                    numbers.Remove(Res.A);
                    numbers.Remove(Res.B);
                    numbers.Add(Res.Result);
                    

                    if (Res.Result == ExpectedResult)
                    {
                        if (Res.Result < 3000 | Res.Result < -3000)
                        {
                            Operations.Add($"{Res.A} {Res.Operand.ToString()} {Res.B} = {Res.Result.ToString()}");
                            break;
                        }
                        
                    }
                    else if (numbers.Count > 1)
                    {
                        Res = DoRandomOperation(numbers, ExpectedResult);
                        if (Res.Result < 3000 | Res.Result < -3000)
                        {
                            Operations.Add($"{Res.A} {Res.Operand.ToString()} {Res.B} = {Res.Result.ToString()}");
                           
                        }
                    }
                    else
                        break;


                }
                if (Res.Result == ExpectedResult)
                {
                    BestResult = Res.Result;
                    bestoperations = Operations;
                    Console.WriteLine($"Result found in {I} apptemps");
                    foreach (String operation in bestoperations)
                    {
                        Console.WriteLine(operation);
                    }
                    break;
                }
                if (Res.Result > BestResult && Res.Result < ExpectedResult)
                {
                    BestResult = Res.Result;
                    bestoperations = Operations;

                }
            }
            if (BestResult != ExpectedResult)
            {
                Console.WriteLine($"Result not found");
                foreach (String operation in bestoperations)
                {
                    Console.WriteLine(operation);
                }
            }
            
      



        }
       

        private OperationResult DoRandomOperation(List<int> Numbers, int ExpectedResult)
        {
            Random randomop = new Random();
            int indexA = -1;
            int indexB = -1;
            List<int> indexs = new List<int>();
            indexs = Enumerable.Range(0, Numbers.Count).ToList();
            indexA = randomop.Next(0, indexs.Count);            
            indexB = randomop.Next(0, indexs.Count);
            while (indexA == indexB)
            {
                indexB = randomop.Next(0, indexs.Count);
            }
            int operand = randomop.Next(0, tempsoperand.Count - 1);
            while(!tempsoperand.Keys.Contains(operand))
            {
                operand = randomop.Next(0, tempsoperand.Count - 1);
            }
            Operation ope = new Operation() { A = Numbers[indexA], B = Numbers[indexB], Operand = tempsoperand[operand] };
        ;
            while (ope.Getresult() == null ) {
                tempsoperand.Remove(operand);
                operand = randomop.Next(0, tempsoperand.Count - 1);
                while (!tempsoperand.Keys.Contains(operand))
                {
                    operand = randomop.Next(0, tempsoperand.Count - 1);
                }
                ope = new Operation() { A = Numbers[indexA], B = Numbers[indexB], Operand = tempsoperand[operand] };
             
            }
            OperationResult result = new OperationResult() { A = ope.A, B = ope.B, Result = (int)ope.Getresult(), Operand = ope.Operand };
            return result;
        }
        private void InitOperands()
        {
            Dictionary<int, OperandEnum> openum = new Dictionary<int, OperandEnum>();
            openum.Add(0, OperandEnum.add);
            openum.Add(1, OperandEnum.minus);
            openum.Add(2, OperandEnum.multiply);
            openum.Add(3, OperandEnum.divide);
            tempsoperand =  new Dictionary<int, OperandEnum> (  openum);
        }

       
    }
}
