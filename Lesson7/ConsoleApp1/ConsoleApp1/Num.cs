namespace ConsoleApp1
{
    public class Num
    {
        private Token token;
        private int value;

        public Num(Token token)
        {
            this.token = token;
            this.value = (int)token.value;
        }
    }
}