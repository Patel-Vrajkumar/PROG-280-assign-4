using PROG280Assign4.Lib;

namespace PROG280Assign4.Tests;

public class Fib280Tests
{
    private readonly Fib280 _fib = new Fib280();

    // Known Fibonacci values: F(0)=0, F(1)=1, F(2)=1, F(3)=2, F(4)=3, F(5)=5,
    //                         F(6)=8, F(7)=13, F(10)=55, F(20)=6765, F(93)=12200160415121876738
    [Theory]
    [InlineData(0, 0UL)]
    [InlineData(1, 1UL)]
    [InlineData(2, 1UL)]
    [InlineData(3, 2UL)]
    [InlineData(4, 3UL)]
    [InlineData(5, 5UL)]
    [InlineData(6, 8UL)]
    [InlineData(7, 13UL)]
    [InlineData(10, 55UL)]
    [InlineData(20, 6765UL)]
    [InlineData(93, 12200160415121876738UL)]
    public void fib_i_ReturnsCorrectValue(int n, ulong expected)
    {
        Assert.Equal(expected, _fib.fib_i(n));
    }

    [Theory]
    [InlineData(0, 0UL)]
    [InlineData(1, 1UL)]
    [InlineData(2, 1UL)]
    [InlineData(3, 2UL)]
    [InlineData(4, 3UL)]
    [InlineData(5, 5UL)]
    [InlineData(6, 8UL)]
    [InlineData(7, 13UL)]
    [InlineData(10, 55UL)]
    [InlineData(20, 6765UL)]
    public void fib_r_ReturnsCorrectValue(int n, ulong expected)
    {
        Assert.Equal(expected, _fib.fib_r(n));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    public void fib_i_And_fib_r_ReturnSameValue(int n)
    {
        Assert.Equal(_fib.fib_i(n), _fib.fib_r(n));
    }
}
