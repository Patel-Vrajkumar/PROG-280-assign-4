namespace PROG280_A04
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.CheckBox chkIterative;
        private System.Windows.Forms.CheckBox chkRecursive;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.Label lblResults;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInput = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.chkIterative = new System.Windows.Forms.CheckBox();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.lblResults = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Size = new System.Drawing.Size(560, 30);
            this.lblTitle.Text = "Fibonacci Benchmarking - PROG280 Assignment 4";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblInput
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(12, 60);
            this.lblInput.Text = "Input Number (0 – 93):";

            // txtInput
            this.txtInput.Location = new System.Drawing.Point(160, 57);
            this.txtInput.Size = new System.Drawing.Size(80, 23);
            this.txtInput.Text = "10";

            // chkIterative
            this.chkIterative.AutoSize = true;
            this.chkIterative.Checked = true;
            this.chkIterative.Location = new System.Drawing.Point(12, 96);
            this.chkIterative.Text = "Run Iterative Algorithm";

            // chkRecursive
            this.chkRecursive.AutoSize = true;
            this.chkRecursive.Checked = true;
            this.chkRecursive.Location = new System.Drawing.Point(12, 124);
            this.chkRecursive.Text = "Run Recursive Algorithm";

            // btnRun
            this.btnRun.Location = new System.Drawing.Point(12, 158);
            this.btnRun.Size = new System.Drawing.Size(120, 30);
            this.btnRun.Text = "Run Benchmark";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);

            // btnClear
            this.btnClear.Location = new System.Drawing.Point(144, 158);
            this.btnClear.Size = new System.Drawing.Size(80, 30);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += (s, e) => listBoxResults.Items.Clear();

            // lblResults
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(12, 204);
            this.lblResults.Text = "Results:";

            // listBoxResults
            this.listBoxResults.Location = new System.Drawing.Point(12, 224);
            this.listBoxResults.Size = new System.Drawing.Size(560, 220);
            this.listBoxResults.HorizontalScrollbar = true;
            this.listBoxResults.Font = new System.Drawing.Font("Consolas", 9F);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.chkIterative);
            this.Controls.Add(this.chkRecursive);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.listBoxResults);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fibonacci Benchmarking";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
