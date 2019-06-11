namespace ConsoleApp1
{
    public class BinaryOperator
    {
        public Token token { get; private set; }
        public Token op { get; private set; }
        public dynamic left { get; private set; }
        public dynamic right { get; private set; }

        public BinaryOperator(dynamic left, Token op, dynamic right)
        {
            this.left = left;
            this.token = this.op = op;
            this.right = right;
        }
    }
}