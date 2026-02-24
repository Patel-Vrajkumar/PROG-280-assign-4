using PROG280Assign4.Lib;

namespace PROG280Assign4.Tests;

public class Hanoi280Tests
{
    // Helper: verify that the destination stack contains disks 1..n in order (1 on top)
    private static void AssertDestinationCorrect(Hanoi280 hanoi, int n)
    {
        Assert.Equal(0, hanoi.Source.Count);
        Assert.Equal(0, hanoi.Spare.Count);
        Assert.Equal(n, hanoi.Destination.Count);

        for (int expected = 1; expected <= n; expected++)
        {
            Assert.Equal(expected, hanoi.Destination.Pop());
        }
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void go_i_MovesAllDisksToDestination(int n)
    {
        var hanoi = new Hanoi280();
        hanoi.LoadDisks(n);

        hanoi.go_i();

        AssertDestinationCorrect(hanoi, n);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void go_r_MovesAllDisksToDestination(int n)
    {
        var hanoi = new Hanoi280();
        hanoi.LoadDisks(n);

        hanoi.go_r();

        AssertDestinationCorrect(hanoi, n);
    }

    [Fact]
    public void print_ReturnsCorrectString_AndRestoresStack()
    {
        var hanoi = new Hanoi280();
        hanoi.LoadDisks(3);

        // Source should be [3 (bottom), 2, 1 (top)]
        string result = hanoi.print(hanoi.Source);

        // print pops from top, so the string should read top-to-bottom: "1, 2, 3"
        Assert.Equal("1, 2, 3", result);

        // Stack must be restored
        Assert.Equal(3, hanoi.Source.Count);
        Assert.Equal(1, hanoi.Source.Peek());
    }

    [Fact]
    public void print_EmptyStack_ReturnsEmptyString()
    {
        var hanoi = new Hanoi280();
        string result = hanoi.print(hanoi.Source);
        Assert.Equal("", result);
    }
}
