namespace Code_Editor
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            if (Screen.PrimaryScreen != null) //Show task bar
            {
                Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
                this.MaximumSize = new Size(workingArea.Width, workingArea.Height);
            }
        }

        private void button2_Click(object sender, EventArgs e) //Menu
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) //Font
        {
            label1.Focus();
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
                Properties.Settings.Default.font_style = fontDialog1.Font;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.default_font = false;
            }
        }

        private void button9_Click(object sender, EventArgs e) //Font color
        {
            label1.Focus();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
                Properties.Settings.Default.font_color = colorDialog1.Color;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.default_color = false;
            }
        }

        private void button3_Click(object sender, EventArgs e) //Reset
        {
            label1.Focus();
            Properties.Settings.Default.default_color = true;
            Properties.Settings.Default.default_font = true;
            Properties.Settings.Default.Save();
            richTextBox1.Font = new Font("Consolas", 12, FontStyle.Regular);
            if (Properties.Settings.Default.dark)
            {
                richTextBox1.ForeColor = Color.White;
            }
            else
            {
                richTextBox1.ForeColor = SystemColors.WindowText;
            }
        }
    }
}