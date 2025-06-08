namespace EE_soundset_tool
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
            generateButton = new Button();
            label1 = new Label();
            fullNameTextBox = new TextBox();
            label3 = new Label();
            authorTextBox = new TextBox();
            saveButton = new Button();
            loadButton = new Button();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // generateButton
            // 
            generateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            generateButton.Location = new Point(747, 608);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(72, 23);
            generateButton.TabIndex = 2;
            generateButton.Text = "Generate";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += Generate;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 3;
            label1.Text = "Mod name:";
            // 
            // fullNameTextBox
            // 
            fullNameTextBox.Location = new Point(86, 12);
            fullNameTextBox.MaxLength = 30;
            fullNameTextBox.Name = "fullNameTextBox";
            fullNameTextBox.Size = new Size(100, 23);
            fullNameTextBox.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(192, 15);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 7;
            label3.Text = "Author:";
            // 
            // authorTextBox
            // 
            authorTextBox.Location = new Point(245, 12);
            authorTextBox.Name = "authorTextBox";
            authorTextBox.Size = new Size(100, 23);
            authorTextBox.TabIndex = 8;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            saveButton.Location = new Point(93, 608);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 9;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += save_Click;
            // 
            // loadButton
            // 
            loadButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            loadButton.Location = new Point(12, 608);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(75, 23);
            loadButton.TabIndex = 10;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += Load_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Location = new Point(12, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(807, 561);
            panel1.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.BackColor = SystemColors.Control;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(807, 561);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(831, 643);
            Controls.Add(panel1);
            Controls.Add(generateButton);
            Controls.Add(loadButton);
            Controls.Add(saveButton);
            Controls.Add(authorTextBox);
            Controls.Add(label3);
            Controls.Add(fullNameTextBox);
            Controls.Add(label1);
            DoubleBuffered = true;
            ImeMode = ImeMode.On;
            Name = "Form1";
            RightToLeft = RightToLeft.No;
            Text = "EE Soundset Tool Assistant";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button generateButton;
        private Label label1;
        private TextBox fullNameTextBox;
        private Label label3;
        private TextBox authorTextBox;
        private Button saveButton;
        private Button loadButton;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
    }
}
