using System;

namespace ConsoleApp1
{
    public abstract class NodeVisitor
    {
        public abstract dynamic Visit(object node);
    }
}