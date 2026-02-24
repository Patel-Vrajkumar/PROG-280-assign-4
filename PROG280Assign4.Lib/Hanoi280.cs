using System.Text;

namespace PROG280Assign4.Lib;

/// <summary>
/// Solves the Towers of Hanoi puzzle using iterative and recursive algorithms.
/// Disks are represented as integers where a larger integer means a larger disk.
/// Push disks onto Source in descending order (largest first) before calling go_i or go_r.
/// </summary>
public class Hanoi280
{
    public Stack<int> Source { get; } = new Stack<int>();
    public Stack<int> Destination { get; } = new Stack<int>();
    public Stack<int> Spare { get; } = new Stack<int>();

    /// <summary>
    /// Resets all stacks and loads <paramref name="n"/> disks onto Source.
    /// Disk n is the largest; disk 1 is the smallest (on top).
    /// </summary>
    public void LoadDisks(int n)
    {
        Source.Clear();
        Destination.Clear();
        Spare.Clear();

        for (int i = n; i >= 1; i--)
        {
            Source.Push(i);
        }
    }

    /// <summary>
    /// Transfers all disks from Source to Destination using the iterative algorithm.
    /// The number of disks is determined by the current contents of Source.
    /// </summary>
    public void go_i()
    {
        int n = Source.Count;
        if (n == 0) return;

        long totalMoves = (1L << n) - 1; // 2^n - 1

        // Index pegs as an array for easy cyclic access.
        // pegs[0]=Source, pegs[1]=Destination, pegs[2]=Spare
        Stack<int>[] pegs = { Source, Destination, Spare };

        // The smallest disk cycles through the pegs in a fixed order depending on n:
        //   odd  n : Source(0) → Destination(1) → Spare(2)     → Source ...
        //   even n : Source(0) → Spare(2)        → Destination(1) → Source ...
        int[] cycle = (n % 2 == 1)
            ? new[] { 0, 1, 2 }   // Source → Dest → Spare
            : new[] { 0, 2, 1 };  // Source → Spare → Dest

        // cyclePos tracks which slot in 'cycle' currently holds the smallest disk.
        int cyclePos = 0;

        for (long move = 1; move <= totalMoves; move++)
        {
            if (move % 2 == 1) // odd move: move the smallest disk one step along the cycle
            {
                int from = cycle[cyclePos % 3];
                int to   = cycle[(cyclePos + 1) % 3];
                pegs[to].Push(pegs[from].Pop());
                cyclePos++;
            }
            else // even move: make the only legal move that does NOT involve the smallest disk
            {
                int smallPeg = cycle[cyclePos % 3];

                // Determine the other two peg indices
                int a = (smallPeg + 1) % 3;
                int b = (smallPeg + 2) % 3;

                int topA = (pegs[a].Count > 0) ? pegs[a].Peek() : int.MaxValue;
                int topB = (pegs[b].Count > 0) ? pegs[b].Peek() : int.MaxValue;

                if (topA < topB)
                    pegs[b].Push(pegs[a].Pop());
                else
                    pegs[a].Push(pegs[b].Pop());
            }
        }
    }

    /// <summary>
    /// Transfers all disks from Source to Destination using the recursive algorithm.
    /// The number of disks is determined by the current contents of Source.
    /// </summary>
    public void go_r()
    {
        int n = Source.Count;
        MoveDisks(n, Source, Destination, Spare);
    }

    /// <summary>
    /// Builds and returns a string representation of the given stack without
    /// permanently altering its contents.
    /// </summary>
    public string print(Stack<int> inputStack)
    {
        var tempStack = new Stack<int>();
        var sb = new StringBuilder();

        // Move all items to tempStack, building the string
        while (inputStack.Count > 0)
        {
            int item = inputStack.Pop();
            tempStack.Push(item);
            sb.Append(item);
            if (inputStack.Count > 0)
                sb.Append(", ");
        }

        // Restore items back to inputStack
        while (tempStack.Count > 0)
        {
            inputStack.Push(tempStack.Pop());
        }

        return sb.ToString();
    }

    // -----------------------------------------------------------------------
    // Private helpers
    // -----------------------------------------------------------------------

    private static void MoveDisks(int n, Stack<int> from, Stack<int> to, Stack<int> spare)
    {
        if (n <= 0) return;

        // Move n-1 disks from 'from' to 'spare', using 'to' as auxiliary
        MoveDisks(n - 1, from, spare, to);

        // Move the nth (largest remaining) disk from 'from' to 'to'
        to.Push(from.Pop());

        // Move n-1 disks from 'spare' to 'to', using 'from' as auxiliary
        MoveDisks(n - 1, spare, to, from);
    }
}
