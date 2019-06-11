namespace ConsoleApp1
{
    public class Num
    {
        private Token token;
        public int value { get; private set; }

        public Num(Token token)
        {
            this.token = token;
            this.value = (int)token.value;
        }
    }
}