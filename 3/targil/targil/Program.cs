using System;

namespace targil
{
    class Program
    {
        static void Main(string[] args)
        {
            NumericalExpression num = new NumericalExpression(123456789159);
            Console.WriteLine(num.ToString());
            /*LinkedList list = new LinkedList(3);
            list.Append(1);
            list.Append(4);
            list.Append(2);
            foreach (var nodeValue in list)
            {
                Console.Write(nodeValue + ", ");
            }
            Console.WriteLine();
            list.sort();
            foreach (var nodeValue in list)
            {
                Console.Write(nodeValue + ", ");
            }
            Console.WriteLine();
            Console.WriteLine(list.GetMaxNode().Value);
            Console.WriteLine(list.GetMinNode().Value);*/

        }
    }
}
