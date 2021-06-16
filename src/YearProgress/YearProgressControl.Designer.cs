
namespace YearProgress
{
    partial class YearProgressControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.yearCirCleProgress = new YearProgress.CircleProgress();
            this.dayCirCleProgress = new YearProgress.CircleProgress();
            this.SuspendLayout();
            // 
            // yearCirCleProgress
            // 
            this.yearCirCleProgress.Content = "Y";
            this.yearCirCleProgress.Location = new System.Drawing.Point(2, 0);
            this.yearCirCleProgress.Maximum = 100D;
            this.yearCirCleProgress.Minimum = 0D;
            this.yearCirCleProgress.Name = "yearCirCleProgress";
            this.yearCirCleProgress.Size = new System.Drawing.Size(25, 25);
            this.yearCirCleProgress.TabIndex = 0;
            this.yearCirCleProgress.Text = "yearCircleProgress";
            this.yearCirCleProgress.Value = 0D;
            // 
            // dayCirCleProgress
            // 
            this.dayCirCleProgress.Content = "D";
            this.dayCirCleProgress.Location = new System.Drawing.Point(38, 0);
            this.dayCirCleProgress.Maximum = 100D;
            this.dayCirCleProgress.Minimum = 0D;
            this.dayCirCleProgress.Name = "dayCirCleProgress";
            this.dayCirCleProgress.Size = new System.Drawing.Size(25, 25);
            this.dayCirCleProgress.TabIndex = 0;
            this.dayCirCleProgress.Text = "dayProgressControl";
            this.dayCirCleProgress.Value = 0D;
            // 
            // YearProgressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.yearCirCleProgress);
            this.Controls.Add(this.dayCirCleProgress);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "YearProgressControl";
            this.Size = new System.Drawing.Size(73, 28);
            this.ResumeLayout(false);

        }

        #endregion

        private CircleProgress yearCirCleProgress;
        private CircleProgress dayCirCleProgress;
    }
}
