using System;

namespace ConsoleApp1
{

    public class Lexer
    {

        public string m_Text;
        public char m_CurrentCharacter;
        public int m_Pos;

        private const char NulCharacter = '\0';


        public Lexer(string mText)
        {
            m_Text = mText;
            m_Pos = 0;
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
                m_CurrentCharacter = NulCharacter;
            }
            else
            {
                m_CurrentCharacter = m_Text[m_Pos];
            }
        }


        public void SkipWhitespace()
        {
            while (m_CurrentCharacter != NulCharacter && char.IsWhiteSpace(m_CurrentCharacter))
            {
                Advance();
            }
        }

        public int GetInteger()
        {
            var result = string.Empty;

            while (m_CurrentCharacter != NulCharacter && char.IsDigit(m_CurrentCharacter))
            {
                result += m_CurrentCharacter;
                Advance();
            }

            return int.Parse(result);
        }

        public Token GetNextToken()
        {
            while (m_CurrentCharacter != NulCharacter)
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
                
                if (m_CurrentCharacter == '*')
                {
                    Advance();
                    return new Token(TokenType.MUL, '*');
                }
                
                if( m_CurrentCharacter == '/')
                {
                    Advance();
                    return new Token(TokenType.DIV, '/');
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
                
                
                if (m_CurrentCharacter == '(')
                {
                    Advance();
                    return new Token(TokenType.LPAREN, '(');
                }
                
                if( m_CurrentCharacter == ')')
                {
                    Advance();
                    return new Token(TokenType.RPAREN, ')');
                }

                InvokeError();
            }
            
            return new Token(TokenType.EOF, null);
        }

    }
}