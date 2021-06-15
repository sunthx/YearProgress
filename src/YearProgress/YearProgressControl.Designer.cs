
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
            this.circleProgress1 = new YearProgress.CircleProgress();
            this.circleProgress2 = new YearProgress.CircleProgress();
            this.SuspendLayout();
            // 
            // circleProgress1
            // 
            this.circleProgress1.Location = new System.Drawing.Point(0, 0);
            this.circleProgress1.Maximum = 100D;
            this.circleProgress1.Minimum = 0D;
            this.circleProgress1.Name = "circleProgress1";
            this.circleProgress1.Size = new System.Drawing.Size(30, 30);
            this.circleProgress1.TabIndex = 0;
            this.circleProgress1.Text = "yearCircleProgress";
            this.circleProgress1.Value = 0D;
            // 
            // circleProgress2
            // 
            this.circleProgress2.Location = new System.Drawing.Point(40, 0);
            this.circleProgress2.Maximum = 100D;
            this.circleProgress2.Minimum = 0D;
            this.circleProgress2.Name = "circleProgress2";
            this.circleProgress2.Size = new System.Drawing.Size(30, 30);
            this.circleProgress2.TabIndex = 0;
            this.circleProgress2.Text = "yearCircleProgress";
            this.circleProgress2.Value = 0D;
            // 
            // YearProgressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.circleProgress1);
            this.Controls.Add(this.circleProgress2);
            this.Name = "YearProgressControl";
            this.Size = new System.Drawing.Size(87, 33);
            this.ResumeLayout(false);

        }

        #endregion

        private CircleProgress circleProgress1;
        private CircleProgress circleProgress2;
    }
}
