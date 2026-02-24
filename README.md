# PROG-280-assign-4

## Assignment 04 – PROG280 – Recursion and the BackgroundWorker

### Project Structure

| Project | Description |
|---------|-------------|
| `PROG280Assign4.Lib` | Class library containing `Fib280` and `Hanoi280` |
| `PROG280Assign4.App` | Windows Forms benchmarking application (net8.0-windows) |
| `PROG280Assign4.Tests` | xUnit unit tests for the library |

### How to Run

```bash
# Run all unit tests
dotnet test PROG280Assign4.Tests/PROG280Assign4.Tests.csproj

# Build the Windows Forms app (requires Windows to run)
dotnet build PROG280Assign4.App/PROG280Assign4.App.csproj
```

---

## Question 2d – Stack copying questions

### Why we shuffle items between two stacks instead of `tempStack = inputStack`

In C#, `Stack<T>` is a **reference type** (a class). Writing `tempStack = inputStack` does not copy the stack's contents – it only copies the *reference* (the memory address) that points to the same underlying stack object. Both variables would then point to the exact same collection in memory. Any operation performed through `tempStack` (such as `Pop()`) would modify the original `inputStack` as well, destroying its contents permanently. That defeats the entire purpose of using a temporary variable.

### Another way to overcome this problem

Instead of manually shuffling items, we can create a **deep copy** of the stack at the start. One straightforward approach in C# is to pass the stack's contents to the constructor of a new `Stack<T>`:

```csharp
// Stack<T>(IEnumerable<T>) preserves order (top of original → top of copy)
var tempStack = new Stack<int>(new Stack<int>(inputStack));
```

The double-wrap is needed because `Stack<T>(IEnumerable<T>)` reverses the enumeration order once; wrapping it twice preserves the original top-to-bottom order.

Alternatively, we could use LINQ:

```csharp
var tempStack = new Stack<int>(inputStack.Reverse());
```

Both approaches create an independent copy of the data so that operations on `tempStack` do not affect the original `inputStack`.
