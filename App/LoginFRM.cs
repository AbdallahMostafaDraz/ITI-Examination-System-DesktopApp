using Database.Data;
using Database.Entities;

namespace App
{
    public partial class LoginFRM : Form
    {
        AppDBContext _dbContext = new AppDBContext();
        public LoginFRM()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Close App?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Environment.Exit(0);
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (emailTXTBOX.Text.Trim() == "" || passwordTXTBOX.Text.Trim() == "" || (!stu_radiobtn.Checked && !inst_radiobtn.Checked))
            {
                MessageBox.Show("Please Enter All Data!", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (stu_radiobtn.Checked)
            {
                /*
                var student = _dbContext.Students.SingleOrDefault(e => e.StEmail == emailTXTBOX.Text && e.StPassword == passwordTXTBOX.Text);
                if (student is null)
                {
                    MessageBox.Show("INVALID USERNAME OR PASSWORD!", "Incorrect Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    StudentFRM studentFRM = new StudentFRM();
                    studentFRM.Show();
                }
                */
            }
            else if (inst_radiobtn.Checked)
            {
                var instructor = _dbContext.Instructors.SingleOrDefault(e => e.InstEmail == emailTXTBOX.Text && e.InstPassword == passwordTXTBOX.Text);
                if (instructor is null)
                {
                    MessageBox.Show("INVALID USERNAME OR PASSWORD!", "Incorrect Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    InstructorFRM instructorFRM = new InstructorFRM();
                    this.Hide();
                    instructorFRM.ShowDialog();
                    this.Close();
                }
            }
        }

        private void LoginFRM_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
