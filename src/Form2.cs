namespace Code_Editor
{
    public partial class Form2 : Form
    {
        Form1 form1 = new Form1();
        public Form2()
        {
            InitializeComponent();
            if (Screen.PrimaryScreen != null) //Show task bar
            {
                Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
                this.MaximumSize = new Size(workingArea.Width, workingArea.Height);
            }
        }

        private void button2_Click(object sender, EventArgs e) //Back
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e) //Reset
        {
            label1.Focus();
            File.WriteAllText("activity.txt", "");
            richTextBox5.Text = form1.now_date_time() + " | Activity reset.";
            form1.save_activity(richTextBox5);
        }
    }
}