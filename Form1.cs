namespace EE_soundset_tool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ToolTip toolTip = new ToolTip();

                tableLayoutPanel1.ColumnCount = 5;
                tableLayoutPanel1.ColumnStyles.Clear();
                for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
                {
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                }
                tableLayoutPanel1.AutoSize = true;
                tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                tableLayoutPanel1.SuspendLayout();

                tableLayoutPanel1.RowCount = Program.Structures.Count;
                int rowIndex = 0;
                foreach (var item in Program.Structures)
                {     
                    var label = new System.Windows.Forms.Label
                    {
                        Text = item.Description,
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleRight,
                        Dock = DockStyle.Fill,
                        Tag = item.Name
                    };

                    toolTip.SetToolTip(label, GenerateTipText(item));
                    tableLayoutPanel1.Controls.Add(label, 0, rowIndex);

                    var textBox = new TextBox { Text = "", Width = 200, TextAlign = HorizontalAlignment.Center };
                    tableLayoutPanel1.Controls.Add(textBox, 1, rowIndex);

                    var fileTextBox = new TextBox { Width = 200, ReadOnly = true, TextAlign = HorizontalAlignment.Center, AllowDrop = true };
                    fileTextBox.DragEnter += (s, e) =>
                    {
                        if (e.Data.GetDataPresent(DataFormats.FileDrop))
                            e.Effect = DragDropEffects.Copy;
                        else
                            e.Effect = DragDropEffects.None;
                    };

                    fileTextBox.DragDrop += (s, e) =>
                    {
                        string[]? files = e.Data.GetData(DataFormats.FileDrop) as string[];
                        if (files.Length == 0)
                            return;
                        fileTextBox.Text = files[0]; // Wstaw pierwszą ścieżkę
                    };

                    tableLayoutPanel1.Controls.Add(fileTextBox, 2, rowIndex);

                    var button = new Button { Text = "Select File", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter };
                    button.Click += (sender, e) =>
                    {
                        using (OpenFileDialog openFileDialog = new())
                        {
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                if (sender is not Button clickedButton)
                                    return;
                                var pos = tableLayoutPanel1.GetPositionFromControl(clickedButton);

                                var fileTextBox = tableLayoutPanel1.GetControlFromPosition(2, pos.Row) as TextBox;
                                if (fileTextBox != null)
                                    fileTextBox.Text = openFileDialog.FileName;
                            }
                        }
                    };
                    tableLayoutPanel1.Controls.Add(button, 3, rowIndex);


                    var clearButton = new Button { Text = "Clear", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter };
                    clearButton.Click += (sender, e) =>
                    {
                        var clickedButton = sender as Button;
                        if (clickedButton == null) 
                            return;

                        var pos = tableLayoutPanel1.GetPositionFromControl(clickedButton);

                        if (tableLayoutPanel1.GetControlFromPosition(2, pos.Row) is TextBox fileTextBoxToClear)
                            fileTextBoxToClear.Clear();
                    };
                    tableLayoutPanel1.Controls.Add(clearButton, 4, rowIndex);

                    ++rowIndex;
                }

                tableLayoutPanel1.ResumeLayout();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var data = SettingsManager.Load();
            FillForms(data);
        }

        private static string GenerateTipText(Structure item)
        {
            string tip = new string("[" + item.Name + "]");
            if (item.Tip.Length > 0)
                tip = item.Tip + "\n" + tip;
            return tip;
        }

        private void Generate(object sender, EventArgs e)
        {
            List<DataItem> dataItems = new List<DataItem>();
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
            {
                if (tableLayoutPanel1.GetControlFromPosition(0, i) is System.Windows.Forms.Label label && 
                    tableLayoutPanel1.GetControlFromPosition(1, i) is TextBox textBox1 && 
                    tableLayoutPanel1.GetControlFromPosition(2, i) is TextBox textBox2)
                {
                    DataItem dataItem = new(label.Name, textBox1.Text, textBox2.Text, label.Tag as String);
                    dataItems.Add(dataItem);
                }
            }

            var validator = new Validator(dataItems);
            if (!validator.Validate(out string error))
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FileEditor fileGenerator = new();
            if (!fileGenerator.Edit(dataItems, fullNameTextBox.Text, authorTextBox.Text))
            {
                MessageBox.Show("An unexpected error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("DONE!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            List<DataItem> dataItems = [];
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
            {
                if (tableLayoutPanel1.GetControlFromPosition(0, i) is System.Windows.Forms.Label label && 
                    tableLayoutPanel1.GetControlFromPosition(1, i) is TextBox textBox1 && 
                    tableLayoutPanel1.GetControlFromPosition(2, i) is TextBox textBox2)
                {
                    var dataItem = new DataItem(label.Text, textBox1.Text, textBox2.Text, label.Tag as String);
                    dataItems.Add(dataItem);
                }
            }
            SettingsManager.Save(new FormData(fullNameTextBox.Text, authorTextBox.Text, dataItems));
        }

        private void Load_Click(object sender, EventArgs e)
        {
            var data = SettingsManager.Load();
            FillForms(data);
        }

        private void FillForms(FormData data)
        {
            if (data == null)
                return;

            for (int i = 0; i < tableLayoutPanel1.RowCount && i < data.Items.Count; i++)
            {
                if (tableLayoutPanel1.GetControlFromPosition(1, i) is TextBox textBox1)
                    textBox1.Text = data.Items[i].Text;

                if (tableLayoutPanel1.GetControlFromPosition(2, i) is TextBox textBox2)
                    textBox2.Text = data.Items[i].Path;
            }
            fullNameTextBox.Text = data.LongName;
            authorTextBox.Text = data.Author;
        }
    }
}
