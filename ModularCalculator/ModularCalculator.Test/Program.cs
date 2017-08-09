using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using ModularCalculator.Core;

namespace ModularCalculator.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteCurrent();

            Calculator.PushBackCurrentExpresion("123"); //123
            Calculator.DeleteLastInCurrentExpression(); //12
            Calculator.ClearCurrentExpression(); //0
            Calculator.DeleteLastInCurrentExpression(); //0
            Calculator.ReverseMathematicalSign(); //0
            Calculator.PushBackCurrentExpresion("123"); //123
            Calculator.ReverseMathematicalSign(); //-123
            Calculator.ReverseMathematicalSign(); //123
            WriteCurrent();

            ReadKey();
        }

        static void WriteCurrent()
        {
            WriteLine($"Current Expression: {Calculator.CurrentExpression}");
        }
    }
}
