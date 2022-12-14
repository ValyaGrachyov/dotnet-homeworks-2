using System.Data;
using System.Linq.Expressions;
using Hw11.Infrastructure.ErrorMessages;

namespace Hw11.Infrastructure;

    public class ExpressionConverter
    {
        private readonly Dictionary<Expression, Expression[]> _expressionDictionary = new();

        public Dictionary<Expression, Expression[]> ExpressionDictionary(Expression expression)
        {
            Visit(expression as dynamic);
            return _expressionDictionary;
        }

        private void Visit(BinaryExpression binaryExpr)
        {
            _expressionDictionary.Add(binaryExpr, new []{binaryExpr.Left,binaryExpr.Right});
            Visit(binaryExpr.Left as dynamic);
            Visit(binaryExpr.Right as dynamic);
        }

        private void Visit(ConstantExpression constantExpr)
        {
            _expressionDictionary.Add(constantExpr,Array.Empty<Expression>());
        }
    }

