namespace OpticalCharacterRecognition
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            pictureBox1 = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            buttonLoad = new Button();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            buttonScan = new Button();
            richTextBox1 = new RichTextBox();
            label3 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label4 = new Label();
            cmbLanguage = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 16);
            label1.Name = "label1";
            label1.Size = new Size(147, 12);
            label1.TabIndex = 0;
            label1.Text = "Выбранное изображение";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(19, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(475, 193);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(19, 230);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(147, 23);
            buttonLoad.TabIndex = 2;
            buttonLoad.Text = "Загрузить изображение";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Location = new Point(500, 31);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(476, 193);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(500, 16);
            label2.Name = "label2";
            label2.Size = new Size(176, 12);
            label2.TabIndex = 4;
            label2.Text = "Подготовленное изображение";
            // 
            // buttonScan
            // 
            buttonScan.Location = new Point(500, 230);
            buttonScan.Name = "buttonScan";
            buttonScan.Size = new Size(147, 23);
            buttonScan.TabIndex = 5;
            buttonScan.Text = "Распознать текст";
            buttonScan.UseVisualStyleBackColor = true;
            buttonScan.Click += buttonScan_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(richTextBox1, 2);
            richTextBox1.Location = new Point(19, 325);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(957, 289);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 306);
            label3.Name = "label3";
            label3.Size = new Size(119, 15);
            label3.TabIndex = 7;
            label3.Text = "Распознанный текст";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(pictureBox2, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonScan, 1, 2);
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Controls.Add(buttonLoad, 0, 2);
            tableLayoutPanel1.Controls.Add(richTextBox1, 0, 6);
            tableLayoutPanel1.Controls.Add(label3, 0, 5);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(cmbLanguage, 0, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(16);
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.818182F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 94.1818161F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 294F));
            tableLayoutPanel1.Size = new Size(995, 633);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 258);
            label4.Name = "label4";
            label4.Size = new Size(128, 15);
            label4.TabIndex = 8;
            label4.Text = "Язык на изображении";
            // 
            // cmbLanguage
            // 
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Location = new Point(19, 279);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(121, 23);
            cmbLanguage.TabIndex = 9;
            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(995, 633);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private OpenFileDialog openFileDialog1;
        private Button buttonLoad;
        private PictureBox pictureBox2;
        private Label label2;
        private Button buttonScan;
        private RichTextBox richTextBox1;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label4;
        private ComboBox cmbLanguage;
    }
}
