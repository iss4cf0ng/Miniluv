namespace Assimilation
{
    partial class frmScanIP
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
            label1 = new Label();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            button1 = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            button2 = new Button();
            statusStrip1 = new StatusStrip();
            toolStripProgressBar1 = new ToolStripProgressBar();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            label5 = new Label();
            textBox3 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 15);
            label1.Name = "label1";
            label1.Size = new Size(57, 19);
            label1.TabIndex = 0;
            label1.Text = "Mode :";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(80, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(251, 27);
            comboBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(80, 113);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(251, 27);
            textBox1.TabIndex = 2;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(80, 45);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(105, 27);
            numericUpDown1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(8, 179);
            button1.Name = "button1";
            button1.Size = new Size(323, 45);
            button1.TabIndex = 4;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 116);
            label2.Name = "label2";
            label2.Size = new Size(66, 19);
            label2.TabIndex = 5;
            label2.Text = "Start IP :";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(80, 146);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(251, 27);
            textBox2.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 149);
            label3.Name = "label3";
            label3.Size = new Size(60, 19);
            label3.TabIndex = 7;
            label3.Text = "End IP :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 47);
            label4.Name = "label4";
            label4.Size = new Size(65, 19);
            label4.TabIndex = 8;
            label4.Text = "Thread :";
            // 
            // button2
            // 
            button2.Location = new Point(8, 230);
            button2.Name = "button2";
            button2.Size = new Size(323, 45);
            button2.TabIndex = 9;
            button2.Text = "Stop";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Font = new Font("Microsoft JhengHei UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar1, toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 278);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(343, 24);
            statusStrip1.TabIndex = 10;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 18);
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(158, 19);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(191, 49);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(62, 23);
            radioButton1.TabIndex = 11;
            radioButton1.TabStop = true;
            radioButton1.Text = "CIDR";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(259, 49);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(72, 23);
            radioButton2.TabIndex = 12;
            radioButton2.TabStop = true;
            radioButton2.Text = "Range";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 83);
            label5.Name = "label5";
            label5.Size = new Size(51, 19);
            label5.TabIndex = 14;
            label5.Text = "CIDR :";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(80, 80);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(251, 27);
            textBox3.TabIndex = 13;
            // 
            // frmScanIP
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 302);
            Controls.Add(label5);
            Controls.Add(textBox3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(statusStrip1);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Font = new Font("Microsoft JhengHei UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "frmScanIP";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmScanIP";
            FormClosed += frmScanIP_FormClosed;
            Load += frmScanIP_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private NumericUpDown numericUpDown1;
        private Button button1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private Label label4;
        private Button button2;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label label5;
        private TextBox textBox3;
    }
}