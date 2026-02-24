using System.Text;

namespace PROG280_A03
{
    public class Hanoi280
    {
        public Stack<int> Source { get; set; } = new Stack<int>();
        public Stack<int> Destination { get; set; } = new Stack<int>();
        public Stack<int> Spare { get; set; } = new Stack<int>();

        // Iterative Towers of Hanoi
        // For each of the 2^n - 1 moves, alternate between moving the smallest disk
        // (which cycles in a fixed direction) and making the only legal move not
        // involving the smallest disk.
        // Cyclic order: Source->Destination->Spare for odd n; Source->Spare->Destination for even n
        public void go_i()
        {
            int n = Source.Count;
            int totalMoves = (int)Math.Pow(2, n) - 1;

            // Arrange the three pegs in the correct cyclic order for the rotation
            Stack<int>[] pegs = (n % 2 == 1)
                ? new[] { Source, Destination, Spare }   // odd
                : new[] { Source, Spare, Destination };  // even

            for (int move = 1; move <= totalMoves; move++)
            {
                int r = move % 3;
                if (r == 1)
                    LegalMove(pegs[0], pegs[1]);
                else if (r == 2)
                    LegalMove(pegs[0], pegs[2]);
                else
                    LegalMove(pegs[1], pegs[2]);
            }
        }

        // Move the smaller top disk between two pegs (or any disk if one peg is empty)
        private void LegalMove(Stack<int> a, Stack<int> b)
        {
            if (a.Count == 0)
                a.Push(b.Pop());
            else if (b.Count == 0)
                b.Push(a.Pop());
            else if (a.Peek() < b.Peek())
                b.Push(a.Pop());
            else
                a.Push(b.Pop());
        }

        // Recursive Towers of Hanoi
        public void go_r()
        {
            int n = Source.Count;
            MoveDisks(n, Source, Destination, Spare);
        }

        private void MoveDisks(int n, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (n == 1)
            {
                destination.Push(source.Pop());
                return;
            }
            MoveDisks(n - 1, source, spare, destination);
            destination.Push(source.Pop());
            MoveDisks(n - 1, spare, destination, source);
        }

        // Print the contents of a stack without destroying it.
        // Items are moved to a temp stack (reversing order), then moved back.
        public string print(Stack<int> stack)
        {
            var tempStack = new Stack<int>();
            var sb = new StringBuilder();

            while (stack.Count > 0)
                tempStack.Push(stack.Pop());

            while (tempStack.Count > 0)
            {
                int item = tempStack.Pop();
                sb.Append(item);
                if (tempStack.Count > 0) sb.Append(", ");
                stack.Push(item);
            }

            return sb.ToString();
        }
    }
}
