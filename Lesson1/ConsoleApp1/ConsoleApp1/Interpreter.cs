using System;

namespace ConsoleApp1
{

    public class Interpreter
    {

        public string text;
        public int pos;
        public Token currentToken;


        public Interpreter(string text)
        {
            this.text = text;
            pos = 0;
            currentToken = null;
        }
        
        public void Error()
        {
            throw new Exception("Error parsing input");
        }

        public Token GetNextToken()
        {
            var readingText = text;

            if (pos > readingText.Length - 1) return new Token(TokenType.EOF, null);

            var currentCharacter = readingText[pos];

            if (char.IsDigit(currentCharacter))
            {
                pos += 1;
                return new Token(TokenType.INTEGER, int.Parse(currentCharacter.ToString()));
            }
            
            if (currentCharacter == '+')
            {
                pos += 1;
                return new Token(TokenType.PLUS, currentCharacter);
            }

            Error();
            return null;
        }

        public void Eat(TokenType tokenType)
        {
            if (currentToken.tokenType == tokenType)
            {
                currentToken = GetNextToken();
            }
            else
            {
                Error();
            }
        }

        public int Expression()
        {
            currentToken = GetNextToken();

            var left = currentToken;
            Eat(TokenType.INTEGER);

            var op = currentToken;
            Eat(TokenType.PLUS);

            var right = currentToken;
            Eat(TokenType.INTEGER);

            return (int)left.value + (int)right.value;
        }
    }
}