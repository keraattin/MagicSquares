namespace MagicSquare
{
    partial class OddForm
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
            this.btnStart = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonRestart = new System.Windows.Forms.Button();
            this.labelExpectedValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(15, 33);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(82, 31);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Başla";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(12, 13);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(325, 17);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = "Seçiminizi yaptıktan sonra başla butonuna basınız.";
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonRestart
            // 
            this.buttonRestart.Location = new System.Drawing.Point(999, 12);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(76, 43);
            this.buttonRestart.TabIndex = 2;
            this.buttonRestart.Text = "Yeniden";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // labelExpectedValue
            // 
            this.labelExpectedValue.AutoSize = true;
            this.labelExpectedValue.Location = new System.Drawing.Point(117, 47);
            this.labelExpectedValue.Name = "labelExpectedValue";
            this.labelExpectedValue.Size = new System.Drawing.Size(120, 17);
            this.labelExpectedValue.TabIndex = 3;
            this.labelExpectedValue.Text = "Beklenen deger =";
            // 
            // OddForm
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 621);
            this.Controls.Add(this.labelExpectedValue);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.btnStart);
            this.Name = "OddForm";
            this.Text = "OddForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OddForm_FormClosing);
            this.Load += new System.EventHandler(this.OddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Label labelExpectedValue;
    }
}