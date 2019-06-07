using System;

namespace ConsoleApp1
{

    public class Interpreter
    {
        private Lexer m_Lexer;
        public Token m_CurrentToken;



        public Interpreter(Lexer lexer)
        {
            m_Lexer = lexer;
            m_CurrentToken = m_Lexer.GetNextToken();
        }

        public void InvokeError()
        {
            throw new Exception("Invalid Syntax");
        }

        public void Eat(TokenType tokenType)
        {
            if (m_CurrentToken.tokenType == tokenType)
            {
                m_CurrentToken = m_Lexer.GetNextToken();
            }
            else
            {
                InvokeError();
            }
        }

        public int Factor()
        {
            var token = m_CurrentToken;

            if (token.tokenType == TokenType.INTEGER)
            {
                Eat(TokenType.INTEGER);
                return (int)token.value;


            }else if (token.tokenType == TokenType.LPAREN)
            {
                Eat(TokenType.LPAREN);
                var result = Expression();
                Eat(TokenType.RPAREN);

                return result;
            }
            else
            {
                InvokeError();
                return -1;
            }
        }

        public int Term()
        {
            var result = Factor();

            while (m_CurrentToken.tokenType == TokenType.DIV || m_CurrentToken.tokenType == TokenType.MUL)
            {
                var token = m_CurrentToken;

                if (token.tokenType == TokenType.MUL)
                {
                    Eat(TokenType.MUL);
                    result *= Factor();
                }
                else if (token.tokenType == TokenType.DIV)
                {
                    Eat(TokenType.DIV);
                    result /= Factor();
                }
            }

            return result;
        }


        public int Expression()
        {
            var result = Term();

            while (m_CurrentToken.tokenType == TokenType.PLUS || m_CurrentToken.tokenType == TokenType.MINUS)
            {
                var token = m_CurrentToken;

                if (token.tokenType == TokenType.PLUS)
                {
                    Eat(TokenType.PLUS);
                    result += Term();
                }
                else if (m_CurrentToken.tokenType == TokenType.MINUS)
                {
                    Eat(TokenType.MINUS);
                    result -= Term();
                }
            }
            return result;
        }
        
    }
}