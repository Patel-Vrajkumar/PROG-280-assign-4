namespace PROG280Assign4.App;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FibBenchmarkForm());
    }
}
