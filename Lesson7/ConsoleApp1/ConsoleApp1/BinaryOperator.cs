namespace ConsoleApp1
{
    public class BinaryOperator
    {
        private Token token;
        private Token op;
        private Num left;
        private Num right;

        public BinaryOperator(Num left, Token op, Num right)
        {
            this.left = left;
            this.token = this.op = op;
            this.right = right;
        }
    }
}