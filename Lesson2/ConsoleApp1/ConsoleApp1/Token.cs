using System;

namespace ConsoleApp1
{
    public class Token
    {
        public TokenType tokenType;
        public object value;

        public Token(TokenType tokenType, object value)
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
        INTEGER,PLUS,EOF,MINUS
    }
}