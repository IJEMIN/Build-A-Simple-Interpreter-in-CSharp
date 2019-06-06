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
            Eat(TokenType.INTEGER);
            return (int)token.value;
        }


        public int Expression()
        {
            var result = Factor();

            while (m_CurrentToken.tokenType == TokenType.MUL || m_CurrentToken.tokenType == TokenType.DIV)
            {
                var token = m_CurrentToken;

                if (token.tokenType == TokenType.MUL)
                {
                    Eat(TokenType.MUL);
                    result *= Factor();
                }
                else if (m_CurrentToken.tokenType == TokenType.DIV)
                {
                    Eat(TokenType.DIV);
                    result /= Factor();
                }
            }
            return result;
        }
        
    }
}