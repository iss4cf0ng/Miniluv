namespace Assimilation
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            TreeNode treeNode3 = new TreeNode("Host");
            TreeNode treeNode4 = new TreeNode("Router");
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton9 = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            splitContainer1 = new SplitContainer();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            splitContainer2 = new SplitContainer();
            treeView1 = new TreeView();
            toolStrip2 = new ToolStrip();
            toolStripButton2 = new ToolStripButton();
            listView2 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            toolStrip3 = new ToolStrip();
            toolStripButton3 = new ToolStripButton();
            toolStripButton7 = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButton4 = new ToolStripButton();
            toolStripButton5 = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButton6 = new ToolStripButton();
            toolStripButton8 = new ToolStripButton();
            textBox1 = new TextBox();
            tabPage3 = new TabPage();
            tabControl2 = new TabControl();
            tabPage4 = new TabPage();
            splitContainer3 = new SplitContainer();
            treeView2 = new TreeView();
            toolStrip5 = new ToolStrip();
            toolStripButton10 = new ToolStripButton();
            listView3 = new ListView();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            textBox2 = new TextBox();
            toolStrip4 = new ToolStrip();
            tabPage5 = new TabPage();
            listView1 = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            splitContainer4 = new SplitContainer();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            toolStrip2.SuspendLayout();
            toolStrip3.SuspendLayout();
            tabPage3.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            toolStrip5.SuspendLayout();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Font = new Font("Microsoft JhengHei UI", 11.25F);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton9 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1029, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "toolStripButton1";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripButton9
            // 
            toolStripButton9.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton9.Image = (Image)resources.GetObject("toolStripButton9.Image");
            toolStripButton9.ImageTransparentColor = Color.Magenta;
            toolStripButton9.Name = "toolStripButton9";
            toolStripButton9.Size = new Size(23, 22);
            toolStripButton9.Text = "toolStripButton9";
            // 
            // statusStrip1
            // 
            statusStrip1.Font = new Font("Microsoft JhengHei UI", 11.25F);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 546);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 18, 0);
            statusStrip1.Size = new Size(1029, 24);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(158, 19);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 25);
            splitContainer1.Margin = new Padding(4);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(listView1);
            splitContainer1.Size = new Size(1029, 521);
            splitContainer1.SplitterDistance = 343;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 2;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1029, 343);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(splitContainer2);
            tabPage1.Location = new Point(4, 28);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1021, 311);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Network";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.FixedPanel = FixedPanel.Panel1;
            splitContainer2.Location = new Point(3, 3);
            splitContainer2.Margin = new Padding(4);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(treeView1);
            splitContainer2.Panel1.Controls.Add(toolStrip2);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(listView2);
            splitContainer2.Panel2.Controls.Add(toolStrip3);
            splitContainer2.Panel2.Controls.Add(textBox1);
            splitContainer2.Size = new Size(1015, 305);
            splitContainer2.SplitterDistance = 298;
            splitContainer2.SplitterWidth = 5;
            splitContainer2.TabIndex = 0;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(0, 25);
            treeView1.Name = "treeView1";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Host";
            treeNode4.Name = "Node1";
            treeNode4.Text = "Router";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode3, treeNode4 });
            treeView1.Size = new Size(298, 280);
            treeView1.TabIndex = 0;
            // 
            // toolStrip2
            // 
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripButton2 });
            toolStrip2.Location = new Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(298, 25);
            toolStrip2.TabIndex = 1;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(23, 22);
            toolStripButton2.Text = "toolStripButton2";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // listView2
            // 
            listView2.CheckBoxes = true;
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listView2.Dock = DockStyle.Fill;
            listView2.FullRowSelect = true;
            listView2.Location = new Point(0, 26);
            listView2.Name = "listView2";
            listView2.Size = new Size(712, 252);
            listView2.TabIndex = 2;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Mode";
            columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "IPv4 Address";
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "MAC Address";
            columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Status";
            columnHeader4.Width = 120;
            // 
            // toolStrip3
            // 
            toolStrip3.Font = new Font("Microsoft JhengHei UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            toolStrip3.Items.AddRange(new ToolStripItem[] { toolStripButton3, toolStripButton7, toolStripSeparator1, toolStripButton4, toolStripButton5, toolStripSeparator2, toolStripButton6, toolStripButton8 });
            toolStrip3.Location = new Point(0, 0);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Size = new Size(712, 26);
            toolStrip3.TabIndex = 0;
            toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(108, 23);
            toolStripButton3.Text = "ARP spoofing";
            toolStripButton3.Click += toolStripButton3_Click;
            // 
            // toolStripButton7
            // 
            toolStripButton7.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton7.Image = (Image)resources.GetObject("toolStripButton7.Image");
            toolStripButton7.ImageTransparentColor = Color.Magenta;
            toolStripButton7.Name = "toolStripButton7";
            toolStripButton7.Size = new Size(111, 23);
            toolStripButton7.Text = "Stop spoofing";
            toolStripButton7.Click += toolStripButton7_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 26);
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(77, 23);
            toolStripButton4.Text = "Check All";
            toolStripButton4.Click += toolStripButton4_Click;
            // 
            // toolStripButton5
            // 
            toolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton5.Image = (Image)resources.GetObject("toolStripButton5.Image");
            toolStripButton5.ImageTransparentColor = Color.Magenta;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Size = new Size(94, 23);
            toolStripButton5.Text = "Uncheck All";
            toolStripButton5.Click += toolStripButton5_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 26);
            // 
            // toolStripButton6
            // 
            toolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton6.Image = (Image)resources.GetObject("toolStripButton6.Image");
            toolStripButton6.ImageTransparentColor = Color.Magenta;
            toolStripButton6.Name = "toolStripButton6";
            toolStripButton6.Size = new Size(107, 23);
            toolStripButton6.Text = "SYN flooding";
            toolStripButton6.Click += toolStripButton6_Click;
            // 
            // toolStripButton8
            // 
            toolStripButton8.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton8.Image = (Image)resources.GetObject("toolStripButton8.Image");
            toolStripButton8.ImageTransparentColor = Color.Magenta;
            toolStripButton8.Name = "toolStripButton8";
            toolStripButton8.Size = new Size(109, 23);
            toolStripButton8.Text = "Stop flooding";
            toolStripButton8.Click += toolStripButton8_Click;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Bottom;
            textBox1.Location = new Point(0, 278);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(712, 27);
            textBox1.TabIndex = 1;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(tabControl2);
            tabPage3.Location = new Point(4, 28);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1021, 311);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Sniffer";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage4);
            tabControl2.Controls.Add(tabPage5);
            tabControl2.Dock = DockStyle.Fill;
            tabControl2.Location = new Point(0, 0);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(1021, 311);
            tabControl2.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(splitContainer3);
            tabPage4.Location = new Point(4, 28);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1013, 279);
            tabPage4.TabIndex = 0;
            tabPage4.Text = "Thought Police";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.FixedPanel = FixedPanel.Panel1;
            splitContainer3.Location = new Point(3, 3);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(treeView2);
            splitContainer3.Panel1.Controls.Add(toolStrip5);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(listView3);
            splitContainer3.Panel2.Controls.Add(textBox2);
            splitContainer3.Panel2.Controls.Add(toolStrip4);
            splitContainer3.Size = new Size(1007, 273);
            splitContainer3.SplitterDistance = 280;
            splitContainer3.TabIndex = 0;
            // 
            // treeView2
            // 
            treeView2.Dock = DockStyle.Fill;
            treeView2.Location = new Point(0, 25);
            treeView2.Name = "treeView2";
            treeView2.Size = new Size(280, 248);
            treeView2.TabIndex = 0;
            // 
            // toolStrip5
            // 
            toolStrip5.Items.AddRange(new ToolStripItem[] { toolStripButton10 });
            toolStrip5.Location = new Point(0, 0);
            toolStrip5.Name = "toolStrip5";
            toolStrip5.Size = new Size(280, 25);
            toolStrip5.TabIndex = 1;
            toolStrip5.Text = "toolStrip5";
            // 
            // toolStripButton10
            // 
            toolStripButton10.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton10.Image = (Image)resources.GetObject("toolStripButton10.Image");
            toolStripButton10.ImageTransparentColor = Color.Magenta;
            toolStripButton10.Name = "toolStripButton10";
            toolStripButton10.Size = new Size(23, 22);
            toolStripButton10.Text = "toolStripButton10";
            toolStripButton10.Click += toolStripButton10_Click;
            // 
            // listView3
            // 
            listView3.Columns.AddRange(new ColumnHeader[] { columnHeader7, columnHeader8 });
            listView3.Dock = DockStyle.Fill;
            listView3.FullRowSelect = true;
            listView3.Location = new Point(0, 25);
            listView3.Name = "listView3";
            listView3.Size = new Size(723, 221);
            listView3.TabIndex = 2;
            listView3.UseCompatibleStateImageBehavior = false;
            listView3.View = View.Details;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Name";
            columnHeader7.Width = 150;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Filter";
            columnHeader8.Width = 200;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Bottom;
            textBox2.Location = new Point(0, 246);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(723, 27);
            textBox2.TabIndex = 1;
            // 
            // toolStrip4
            // 
            toolStrip4.Location = new Point(0, 0);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.Size = new Size(723, 25);
            toolStrip4.TabIndex = 0;
            toolStrip4.Text = "toolStrip4";
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(splitContainer4);
            tabPage5.Location = new Point(4, 28);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1013, 279);
            tabPage5.TabIndex = 1;
            tabPage5.Text = "Password";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6 });
            listView1.Dock = DockStyle.Fill;
            listView1.FullRowSelect = true;
            listView1.Location = new Point(0, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(1029, 173);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Date";
            columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Message";
            columnHeader6.Width = 500;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(3, 3);
            splitContainer4.Name = "splitContainer4";
            splitContainer4.Size = new Size(1007, 273);
            splitContainer4.SplitterDistance = 335;
            splitContainer4.TabIndex = 0;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 570);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Font = new Font("Microsoft JhengHei UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            Margin = new Padding(4);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Miniluv";
            Load += frmMain_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
            splitContainer3.Panel2.ResumeLayout(false);
            splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            toolStrip5.ResumeLayout(false);
            toolStrip5.PerformLayout();
            tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private StatusStrip statusStrip1;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private TreeView treeView1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private ListView listView1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripButton toolStripButton1;
        private ToolStrip toolStrip2;
        private ToolStripButton toolStripButton2;
        private ListView listView2;
        private TextBox textBox1;
        private ToolStrip toolStrip3;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton6;
        private ToolStripButton toolStripButton7;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton8;
        private ToolStripButton toolStripButton9;
        private SplitContainer splitContainer3;
        private TreeView treeView2;
        private ListView listView3;
        private TextBox textBox2;
        private ToolStrip toolStrip4;
        private TabPage tabPage3;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ToolStrip toolStrip5;
        private ToolStripButton toolStripButton10;
        private TabControl tabControl2;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private SplitContainer splitContainer4;
    }
}
