using System;

namespace ConsoleApp1
{
    public class Token
    {
        public TokenType tokenType;
        public dynamic value;

        public Token(TokenType tokenType, dynamic value)
        {
            this.tokenType = tokenType;
            this.value = value;
        }

        public override string ToString()
        {
            return $"Token({tokenType}, {value}";
        }
    }

    public enum TokenType
    {
        INTEGER,PLUS,MINUS, MUL, DIV, LPAREN, RPAREN, EOF
    }
}