namespace PROG280_A03
{
    public class Fib280
    {
        // Iterative Fibonacci
        public ulong fib_i(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;

            ulong prev = 0, curr = 1;
            for (int i = 2; i <= n; i++)
            {
                ulong next = prev + curr;
                prev = curr;
                curr = next;
            }
            return curr;
        }

        // Recursive Fibonacci
        public ulong fib_r(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;
            return fib_r(n - 1) + fib_r(n - 2);
        }
    }
}