namespace MagicSquare
{
    partial class EvenForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelExpectedValue = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelExpectedValue
            // 
            this.labelExpectedValue.AutoSize = true;
            this.labelExpectedValue.Location = new System.Drawing.Point(25, 31);
            this.labelExpectedValue.Name = "labelExpectedValue";
            this.labelExpectedValue.Size = new System.Drawing.Size(120, 17);
            this.labelExpectedValue.TabIndex = 6;
            this.labelExpectedValue.Text = "Beklenen deger =";
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 400;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // EvenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 621);
            this.Controls.Add(this.labelExpectedValue);
            this.Name = "EvenForm";
            this.Text = "Çift Sayı";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EvenForm_FormClosing);
            this.Load += new System.EventHandler(this.EvenForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelExpectedValue;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}