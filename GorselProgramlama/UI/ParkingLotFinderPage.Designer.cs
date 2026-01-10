namespace GorselProgramlama.UI
{
    partial class ParkingLotFinderPage
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
            panel1 = new Panel();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(467, 453);
            panel1.Name = "panel1";
            panel1.Size = new Size(417, 130);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(520, 234);
            button1.Name = "button1";
            button1.Size = new Size(319, 93);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox1.Location = new Point(520, 135);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(319, 93);
            textBox1.TabIndex = 2;
            textBox1.Text = "Plakanız...";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(23, 48);
            label1.Name = "label1";
            label1.Size = new Size(170, 37);
            label1.TabIndex = 0;
            label1.Text = "Otopark Yeri:";
            // 
            // ParkingLotFinderPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1473, 612);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(panel1);
            Name = "ParkingLotFinderPage";
            Text = "ParkingLotFinderPage";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button button1;
        private TextBox textBox1;
    }
}