using System;
using System.Linq.Expressions;

namespace ConsoleForInterview
{
    class ExpressionTreeExample
    {
        public static void Execute()
        {
            //Create the expression parameters
            ParameterExpression num1 = Expression.Parameter(typeof(int), "num1");
            ParameterExpression num2 = Expression.Parameter(typeof(int), "num2");

            //Create the expression parameters
            ParameterExpression[] parameters = new ParameterExpression[] { num1, num2 };

            //Create the expression body
            BinaryExpression body = Expression.Add(num1, num2);

            //Create the expression 
            Expression<Func<int, int, int>> expression = Expression.Lambda<Func<int, int, int>>(body, parameters);

            // Compile the expression
            Func<int, int, int> compiledExpression = expression.Compile();

            // Execute the expression. 
            int result = compiledExpression(3, 4); //return 7
        }
    }
}
