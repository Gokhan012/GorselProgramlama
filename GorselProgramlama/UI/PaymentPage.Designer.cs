namespace GorselProgramlama.UI
{
    partial class PaymentPage
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
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(381, 153);
            panel1.Name = "panel1";
            panel1.Size = new Size(728, 277);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(235, 85);
            label1.Name = "label1";
            label1.Size = new Size(133, 30);
            label1.TabIndex = 0;
            label1.Text = "Kalınan Süre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(235, 115);
            label2.Name = "label2";
            label2.Size = new Size(132, 30);
            label2.TabIndex = 1;
            label2.Text = "Toplam Süre:";
            // 
            // button1
            // 
            button1.Location = new Point(235, 163);
            button1.Name = "button1";
            button1.Size = new Size(196, 49);
            button1.TabIndex = 2;
            button1.Text = "Ödemeyi Tamamla";
            button1.UseVisualStyleBackColor = true;
            // 
            // PaymentPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1481, 614);
            Controls.Add(panel1);
            Name = "PaymentPage";
            Text = "PaymentPage";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Label label2;
        private Label label1;
    }
}