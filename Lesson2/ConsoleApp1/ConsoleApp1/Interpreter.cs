using System;

namespace ConsoleApp1
{

    public class Interpreter
    {

        public string m_Text;
        public char m_CurrentCharacter;
        public int m_Pos;
        public Token m_CurrentToken;

        private const char EmptyCharacter = '';


        public Interpreter(string mText)
        {
            m_Text = mText;
            m_Pos = 0;
            m_CurrentToken = null;
            m_CurrentCharacter = mText[m_Pos];
        }
        
        public void InvokeError()
        {
            throw new Exception("Error parsing input");
        }

        public void Advance()
        {
            m_Pos++;
            if (m_Pos > m_Text.Length - 1)
            {
                m_CurrentCharacter = EmptyCharacter;
            }
            else
            {
                m_CurrentCharacter = m_Text[m_Pos];
            }
        }


        public void SkipWhitespace()
        {
            while (m_CurrentCharacter != EmptyCharacter && char.IsWhiteSpace(m_CurrentCharacter))
            {
                Advance();
            }
        }

        public int GetInteger()
        {
            var result = string.Empty;

            while (m_CurrentCharacter != EmptyCharacter && char.IsDigit(m_CurrentCharacter))
            {
                result += m_CurrentCharacter;
            }

            return int.Parse(result);
        }

        public Token GetNextToken()
        {
            while (m_CurrentCharacter != EmptyCharacter)
            {
                if (char.IsWhiteSpace(m_CurrentCharacter))
                {
                    SkipWhitespace();
                    continue;
                }

                if (char.IsDigit(m_CurrentCharacter))
                {
                    return new Token(TokenType.INTEGER, GetInteger());
                }

                if (m_CurrentCharacter == '+')
                {
                    Advance();
                    return new Token(TokenType.PLUS, '+');
                }
                
                if( m_CurrentCharacter == '-')
                {
                    Advance();
                    return new Token(TokenType.MINUS, '-');
                }

                InvokeError();
            }
            
            return new Token(TokenType.EOF, null);
        }

        public void Eat(TokenType tokenType)
        {
            if (m_CurrentToken.tokenType == tokenType)
            {
                m_CurrentToken = GetNextToken();
            }
            else
            {
                InvokeError();
            }
        }

        public int Expression()
        {
            m_CurrentToken = GetNextToken();

            var left = m_CurrentToken;
            Eat(TokenType.INTEGER);

            var op = m_CurrentToken;

            if (op.tokenType == TokenType.PLUS)
            {
                Eat(TokenType.PLUS);    
            }
            else if(op.tokenType == TokenType.MINUS)
            {
                Eat(TokenType.MINUS);    
            }

            var right = m_CurrentToken;
            Eat(TokenType.INTEGER);

            if (op.tokenType == TokenType.MINUS)
            {
                return (int)left.value - (int)right.value;
            }
            else
            {
                return (int)left.value + (int)right.value;
            }
        }
    }
}