using System;
using System.Linq.Expressions;

namespace ConsoleApp1
{
    public class Parser
    {
        private Lexer m_Lexer;
        private Token m_CurrentToken;

        public Parser(Lexer lexer)
        {
            m_Lexer = lexer;
            m_CurrentToken = m_Lexer.GetNextToken();
        }

        private void InvokeError()
        {
            throw new Exception("Invalid Syntax");
        }

        void Eat(TokenType type)
        {
            if (m_CurrentToken.tokenType == type)
            {
                m_CurrentToken = m_Lexer.GetNextToken();
            }
            else
            {
                InvokeError();
            }
        }

        dynamic Factor()
        {
            var token = m_CurrentToken;
            if (token.tokenType == TokenType.INTEGER)
            {
                Eat(TokenType.INTEGER);
                return new Num(token);
            }
            else if (token.tokenType == TokenType.LPAREN)
            {
                Eat(TokenType.LPAREN);
                var node = Expression();
                Eat(TokenType.RPAREN);
                return node;
            }

            InvokeError();
            return null;
        }

        dynamic Term()
        {
            var node = Factor();

            while (m_CurrentToken.tokenType == TokenType.MUL || m_CurrentToken.tokenType == TokenType.DIV)
            {
                var token = m_CurrentToken;
                if (token.tokenType == TokenType.MUL)
                {
                    Eat(TokenType.MUL);
                }
                else if (token.tokenType == TokenType.DIV)
                {
                    Eat(TokenType.DIV);
                }

                node = new BinaryOperator(node, token, Factor());
            }

            return node;
        }

        public dynamic Expression()
        {
            var node = Term();

            while (m_CurrentToken.tokenType == TokenType.PLUS || m_CurrentToken.tokenType == TokenType.MINUS)
            {
                var token = m_CurrentToken;

                if (token.tokenType == TokenType.PLUS)
                {
                    Eat(TokenType.PLUS);
                }
                else if (token.tokenType == TokenType.MINUS)
                {
                    Eat(TokenType.MINUS);
                }
                
                node = new BinaryOperator(node,token,Term());
            }

            return node;
        }

        public dynamic Parse()
        {
            return Expression();
        }
    }
}