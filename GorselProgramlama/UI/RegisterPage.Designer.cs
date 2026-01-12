namespace GorselProgramlama.UI
{
    partial class RegisterPage
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
            button = new Button();
            label2 = new Label();
            label1 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox5 = new TextBox();
            SuspendLayout();
            // 
            // button
            // 
            button.Location = new Point(603, 443);
            button.Name = "button";
            button.Size = new Size(156, 43);
            button.TabIndex = 11;
            button.Text = "Kayıt Ol";
            button.UseVisualStyleBackColor = true;
            button.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(534, 241);
            label2.Name = "label2";
            label2.Size = new Size(67, 32);
            label2.TabIndex = 9;
            label2.Text = "Şifre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(534, 192);
            label1.Name = "label1";
            label1.Size = new Size(74, 32);
            label1.TabIndex = 8;
            label1.Text = "Plaka:";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox2.Location = new Point(603, 234);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(156, 43);
            textBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox1.Location = new Point(603, 185);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(156, 43);
            textBox1.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox3.Location = new Point(603, 283);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(156, 43);
            textBox3.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.Location = new Point(463, 290);
            label3.Name = "label3";
            label3.Size = new Size(138, 32);
            label3.TabIndex = 13;
            label3.Text = "Tekrar Şifre:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label4.Location = new Point(539, 339);
            label4.Name = "label4";
            label4.Size = new Size(62, 32);
            label4.TabIndex = 15;
            label4.Text = "İsim:";
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox4.Location = new Point(603, 332);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(156, 43);
            textBox4.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label5.Location = new Point(505, 388);
            label5.Name = "label5";
            label5.Size = new Size(96, 32);
            label5.TabIndex = 17;
            label5.Text = "Soyisim";
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox5.Location = new Point(603, 381);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(156, 43);
            textBox5.TabIndex = 16;
            // 
            // RegisterPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1467, 618);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(label4);
            Controls.Add(textBox4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(button);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "RegisterPage";
            Text = "RegisterPage";
            Load += RegisterPage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button;
        private Label label2;
        private Label label1;
        private TextBox textBox2;
        private TextBox textBox1;
        private TextBox textBox3;
        private Label label3;
        private Label label4;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox5;
    }
}