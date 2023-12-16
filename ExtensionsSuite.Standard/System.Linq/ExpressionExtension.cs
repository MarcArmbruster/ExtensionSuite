namespace System.Linq.Expressions
{
    using System;

    /// <summary>
    /// Contains extensions for the <see cref="Expression"/> generic classes.
    /// </summary>
    public static class ExpressionExtension
    {
        /// <summary>
        /// Extracts the name of a member (property of field in this case)
        /// from an expression.
        /// </summary>
        /// <typeparam name="TDelegate">The delegate type.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>The member name.</returns>
        public static string MemberName<TDelegate>(this Expression<TDelegate> expression)
        {
            if (expression == null)
            {
                return string.Empty;
            }

            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("Expression is not a member expression.", nameof(expression));
            }

            return memberExpression.Member.Name;
        }
    }
}