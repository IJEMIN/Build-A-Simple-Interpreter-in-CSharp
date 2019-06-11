using System;

namespace ConsoleApp1
{

    public class Interpreter : NodeVisitor
    {
        private Parser m_Parser;


        public override dynamic Visit(object node)
        {
            if (node.GetType() == typeof(Num))
            {
                return VisitNum(node as Num);
            }
            else if (node.GetType() == typeof(BinaryOperator))
            {
                return VisitBinaryOperator(node as BinaryOperator);
            }
            
            InvokeError();
            return null;
        }

        public Interpreter(Parser parser)
        {
            m_Parser = parser;
        }

        public dynamic VisitBinaryOperator(BinaryOperator node)
        {
            if (node.op.tokenType == TokenType.PLUS)
            {
                return Visit(node.left) + Visit(node.right);
            }
            else if (node.op.tokenType == TokenType.MINUS)
            {
                return Visit(node.left) - Visit(node.right);
            }
            else if (node.op.tokenType == TokenType.MUL)
            {
                return Visit(node.left) * Visit(node.right);
            }
            else if (node.op.tokenType == TokenType.DIV)
            {
                return Visit(node.left) / Visit(node.right);
            }

            InvokeError();
            return null;
        }

        public int VisitNum(Num node)
        {
            return node.value;
        }

        public dynamic Interpret()
        {
            var tree = m_Parser.Parse();

            return Visit(tree);
        }

        public void InvokeError()
        {
            throw new Exception("Interpreter Error");
        }
    }
}