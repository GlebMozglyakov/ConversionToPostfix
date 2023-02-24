using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionToPostfix
{
    public class ConversionPostfix
    {
        public static string ConvertToPostfix(string infix)
        {
            var postfixSB = new StringBuilder();
            var operationStack = new Stack<char>();
            var operationPriority = new Dictionary<char, int>()
            {
                {'(', 0 },
                {'+', 1 },
                {'-', 1 },
                {'*', 2 },
                {'/', 2 },
                {'^', 3 },
            };

            if (!string.IsNullOrEmpty(infix))
            {
                for (int i = 0; i < infix.Length; i++)
                {
                    var symbol = infix[i];

                    if (Char.IsDigit(symbol))
                        postfixSB.Append(GetNumber(infix, ref i));
                    else if (symbol == '(')
                        operationStack.Push(symbol);
                    else if (symbol == ')')
                        PopOperationsFromStack(operationStack, ref postfixSB);
                    else if (operationPriority.ContainsKey(symbol))
                        AddPriorityOperationsToPostfix(ref operationStack, ref postfixSB, operationPriority, symbol);
                }

                foreach (var operation in operationStack)
                    postfixSB.Append(operation);
            }
            else
            {
                throw new NullReferenceException("Строка не должна быть пустой !");
            }

            return postfixSB.ToString();
        }

        private static string GetNumber(string infix, ref int position)
        {
            var numberSB = new StringBuilder();

            for (; position < infix.Length; position++)
            {
                var number = infix[position];

                if (Char.IsDigit(number))
                    numberSB.Append(number);
                else
                {
                    position--;
                    break;
                }
            }
            
            return numberSB.ToString();
        }

        private static void PopOperationsFromStack(Stack<char> operationStack, ref StringBuilder postfixSB)
        {
            while (operationStack.Count > 0 && operationStack.Peek() != '(')
                postfixSB.Append(operationStack.Pop());
            operationStack.Pop();
        }

        private static void AddPriorityOperationsToPostfix(ref Stack<char> operationStack, ref StringBuilder postfixSB, Dictionary<char, int> operationPriority, char symbol)
        {
            while (operationStack.Count > 0 && (operationPriority[operationStack.Peek()] >= operationPriority[symbol]))
                postfixSB.Append(operationStack.Pop());
            operationStack.Push(symbol);
        }
    }
}
