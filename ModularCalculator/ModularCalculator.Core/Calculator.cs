using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularCalculator.Core
{
    public static class Calculator
    {
        public const string DEFAULT_CURRENT_EXPRESSION = "0";
        public const string DEFAULT_PREVIOUS_EPRESSION = "";

        public static event EventHandler OnPreviousExpressionChanged;
        public static event EventHandler OnCurrentExpressionChanged;

        private static string previousExpression = DEFAULT_PREVIOUS_EPRESSION;
        public static string PreviousExpression
        {
            get => previousExpression;
            set
            {
                previousExpression = value;
                OnPreviousExpressionChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        private static string currentExpression = DEFAULT_CURRENT_EXPRESSION;
        public static string CurrentExpression
        {
            get => currentExpression;
            set
            {
                currentExpression = value;
                OnCurrentExpressionChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        public static void PushBackCurrentExpresion(string value)
        {
            if (CurrentExpression.Equals(DEFAULT_CURRENT_EXPRESSION))
                CurrentExpression = string.Empty;

            CurrentExpression += value;
        }

        public static void PushForwardCurrentExpresion(string value)
        {
            if (CurrentExpression.Equals(DEFAULT_CURRENT_EXPRESSION))
                CurrentExpression = string.Empty;

            CurrentExpression = value + CurrentExpression;
        }

        public static void ClearCurrentExpression()
        {
            CurrentExpression = DEFAULT_CURRENT_EXPRESSION;
        }

        public static void ClearCurrentExpressionSilent()
        {
            currentExpression = DEFAULT_CURRENT_EXPRESSION;
        }

        public static void ClearPreviousExpression()
        {
            PreviousExpression = DEFAULT_PREVIOUS_EPRESSION;
        }

        public static void ClearPreviousExpressionSilent()
        {
            PreviousExpression = DEFAULT_PREVIOUS_EPRESSION;
        }

        public static void ClearBothExpressions()
        {
            ClearCurrentExpression();
            ClearPreviousExpression();
        }

        public static void DeleteLastInCurrentExpression()
        {
            if (CurrentExpression.Equals(DEFAULT_CURRENT_EXPRESSION))
                return;

            if (CurrentExpression.Length == 1)
            {
                CurrentExpression = DEFAULT_CURRENT_EXPRESSION;
                return;
            }

            CurrentExpression = new string(CurrentExpression.Take(CurrentExpression.Length - 1).ToArray());
        }

        public static void ReverseMathematicalSign()
        {
            if (CurrentExpression.Equals(DEFAULT_CURRENT_EXPRESSION))
                return;

            if (CurrentExpression.First().Equals('-'))
                CurrentExpression = CurrentExpression.Remove(0, 1);

            else
                CurrentExpression = "-" + CurrentExpression;
        }

        public static void ApplyMathemticalAction(string action)
        {
            if (CurrentExpression.Equals(DEFAULT_CURRENT_EXPRESSION))
                return;

            PreviousExpression += currentExpression;
            CurrentExpression = EvaluateThroughNCalcOnlyResult(PreviousExpression);
            PreviousExpression += action;
            ClearCurrentExpressionSilent();
        }

        public static void ApplyFunction(string format)
        {
            CurrentExpression = string.Format(format, currentExpression);
        }

        public static void EvaluateThroughNCalc()
        {
            string expressionToEvaluate = previousExpression + currentExpression;
            CurrentExpression = EvaluateThroughNCalcOnlyResult(expressionToEvaluate);

            ClearPreviousExpression();
        }

        public static string EvaluateThroughNCalcOnlyResult(string expression)
        {
            return new NCalc.Expression(expression).Evaluate().ToString().Replace(',', '.');
        }
    }
}
