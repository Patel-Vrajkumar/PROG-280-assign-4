using System.ComponentModel;
using System.Diagnostics;
using PROG280Assign4.Lib;

namespace PROG280Assign4.App;

/// <summary>
/// Windows Forms application that benchmarks iterative vs recursive Fibonacci
/// using a BackgroundWorker for each algorithm.
/// </summary>
public class FibBenchmarkForm : Form
{
    private readonly Fib280 _fib = new Fib280();

    // Controls
    private CheckBox _chkIterative = null!;
    private CheckBox _chkRecursive = null!;
    private Label _lblInput = null!;
    private TextBox _txtInput = null!;
    private Button _btnRun = null!;
    private ListBox _lstResults = null!;
    private Button _btnClear = null!;

    // Background workers
    private BackgroundWorker _workerIterative = null!;
    private BackgroundWorker _workerRecursive = null!;

    // Track how many workers are still running so we can re-enable the UI
    private int _activeWorkers;
    private readonly object _lock = new object();

    public FibBenchmarkForm()
    {
        InitializeComponent();
        InitializeWorkers();
    }

    // -----------------------------------------------------------------------
    // UI setup
    // -----------------------------------------------------------------------

    private void InitializeComponent()
    {
        Text = "Fibonacci Benchmark – PROG280 Assign 4";
        Size = new Size(520, 480);
        MinimumSize = new Size(480, 420);
        FormBorderStyle = FormBorderStyle.Sizable;
        StartPosition = FormStartPosition.CenterScreen;

        // --- checkboxes ---
        _chkIterative = new CheckBox
        {
            Text = "Iterative (fib_i)",
            Checked = true,
            Location = new Point(16, 16),
            AutoSize = true
        };

        _chkRecursive = new CheckBox
        {
            Text = "Recursive (fib_r)",
            Checked = true,
            Location = new Point(160, 16),
            AutoSize = true
        };

        // --- input ---
        _lblInput = new Label
        {
            Text = "n (0 – 93):",
            Location = new Point(16, 52),
            AutoSize = true
        };

        _txtInput = new TextBox
        {
            Text = "30",
            Location = new Point(100, 48),
            Width = 80
        };

        // --- run button ---
        _btnRun = new Button
        {
            Text = "Run",
            Location = new Point(200, 46),
            Width = 80
        };
        _btnRun.Click += BtnRun_Click;

        // --- results list ---
        _lstResults = new ListBox
        {
            Location = new Point(16, 88),
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
            Font = new Font("Courier New", 9f)
        };

        // --- clear button ---
        _btnClear = new Button
        {
            Text = "Clear Results",
            Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
            Width = 110
        };
        _btnClear.Click += (_, __) => _lstResults.Items.Clear();

        Controls.AddRange(new Control[]
        {
            _chkIterative, _chkRecursive,
            _lblInput, _txtInput,
            _btnRun, _lstResults, _btnClear
        });

        // Position the list and clear button after controls are added so
        // we can use ClientSize.
        Resize += (_, __) => LayoutDynamic();
        LayoutDynamic();
    }

    private void LayoutDynamic()
    {
        _lstResults.Size = new Size(ClientSize.Width - 32, ClientSize.Height - 130);
        _btnClear.Location = new Point(16, ClientSize.Height - 36);
    }

    // -----------------------------------------------------------------------
    // BackgroundWorker setup
    // -----------------------------------------------------------------------

    private void InitializeWorkers()
    {
        _workerIterative = new BackgroundWorker { WorkerReportsProgress = false };
        _workerIterative.DoWork += WorkerIterative_DoWork;
        _workerIterative.RunWorkerCompleted += Worker_Completed;

        _workerRecursive = new BackgroundWorker { WorkerReportsProgress = false };
        _workerRecursive.DoWork += WorkerRecursive_DoWork;
        _workerRecursive.RunWorkerCompleted += Worker_Completed;
    }

    // -----------------------------------------------------------------------
    // Button handler
    // -----------------------------------------------------------------------

    private void BtnRun_Click(object? sender, EventArgs e)
    {
        if (!int.TryParse(_txtInput.Text.Trim(), out int n) || n < 0 || n > 93)
        {
            MessageBox.Show("Please enter a whole number between 0 and 93.",
                "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!_chkIterative.Checked && !_chkRecursive.Checked)
        {
            MessageBox.Show("Select at least one algorithm to run.",
                "No Algorithm Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        _btnRun.Enabled = false;
        _activeWorkers = 0;

        if (_chkIterative.Checked)
        {
            lock (_lock) _activeWorkers++;
            _workerIterative.RunWorkerAsync(n);
        }

        if (_chkRecursive.Checked)
        {
            lock (_lock) _activeWorkers++;
            _workerRecursive.RunWorkerAsync(n);
        }
    }

    // -----------------------------------------------------------------------
    // Worker DoWork handlers (run on background threads)
    // -----------------------------------------------------------------------

    private void WorkerIterative_DoWork(object? sender, DoWorkEventArgs e)
    {
        int n = (int)e.Argument!;
        var sw = Stopwatch.StartNew();
        ulong result = _fib.fib_i(n);
        sw.Stop();
        e.Result = new BenchmarkResult("Iterative (fib_i)", n, result, sw.ElapsedMilliseconds);
    }

    private void WorkerRecursive_DoWork(object? sender, DoWorkEventArgs e)
    {
        int n = (int)e.Argument!;
        var sw = Stopwatch.StartNew();
        ulong result = _fib.fib_r(n);
        sw.Stop();
        e.Result = new BenchmarkResult("Recursive (fib_r)", n, result, sw.ElapsedMilliseconds);
    }

    // -----------------------------------------------------------------------
    // Completed handler (back on UI thread)
    // -----------------------------------------------------------------------

    private void Worker_Completed(object? sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            _lstResults.Items.Add($"ERROR: {e.Error.Message}");
        }
        else if (e.Result is BenchmarkResult r)
        {
            string entry = $"n={r.N,-4} | {r.Algorithm,-20} | Result={r.Result,-22} | {r.ElapsedMs} ms";
            _lstResults.Items.Add(entry);
            _lstResults.TopIndex = _lstResults.Items.Count - 1;
        }

        lock (_lock)
        {
            _activeWorkers--;
            if (_activeWorkers <= 0)
                _btnRun.Enabled = true;
        }
    }

    // -----------------------------------------------------------------------
    // Result record
    // -----------------------------------------------------------------------

    private sealed record BenchmarkResult(string Algorithm, int N, ulong Result, long ElapsedMs);
}
