namespace PROG280Assign4.Lib;

/// <summary>
/// Provides iterative and recursive Fibonacci implementations.
/// </summary>
public class Fib280
{
    /// <summary>
    /// Returns the nth Fibonacci number using an iterative algorithm.
    /// </summary>
    /// <param name="n">The index (0-based) of the Fibonacci number to compute.</param>
    /// <returns>The nth Fibonacci number as a ulong.</returns>
    public ulong fib_i(int n)
    {
        if (n <= 0) return 0;
        if (n == 1) return 1;

        ulong prev = 0;
        ulong curr = 1;

        for (int i = 2; i <= n; i++)
        {
            ulong next = prev + curr;
            prev = curr;
            curr = next;
        }

        return curr;
    }

    /// <summary>
    /// Returns the nth Fibonacci number using a recursive algorithm.
    /// </summary>
    /// <param name="n">The index (0-based) of the Fibonacci number to compute.</param>
    /// <returns>The nth Fibonacci number as a ulong.</returns>
    public ulong fib_r(int n)
    {
        if (n <= 0) return 0;
        if (n == 1) return 1;

        return fib_r(n - 1) + fib_r(n - 2);
    }
}
