using System.Windows.Forms;

namespace Code_Editor
{
    public partial class Form4 : Form
    {
        Form1 form1 = new Form1();
        Form1 form1_ = Application.OpenForms.OfType<Form1>().FirstOrDefault(); //Get reference to Form1 if it's open
        public Form4()
        {
            InitializeComponent();
            if (Screen.PrimaryScreen != null) //Show task bar
            {
                Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
                this.MaximumSize = new Size(workingArea.Width, workingArea.Height);
            }
            form1.show_all_c_and_cpp_files(richTextBox3); //Show all files to user
        }

        //My Function check_path_exists
        public int check_path_exists(string rtb, RichTextBox activity) //Chack path exists or not
        {
            if (rtb != "")
            {
                if (Path.GetFullPath(rtb) == @"C:\" || Path.GetFullPath(rtb) == @"c:\" || Path.GetFullPath(rtb) == @"c:")
                {
                    activity.Text = form1.now_date_time() + " | " + rtb + " is not accessible.";
                    form1.save_activity(activity);
                    return 1;
                }
                else
                {
                    if (Path.Exists(rtb))
                    {
                        return 0;
                    }
                    else
                    {
                        activity.Text = form1.now_date_time() + " | " + rtb + " does not exist.";
                        form1.save_activity(activity);
                        return 1;
                    }
                }
            }
            else
            {
                activity.Text = form1.now_date_time() + " | Location is not specified here.";
                form1.save_activity(activity);
                return 1;
            }
        }

        private void button1_Click(object sender, EventArgs e) //Export
        {
            label1.Focus();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK && check_path_exists(folderBrowserDialog1.SelectedPath, richTextBox4) == 0)
            {
                if (form1.check_file_and_extension(Path.GetFileName(richTextBox1.Text), true, richTextBox4) == 0)
                {
                    if (File.Exists("source_files\\" + Path.GetFileName(richTextBox1.Text)))
                    {
                        File.Copy("source_files\\" + Path.GetFileName(richTextBox1.Text), folderBrowserDialog1.SelectedPath + "\\" + Path.GetFileName(richTextBox1.Text));
                        richTextBox4.Text = form1.now_date_time() + " | " + richTextBox1.Text + " is exported to " + folderBrowserDialog1.SelectedPath + ".";
                        form1.save_activity(richTextBox4);
                    }
                    else if (File.Exists("executable_files\\" + Path.GetFileName(richTextBox1.Text)))
                    {
                        File.Copy("executable_files\\" + Path.GetFileName(richTextBox1.Text), folderBrowserDialog1.SelectedPath + "\\" + Path.GetFileName(richTextBox1.Text));
                        richTextBox4.Text = form1.now_date_time() + " | " + richTextBox1.Text + " is exported to " + folderBrowserDialog1.SelectedPath + ".";
                    }
                    else
                    {
                        richTextBox4.Text = form1.now_date_time() + " | " + richTextBox1.Text + " does not exist.";
                        richTextBox1.Text = "";
                    }
                }
                else
                {
                    richTextBox1.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //Back
        {
            form1_.richTextBox3.Text = "";
            form1.show_all_c_and_cpp_files(form1_.richTextBox3); //Refresh files
            form1_.richTextBox1.Text = richTextBox4.Text; //Update activity
            Close();
        }

        private void button3_Click(object sender, EventArgs e) //Import
        {
            label1.Focus();
            openFileDialog1.Filter = "C|*.c|C++|*.cpp|Java|*.java";
            openFileDialog1.Title = "Select File";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                File.Copy(selectedFilePath, "source_files\\" + Path.GetFileName(selectedFilePath));
                richTextBox4.Text = form1.now_date_time() + " | " + Path.GetFileName(selectedFilePath) + " is imported in Turbine++.";
                form1.save_activity(richTextBox4);
                richTextBox3.Text = "";
                form1.show_all_c_and_cpp_files(richTextBox3);
            }
        }
    }
}