namespace Code_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (Properties.Settings.Default.dark)
            {
                button1.BackColor = Color.FromArgb(60, 64, 64);
                button2.BackColor = Color.FromArgb(60, 64, 64);
                button3.BackColor = Color.FromArgb(60, 64, 64);
                button4.BackColor = Color.FromArgb(60, 64, 64);
                button5.BackColor = Color.FromArgb(60, 64, 64);
                button6.BackColor = Color.FromArgb(60, 64, 64);
                button7.BackColor = Color.FromArgb(60, 64, 64);
                button8.BackColor = Color.FromArgb(60, 64, 64);
                button9.BackColor = Color.FromArgb(60, 64, 64);
                button10.BackColor = Color.FromArgb(60, 64, 64);
                richTextBox1.BackColor = Color.FromArgb(60, 64, 64);
                richTextBox2.BackColor = Color.FromArgb(60, 64, 64);
                richTextBox3.BackColor = Color.FromArgb(60, 64, 64);
                richTextBox1.ForeColor = Color.Gainsboro;
                richTextBox2.ForeColor = Color.White;
                richTextBox3.ForeColor = Color.Gainsboro;
                label1.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                this.BackColor = Color.FromArgb(50, 50, 50);
                button9.Text = "\U0001F311";
            }
            show_all_c_and_cpp_files(richTextBox3);
            if (Screen.PrimaryScreen != null) //Show task bar
            {
                Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
                this.MaximumSize = new Size(workingArea.Width, workingArea.Height);
            }
            this.Load += show_first_time;
        }

        //My Function show_first_time
        private void show_first_time(object sender, EventArgs e) //To save "Turbine++ started." only first time
        {
            richTextBox1.Text = now_date_time() + " | Turbine++ started.";
            save_activity(richTextBox1);
        }

        //My Function now_date_time
        public DateTime now_date_time() //To get date and time
        {
            DateTime dt = DateTime.Now;
            return dt;
        }

        //My Function save_activity
        public void save_activity(RichTextBox activity) //To save activity in activity.txt
        {
            File.AppendAllText("activity.txt", activity.Text + Environment.NewLine);
        }

        //My Function show_all_c_and_cpp_files
        public void show_all_c_and_cpp_files(RichTextBox rtb) //Use this to show all c, cpp, java, class and exe
        {
            string[] cFiles = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\source_files", "*.c"); //Get all .c files in the directory
            string[] cppFiles = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\source_files", "*.cpp"); //Get all .cpp files in the directory
            string[] javaFiles = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\source_files", "*.java"); //Get all .java files in the directory
            string[] classFiles = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\executable_files", "*.class"); //Get all .class files in the directory
            string[] exeFiles = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\executable_files", "*.exe"); //Get all .exe files in the directory
            foreach (string file in cFiles) //Print files
            {
                rtb.Text = rtb.Text + Path.GetFileName(file) + "\n";
            }
            foreach (string file in cppFiles) //Print files
            {
                rtb.Text = rtb.Text + Path.GetFileName(file) + "\n";
            }
            foreach (string file in javaFiles) //Print files
            {
                rtb.Text = rtb.Text + Path.GetFileName(file) + "\n";
            }
            foreach (string file in classFiles) //Print files
            {
                rtb.Text = rtb.Text + Path.GetFileName(file) + "\n";
            }
            foreach (string file in exeFiles) //Print files
            {
                rtb.Text = rtb.Text + Path.GetFileName(file) + "\n";
            }
        }

        //My Function check_file_and_extension
        public int check_file_and_extension(string fileNameWithExtension, bool alsoSearchForExecutableFile, RichTextBox activity) //Check for file name correct format
        {
            if (Path.GetFileName(fileNameWithExtension) != "")
            {
                if (alsoSearchForExecutableFile)
                {
                    if (Path.GetExtension(fileNameWithExtension) == ".c" || Path.GetExtension(fileNameWithExtension) == ".cpp" || Path.GetExtension(fileNameWithExtension) == ".java" || Path.GetExtension(fileNameWithExtension) == ".class" || Path.GetExtension(fileNameWithExtension) == ".exe")
                    {
                        if (Path.GetFileNameWithoutExtension(fileNameWithExtension) != "")
                        {
                            return 0;
                        }
                        else
                        {
                            activity.Text = now_date_time() + " | The extension is specified here, but the file name is not.";
                            save_activity(activity);
                            return 1;
                        }
                    }
                    else
                    {
                        activity.Text = now_date_time() + " | Right extension is not specified here.";
                        save_activity(activity);
                        return 1;
                    }
                }
                else
                {
                    if (Path.GetExtension(fileNameWithExtension) == ".c" || Path.GetExtension(fileNameWithExtension) == ".cpp" || Path.GetExtension(fileNameWithExtension) == ".java")
                    {
                        if (Path.GetFileNameWithoutExtension(fileNameWithExtension) != "")
                        {
                            return 0;
                        }
                        else
                        {
                            activity.Text = now_date_time() + " | The extension is specified here, but the file name is not.";
                            save_activity(activity);
                            return 1;
                        }
                    }
                    else
                    {
                        activity.Text = now_date_time() + " | Right extension is not specified here.";
                        save_activity(activity);
                        return 1;
                    }
                }
            }
            else
            {
                activity.Text = now_date_time() + " | File name is not specified here.";
                save_activity(activity);
                return 1;
            }
        }

        private void button1_Click(object sender, EventArgs e) //Open
        {
            label1.Focus();
            if (check_file_and_extension("source_files\\" + Path.GetFileName(richTextBox2.Text), false, richTextBox1) == 0 && File.Exists("source_files\\" + Path.GetFileName(richTextBox2.Text)))
            {
                string fileData = File.ReadAllText("source_files\\" + Path.GetFileName(richTextBox2.Text));
                Form3 codeEditor = new Form3();
                if (fileData != null)
                {
                    codeEditor.richTextBox1.Text = fileData;
                }
                else
                {
                    File.WriteAllText("source_files\\" + Path.GetFileName(richTextBox2.Text), "");
                }
                codeEditor.richTextBox4.Text = richTextBox2.Text;
                richTextBox1.Text = now_date_time() + " | " + richTextBox2.Text + " is opened.";
                save_activity(richTextBox1);
                codeEditor.richTextBox2.Text = richTextBox1.Text;
                if (Properties.Settings.Default.dark)
                {
                    codeEditor.BackColor = Color.FromArgb(50, 50, 50);
                    codeEditor.button2.BackColor = Color.FromArgb(60, 64, 64);
                    codeEditor.button3.BackColor = Color.FromArgb(60, 64, 64);
                    codeEditor.button7.BackColor = Color.FromArgb(60, 64, 64);
                    codeEditor.button8.BackColor = Color.FromArgb(60, 64, 64);
                    codeEditor.button9.BackColor = Color.FromArgb(60, 64, 64);
                    codeEditor.richTextBox1.BackColor = Color.FromArgb(60, 64, 64);
                    codeEditor.richTextBox2.BackColor = Color.FromArgb(60, 64, 64);
                    codeEditor.richTextBox4.BackColor = Color.FromArgb(60, 64, 64);
                    if (Properties.Settings.Default.default_color == true)
                    {
                        codeEditor.richTextBox1.ForeColor = Color.White;
                    }
                    else
                    {
                        codeEditor.richTextBox1.ForeColor = Properties.Settings.Default.font_color;
                    }
                    codeEditor.richTextBox2.ForeColor = Color.Gainsboro;
                    codeEditor.richTextBox4.ForeColor = Color.Gainsboro;
                    codeEditor.label1.ForeColor = Color.White;
                }
                else
                {
                    if (Properties.Settings.Default.default_color == true)
                    {
                        codeEditor.richTextBox1.ForeColor = SystemColors.WindowText;
                    }
                    else
                    {
                        codeEditor.richTextBox1.ForeColor = Properties.Settings.Default.font_color;
                    }
                }
                if (Properties.Settings.Default.default_font == false)
                {
                    codeEditor.richTextBox1.Font = Properties.Settings.Default.font_style;
                }
                codeEditor.ShowDialog();
            }
            else
            {
                check_file_and_extension(Path.GetFileName(richTextBox2.Text), false, richTextBox1);
                save_activity(richTextBox1);
                richTextBox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e) //Exit
        {
            richTextBox1.Text = now_date_time() + " | Turbine++ closed." + Environment.NewLine + Environment.NewLine;
            save_activity(richTextBox1);
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e) //Export\Import
        {
            label1.Focus();
            Form4 export = new Form4();
            export.richTextBox4.Text = richTextBox1.Text;
            if (Properties.Settings.Default.dark)
            {
                export.BackColor = Color.FromArgb(50, 50, 50);
                export.button1.BackColor = Color.FromArgb(60, 64, 64);
                export.button2.BackColor = Color.FromArgb(60, 64, 64);
                export.button3.BackColor = Color.FromArgb(60, 64, 64);
                export.richTextBox1.BackColor = Color.FromArgb(60, 64, 64);
                export.richTextBox3.BackColor = Color.FromArgb(60, 64, 64);
                export.richTextBox4.BackColor = Color.FromArgb(60, 64, 64);
                export.richTextBox1.ForeColor = Color.White;
                export.richTextBox3.ForeColor = Color.Gainsboro;
                export.richTextBox4.ForeColor = Color.Gainsboro;
                export.label1.ForeColor = Color.White;
                export.label2.ForeColor = Color.White;
                export.label3.ForeColor = Color.White;
                export.label5.ForeColor = Color.White;
            }
            export.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e) //Help
        {
            label1.Focus();
            Form2 help = new Form2();
            if (Properties.Settings.Default.dark)
            {
                help.BackColor = Color.FromArgb(50, 50, 50);
                help.button1.BackColor = Color.FromArgb(60, 64, 64);
                help.button2.BackColor = Color.FromArgb(60, 64, 64);
                help.richTextBox5.BackColor = Color.FromArgb(60, 64, 64);
                help.richTextBox5.ForeColor = Color.Gainsboro;
                help.label1.ForeColor = Color.White;
            }
            help.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e) //Create
        {
            label1.Focus();
            if (check_file_and_extension(Path.GetFileName(richTextBox2.Text), false, richTextBox1) == 0 && File.Exists("source_files\\" + Path.GetFileName(richTextBox2.Text)) == false)
            {
                File.WriteAllText("source_files\\" + Path.GetFileName(richTextBox2.Text), "");
                richTextBox3.Text = ""; //Clear show file
                show_all_c_and_cpp_files(richTextBox3);
                richTextBox1.Text = now_date_time() + " | " + richTextBox2.Text + " is created.";
                save_activity(richTextBox1);
            }
            else if (File.Exists("source_files\\" + Path.GetFileName(richTextBox2.Text)) == true)
            {
                richTextBox1.Text = now_date_time() + " | " + richTextBox2.Text + " exists.";
                save_activity(richTextBox1);
                richTextBox2.Text = "";
            }
            else
            {
                check_file_and_extension(Path.GetFileName(richTextBox2.Text), false, richTextBox1);
                save_activity(richTextBox1);
                richTextBox2.Text = "";
            }
        }

        private void button6_Click(object sender, EventArgs e) //Delete
        {
            label1.Focus();
            if (check_file_and_extension(Path.GetFileName(richTextBox2.Text), false, richTextBox1) == 0 && File.Exists("source_files\\" + Path.GetFileName(richTextBox2.Text)) != false)
            {
                File.Delete("source_files\\" + Path.GetFileName(richTextBox2.Text));
                richTextBox1.Text = now_date_time() + " | " + richTextBox2.Text + " has been deleted.";
                save_activity(richTextBox1);
            }
            else if (check_file_and_extension(Path.GetFileName(richTextBox2.Text), true, richTextBox1) == 0 && File.Exists("executable_files\\" + Path.GetFileName(richTextBox2.Text)) != false && Path.GetExtension(Path.GetFileName(richTextBox2.Text)) == ".class" || Path.GetExtension(Path.GetFileName(richTextBox2.Text)) == ".exe")
            {
                File.Delete("executable_files\\" + Path.GetFileName(richTextBox2.Text));
                richTextBox1.Text = now_date_time() + " | " + richTextBox2.Text + " has been deleted.";
                save_activity(richTextBox1);
            }
            else
            {
                check_file_and_extension(Path.GetFileName(richTextBox2.Text), false, richTextBox1);
                save_activity(richTextBox1);
            }
            richTextBox3.Text = ""; //Clear show file
            show_all_c_and_cpp_files(richTextBox3);
            richTextBox2.Text = ""; //Clear file name input
        }

        private void button7_Click(object sender, EventArgs e) //Minimize
        {
            label1.Focus();
            WindowState = FormWindowState.Minimized;
        }

        private void button8_Click(object sender, EventArgs e) //Activity
        {
            label1.Focus();
            Form2 activity = new Form2();
            activity.Text = "Activity";
            activity.button1.Enabled = true;
            activity.button1.Visible = true;
            activity.richTextBox5.Text = File.ReadAllText("activity.txt");
            if (Properties.Settings.Default.dark)
            {
                activity.BackColor = Color.FromArgb(50, 50, 50);
                activity.button1.BackColor = Color.FromArgb(60, 64, 64);
                activity.button2.BackColor = Color.FromArgb(60, 64, 64);
                activity.richTextBox5.BackColor = Color.FromArgb(60, 64, 64);
                activity.richTextBox5.ForeColor = Color.Gainsboro;
                activity.label1.ForeColor = Color.White;
            }
            activity.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e) //Dark mode on\off
        {
            if (Properties.Settings.Default.dark)
            {
                label1.Focus();
                button1.BackColor = Color.DimGray;
                button2.BackColor = Color.DimGray;
                button3.BackColor = Color.DimGray;
                button4.BackColor = Color.DimGray;
                button5.BackColor = Color.DimGray;
                button6.BackColor = Color.DimGray;
                button7.BackColor = Color.DimGray;
                button8.BackColor = Color.DimGray;
                button9.BackColor = Color.DimGray;
                button10.BackColor = Color.DimGray;
                richTextBox1.BackColor = SystemColors.Control;
                richTextBox2.BackColor = SystemColors.Control;
                richTextBox3.BackColor = SystemColors.Control;
                richTextBox1.ForeColor = Color.DimGray;
                richTextBox2.ForeColor = Color.Black;
                richTextBox3.ForeColor = Color.DimGray;
                label1.ForeColor = SystemColors.ControlText;
                label3.ForeColor = SystemColors.ControlText;
                label4.ForeColor = SystemColors.ControlText;
                this.BackColor = SystemColors.ControlLight;
                button9.Text = "\U0001F311";
                Properties.Settings.Default.dark = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                label1.Focus();
                button1.BackColor = Color.FromArgb(60, 64, 64);
                button2.BackColor = Color.FromArgb(60, 64, 64);
                button3.BackColor = Color.FromArgb(60, 64, 64);
                button4.BackColor = Color.FromArgb(60, 64, 64);
                button5.BackColor = Color.FromArgb(60, 64, 64);
                button6.BackColor = Color.FromArgb(60, 64, 64);
                button7.BackColor = Color.FromArgb(60, 64, 64);
                button8.BackColor = Color.FromArgb(60, 64, 64);
                button9.BackColor = Color.FromArgb(60, 64, 64);
                button10.BackColor = Color.FromArgb(60, 64, 64);
                richTextBox1.BackColor = Color.FromArgb(60, 64, 64);
                richTextBox2.BackColor = Color.FromArgb(60, 64, 64);
                richTextBox3.BackColor = Color.FromArgb(60, 64, 64);
                richTextBox1.ForeColor = Color.Gainsboro;
                richTextBox2.ForeColor = Color.White;
                richTextBox3.ForeColor = Color.Gainsboro;
                label1.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                this.BackColor = Color.FromArgb(50, 50, 50);
                button9.Text = "\U0001F311";
                Properties.Settings.Default.dark = true;
                Properties.Settings.Default.Save();
            }
        }

        private void button10_Click(object sender, EventArgs e) //Settings
        {
            label1.Focus();
            Form5 form5 = new Form5();
            if (Properties.Settings.Default.dark)
            {
                if (Properties.Settings.Default.default_color == true)
                {
                    form5.richTextBox1.ForeColor = Color.White;
                }
                else
                {
                    form5.richTextBox1.ForeColor = Properties.Settings.Default.font_color;
                }
                form5.button1.BackColor = Color.FromArgb(60, 64, 64);
                form5.button2.BackColor = Color.FromArgb(60, 64, 64);
                form5.button3.BackColor = Color.FromArgb(60, 64, 64);
                form5.button9.BackColor = Color.FromArgb(60, 64, 64);
                form5.label1.ForeColor = Color.White;
                form5.label2.ForeColor = Color.White;
                form5.label3.ForeColor = Color.White;
                form5.label4.ForeColor = Color.White;
                form5.BackColor = Color.FromArgb(50, 50, 50);
                form5.richTextBox1.BackColor = Color.FromArgb(60, 64, 64);
            }
            else
            {
                if (Properties.Settings.Default.default_color == true)
                {
                    form5.richTextBox1.ForeColor = SystemColors.WindowText;
                }
                else
                {
                    form5.richTextBox1.ForeColor = Properties.Settings.Default.font_color;
                }
            }
            if (Properties.Settings.Default.default_font == false)
            {
                form5.richTextBox1.Font = Properties.Settings.Default.font_style;
            }
            form5.ShowDialog();
        }

        private void richTextBox2_KeyDown(object sender, KeyEventArgs e) //Stop pasting formatted text
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                if (Clipboard.ContainsText())
                {
                    string text = Clipboard.GetText();
                    richTextBox2.SelectedText = text;
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}