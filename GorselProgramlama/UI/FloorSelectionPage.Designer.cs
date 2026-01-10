namespace GorselProgramlama.UI
{
    partial class FloorSelectionPage
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            progressBar1 = new ProgressBar();
            progressBar2 = new ProgressBar();
            progressBar3 = new ProgressBar();
            progressBar4 = new ProgressBar();
            button5 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(156, 210);
            button1.Name = "button1";
            button1.Size = new Size(231, 58);
            button1.TabIndex = 0;
            button1.Tag = "1";
            button1.Text = "1. KAT";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Allbuttons_Click;
            // 
            // button2
            // 
            button2.Location = new Point(447, 210);
            button2.Name = "button2";
            button2.Size = new Size(231, 58);
            button2.TabIndex = 1;
            button2.Tag = "2";
            button2.Text = "2. KAT";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Allbuttons_Click;
            // 
            // button3
            // 
            button3.Location = new Point(765, 210);
            button3.Name = "button3";
            button3.Size = new Size(231, 58);
            button3.TabIndex = 2;
            button3.Tag = "3";
            button3.Text = "3. KAT";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Allbuttons_Click;
            // 
            // button4
            // 
            button4.Location = new Point(1069, 210);
            button4.Name = "button4";
            button4.Size = new Size(231, 58);
            button4.TabIndex = 3;
            button4.Tag = "4";
            button4.Text = "4. KAT";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Allbuttons_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(584, 70);
            label1.Name = "label1";
            label1.Size = new Size(255, 65);
            label1.TabIndex = 4;
            label1.Text = "Kat Seçiniz";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(156, 274);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(231, 23);
            progressBar1.TabIndex = 5;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(447, 274);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(231, 23);
            progressBar2.TabIndex = 6;
            // 
            // progressBar3
            // 
            progressBar3.Location = new Point(765, 274);
            progressBar3.Name = "progressBar3";
            progressBar3.Size = new Size(231, 23);
            progressBar3.TabIndex = 7;
            // 
            // progressBar4
            // 
            progressBar4.Location = new Point(1069, 274);
            progressBar4.Name = "progressBar4";
            progressBar4.Size = new Size(231, 23);
            progressBar4.TabIndex = 8;
            // 
            // button5
            // 
            button5.Location = new Point(608, 469);
            button5.Name = "button5";
            button5.Size = new Size(231, 58);
            button5.TabIndex = 9;
            button5.Text = "Park Yerini Bulunuz";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // FloorSelectionPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1473, 612);
            Controls.Add(button5);
            Controls.Add(progressBar4);
            Controls.Add(progressBar3);
            Controls.Add(progressBar2);
            Controls.Add(progressBar1);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "FloorSelectionPage";
            Text = "FloorSelectionPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private ProgressBar progressBar3;
        private ProgressBar progressBar4;
        private Button button5;
    }
}