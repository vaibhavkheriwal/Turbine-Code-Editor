using System.Diagnostics;
namespace Code_Editor
{
    public partial class Form3 : Form
    {
        Form1 form1 = new Form1();
        Form1 form1_ = Application.OpenForms.OfType<Form1>().FirstOrDefault(); //Get reference to Form1 if it's open
        public Form3()
        {
            InitializeComponent();
            if (Screen.PrimaryScreen != null) //Show task bar
            {
                Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
                this.MaximumSize = new Size(workingArea.Width, workingArea.Height);
            }
        }

        private void button2_Click(object sender, EventArgs e) //Exit
        {
            richTextBox2.Text = form1.now_date_time() + " | Turbine++ has closed." + Environment.NewLine;
            form1.save_activity(richTextBox2);
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e) //Save
        {
            label1.Focus();
            File.WriteAllText("source_files\\" + richTextBox4.Text, richTextBox1.Text);
            richTextBox2.Text = form1.now_date_time() + " | " + richTextBox4.Text + " has been saved.";
            form1.save_activity(richTextBox2);
        }

        private void button7_Click(object sender, EventArgs e) //Minimize
        {
            label1.Focus();
            WindowState = FormWindowState.Minimized;
            foreach (Form form in OwnedForms)
            {
                form.WindowState = WindowState = FormWindowState.Minimized;
            }
        }

        private void button8_Click(object sender, EventArgs e) //Menu
        {
            form1_.richTextBox1.Text = richTextBox2.Text;
            Close();
        }

        private void button9_Click(object sender, EventArgs e) //Run
        {
            label1.Focus();
            richTextBox2.Text = form1.now_date_time() + " | " + richTextBox4.Text + " has run.";
            form1.save_activity(richTextBox2);
            if (Path.GetExtension(richTextBox4.Text) == ".java") //Run java
            {
                string javaFileName = Path.GetFileName(richTextBox4.Text);
                string sourceFilePath = $@"source_files\{javaFileName}";
                string outputDirectory = "executable_files";
                string outputFileName = Path.GetFileNameWithoutExtension(javaFileName);
                string command = $@"/k javac -d ""{outputDirectory}"" ""{sourceFilePath}"" && cd ""{outputDirectory}"" && color F0 && java ""{outputFileName}""";
                if (this.BackColor == Color.FromArgb(50, 50, 50))
                {
                    command = $@"/k javac -d ""{outputDirectory}"" ""{sourceFilePath}"" && cd ""{outputDirectory}"" && java ""{outputFileName}""";
                }
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = command,
                    UseShellExecute = true,
                    CreateNoWindow = false
                };
                Process cmdProcess = new Process //Start the command prompt process
                {
                    StartInfo = processStartInfo
                };
                cmdProcess.Start(); //Start cmd
            }
            else if (Path.GetExtension(richTextBox4.Text) == ".c") //Run c
            {
                string outputFile = Path.GetFileNameWithoutExtension(richTextBox4.Text) + ".exe";
                string sourceFilePath = $@"{Directory.GetCurrentDirectory()}\source_files\{Path.GetFileName(richTextBox4.Text)}";
                string outputFilePath = $@"{Directory.GetCurrentDirectory()}\executable_files\{Path.GetFileName(outputFile)}";
                string command = $@"/k gcc ""{sourceFilePath}"" -o ""{outputFilePath}"" && color F0 && ""{outputFilePath}""";
                if (this.BackColor == Color.FromArgb(50, 50, 50))
                {
                    command = $@"/k gcc ""{sourceFilePath}"" -o ""{outputFilePath}"" && ""{outputFilePath}""";
                }
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = command,
                    UseShellExecute = true,
                    CreateNoWindow = false,

                };
                Process cmdProcess = new Process
                {
                    StartInfo = processStartInfo
                };
                cmdProcess.Start();
            }
            else //Run c++
            {
                string outputFile = Path.GetFileNameWithoutExtension(richTextBox4.Text) + ".exe";
                string sourceFilePath = $@"{Directory.GetCurrentDirectory()}\source_files\{Path.GetFileName(richTextBox4.Text)}";
                string outputFilePath = $@"{Directory.GetCurrentDirectory()}\executable_files\{Path.GetFileName(outputFile)}";
                string command = $@"/k g++ ""{sourceFilePath}"" -o ""{outputFilePath}"" && color F0 && ""{outputFilePath}""";
                if (this.BackColor == Color.FromArgb(50, 50, 50))
                {
                    command = $@"/k g++ ""{sourceFilePath}"" -o ""{outputFilePath}"" && ""{outputFilePath}""";
                }
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = command,
                    UseShellExecute = true,
                    CreateNoWindow = false
                };
                Process cmdProcess = new Process
                {
                    StartInfo = processStartInfo
                };
                cmdProcess.Start();
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '{')
            {
                int cursorPosition = richTextBox1.SelectionStart; //Get the current position of the cursor
                richTextBox1.Text = richTextBox1.Text.Insert(cursorPosition, "{}"); //Insert the braces at the cursor position
                richTextBox1.SelectionStart = cursorPosition + 1; //Move the cursor to between the braces
                e.Handled = true; //Prevent the default handling of the key press event
            }
            if (e.KeyChar == '(')
            {
                int cursorPosition = richTextBox1.SelectionStart;
                richTextBox1.Text = richTextBox1.Text.Insert(cursorPosition, "()");
                richTextBox1.SelectionStart = cursorPosition + 1;
                e.Handled = true;
            }
            if (e.KeyChar == '[')
            {
                int cursorPosition = richTextBox1.SelectionStart;
                richTextBox1.Text = richTextBox1.Text.Insert(cursorPosition, "[]");
                richTextBox1.SelectionStart = cursorPosition + 1;
                e.Handled = true;
            }
            if (e.KeyChar == '\'')
            {
                int cursorPosition = richTextBox1.SelectionStart;
                richTextBox1.Text = richTextBox1.Text.Insert(cursorPosition, "''");
                richTextBox1.SelectionStart = cursorPosition + 1;
                e.Handled = true;
            }
            if (e.KeyChar == '"')
            {
                int cursorPosition = richTextBox1.SelectionStart;
                richTextBox1.Text = richTextBox1.Text.Insert(cursorPosition, "\"\"");
                richTextBox1.SelectionStart = cursorPosition + 1;
                e.Handled = true;
            }
            if (e.KeyChar == '<')
            {
                int cursorPosition = richTextBox1.SelectionStart;
                richTextBox1.Text = richTextBox1.Text.Insert(cursorPosition, "<>");
                richTextBox1.SelectionStart = cursorPosition + 1;
                e.Handled = true;
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e) //Stop pasting formatted text
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                if (Clipboard.ContainsText())
                {
                    string text = Clipboard.GetText();
                    richTextBox1.SelectedText = text;
                }
            }
        }
    }
}