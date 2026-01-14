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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParkingLotFinderPage));
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.FromArgb(76, 175, 80);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.ForeColor = Color.White;
            button1.Location = new Point(825, 483);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(456, 155);
            button1.TabIndex = 1;
            button1.Text = "Otopark Yerini Bul.";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnSorgula_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.None;
            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox1.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox1.Location = new Point(825, 315);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.MaxLength = 10;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(454, 135);
            textBox1.TabIndex = 2;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.White;
            label1.Location = new Point(790, 192);
            label1.Name = "label1";
            label1.Size = new Size(524, 65);
            label1.TabIndex = 3;
            label1.Text = "PARK YERİ SORGULA";
            // 
            // ParkingLotFinderPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(2104, 1020);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            DoubleBuffered = true;
            Margin = new Padding(4, 5, 4, 5);
            Name = "ParkingLotFinderPage";
            Text = "ParkingLotFinderPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private TextBox textBox1;
        private Label label1;
    }
}