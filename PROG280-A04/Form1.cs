using System.ComponentModel;
using System.Diagnostics;
using PROG280_A03;

namespace PROG280_A04
{
    public partial class Form1 : Form
    {
        private readonly Fib280 _fib = new Fib280();
        private BackgroundWorker _workerIterative = new BackgroundWorker();
        private BackgroundWorker _workerRecursive = new BackgroundWorker();

        public Form1()
        {
            InitializeComponent();
            InitializeBackgroundWorkers();
        }

        private void InitializeBackgroundWorkers()
        {
            _workerIterative.DoWork += WorkerIterative_DoWork;
            _workerIterative.RunWorkerCompleted += WorkerIterative_RunWorkerCompleted;

            _workerRecursive.DoWork += WorkerRecursive_DoWork;
            _workerRecursive.RunWorkerCompleted += WorkerRecursive_RunWorkerCompleted;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtInput.Text, out int n) || n < 0 || n > 93)
            {
                MessageBox.Show("Please enter a valid integer between 0 and 93.", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnRun.Enabled = false;

            if (chkIterative.Checked && !_workerIterative.IsBusy)
                _workerIterative.RunWorkerAsync(n);

            if (chkRecursive.Checked && !_workerRecursive.IsBusy)
                _workerRecursive.RunWorkerAsync(n);

            if (!chkIterative.Checked && !chkRecursive.Checked)
                btnRun.Enabled = true;
        }

        private void WorkerIterative_DoWork(object? sender, DoWorkEventArgs e)
        {
            int n = (int)e.Argument!;
            var sw = Stopwatch.StartNew();
            ulong result = _fib.fib_i(n);
            sw.Stop();
            e.Result = new BenchmarkResult("Iterative", n, result, sw.Elapsed.TotalMilliseconds);
        }

        private void WorkerIterative_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                listBoxResults.Items.Add($"Iterative Error: {e.Error.Message}");
            else if (e.Result is BenchmarkResult r)
                listBoxResults.Items.Add(r.ToString());

            CheckAllDone();
        }

        private void WorkerRecursive_DoWork(object? sender, DoWorkEventArgs e)
        {
            int n = (int)e.Argument!;
            var sw = Stopwatch.StartNew();
            ulong result = _fib.fib_r(n);
            sw.Stop();
            e.Result = new BenchmarkResult("Recursive", n, result, sw.Elapsed.TotalMilliseconds);
        }

        private void WorkerRecursive_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                listBoxResults.Items.Add($"Recursive Error: {e.Error.Message}");
            else if (e.Result is BenchmarkResult r)
                listBoxResults.Items.Add(r.ToString());

            CheckAllDone();
        }

        private void CheckAllDone()
        {
            if (!_workerIterative.IsBusy && !_workerRecursive.IsBusy)
                btnRun.Enabled = true;
        }

        private record BenchmarkResult(string Algorithm, int Input, ulong Result, double Ms)
        {
            public override string ToString() =>
                $"[{Algorithm}] fib({Input}) = {Result} | Time: {Ms:F4} ms";
        }
    }
}
