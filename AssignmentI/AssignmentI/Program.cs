using System;

namespace AssignmentI
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 8;
            HelloConstantTime(n);
            HelloLinearTime(n);
            HelloQuadraticTime(n);
        }

        // This method demonstrates constant time, O(1), because no matter what the value of n is, this method will still go through the same number of steps
        static void HelloConstantTime(int n)
        {
            Console.WriteLine("~HELLO CONSTANT TIME~\n\n");
            Console.WriteLine("Hello!\n");
        }

        // This method demonstrates linear time, O(n), because the runtime is linearly proportional to n
        static void HelloLinearTime(int n)
        {
            Console.WriteLine("~HELLO LINEAR TIME~\n\n");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Hello Person " + (i + 1) + "!\n");
            }
        }

        // This method demonstrates quadratic time, O(n^2), because the runtime is proportional to (n * n)
        static void HelloQuadraticTime(int n)
        {
            Console.WriteLine("~HELLO QUADRATIC TIME~\n\n");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Hello Class " + (i + 1) + "!\n");
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("Hello Teacher!\n");
                }
            }
        }
    }
}
