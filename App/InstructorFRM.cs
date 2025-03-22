using Database.Data;
using Database.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class InstructorFRM : Form
    {

        AppDBContext _dbContext = new AppDBContext();
        public InstructorFRM()
        {
            InitializeComponent();
        }

        private void FillComboWithInstructors(ComboBox comboBox)
        {

            var allInstructors = _dbContext.Instructors
                .Select(e => new { Id = e.InstId, FullName = $"{e.InstFname} {e.InstLname}" })
                .ToList();

            comboBox.DataSource = allInstructors;
            comboBox.DisplayMember = "FullName";
            comboBox.ValueMember = "Id";
            comboBox.SelectedItem = null;

            comboBox.Validating += (s, e) =>
            {
                var validNames = comboBox.Items.Cast<dynamic>().Select(item => item.FullName).ToList();

                if (!validNames.Contains(comboBox.Text))
                {
                    comboBox.Text = "";
                }
            };
        }
        private bool isLoading = true;
        private void FillComboWithDepartment(ComboBox comboBox)
        {

            isLoading = true;
            var allDepartments = _dbContext.Departments
                .Select(e => new { Id = e.DeptId, Name = e.DeptName })
                .ToList();

            comboBox.DataSource = allDepartments;
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Id";
            comboBox.SelectedItem = null;

            comboBox.Validating += (s, e) =>
            {
                var validNames = comboBox.Items.Cast<dynamic>().Select(item => item.Name).ToList();

                if (!validNames.Contains(comboBox.Text))
                {
                    comboBox.Text = "";
                    comboBox.SelectedItem = null;
                }
            };
            isLoading = false;
        }

        private void FillComboWithBranches(ComboBox comboBox)
        {
            var allBranches = _dbContext.Branches
          .Select(e => new { Id = e.BrId, Name = e.BrName })
          .ToList();

            comboBox.DataSource = allBranches;
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Id";
            comboBox.SelectedItem = null;

            comboBox.Validating += (s, e) =>
            {
                var validNames = comboBox.Items.Cast<dynamic>().Select(item => item.Name).ToList();

                if (!validNames.Contains(comboBox.Text))
                {
                    comboBox.Text = "";
                }
            };
        }

        private void FillComboWithTracks(ComboBox comboBox, int deptId)
        {
            var allTracks = _dbContext.Tracks
                .Where(e => e.DeptId == deptId)
          .Select(e => new { Id = e.TrkId, Name = e.TrkName })
          .ToList();

            comboBox.DataSource = allTracks;
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Id";
            comboBox.SelectedItem = null;

            comboBox.Validating += (s, e) =>
            {
                var validNames = comboBox.Items.Cast<dynamic>().Select(item => item.Name).ToList();

                if (!validNames.Contains(comboBox.Text))
                {
                    comboBox.Text = "";
                }
            };
        }

        private void FillComboWithCourses(ComboBox comboBox)
        {
            var allCourse = _dbContext.Courses
          .Select(e => new { Id = e.CrsId, Name = e.CrsName })
          .ToList();

            comboBox.DataSource = allCourse;
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Id";
            comboBox.SelectedItem = null;

            comboBox.Validating += (s, e) =>
            {
                var validNames = comboBox.Items.Cast<dynamic>().Select(item => item.Name).ToList();

                if (!validNames.Contains(comboBox.Text))
                {
                    comboBox.Text = "";
                }
            };

        }


        private void FillComboWithQuestionTypes(ComboBox comboBox)
        {
            isLoading = true;
            var allQuestionTypes = _dbContext.QuestionTypes
            .Select(e => new { Id = e.TId, Name = e.QType })
            .ToList();

            comboBox.DataSource = allQuestionTypes;
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Id";
            comboBox.SelectedItem = null;

            comboBox.Validating += (s, e) =>
            {
                var validNames = comboBox.Items.Cast<dynamic>().Select(item => item.Name).ToList();

                if (!validNames.Contains(comboBox.Text))
                {
                    comboBox.Text = "";
                }
            };
            isLoading = false;
        }

        private void FillDataGridWithInstructors(DataGridView dataGridView, int? trackId)
        {
            var allInsts = _dbContext.Instructors.
                Select(e => new { Id = e.InstId, FullName = $"{e.InstFname} {e.InstLname}" }).ToList();

            if (trackId is not null)
            {
                allInsts = _dbContext.Instructors.
                Where(e => e.Trks.Any(t => t.TrkId == trackId)).
                    Select(e => new { Id = e.InstId, FullName = $"{e.InstFname} {e.InstLname}" }).ToList();
            }

            dataGridView.Columns.Clear();

            dataGridView.DataSource = allInsts;

            dataGridView.Columns["FullName"].HeaderText = "Instructor Name";
            dataGridView.Columns["FullName"].Width = 200;
            dataGridView.Columns["Id"].Visible = false;

            // Create a new checkbox column
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "✔"; // Column header name
            chk.Name = "AddChk"; // Column name
            chk.Width = 60; // Adjust column width
            dataGridView.Columns.Add(chk);
        }
        private void FillDataGridWithTracks(DataGridView dataGridView, int? deptId)
        {
            var allTracks = _dbContext.Tracks.
                 Select(e => new { Id = e.TrkId, Name = e.TrkName })
                .ToList();

            if (deptId is not null)
            {
                allTracks = _dbContext.Tracks.
                   Where(e => e.DeptId == deptId).
                   Select(e => new { Id = e.TrkId, Name = e.TrkName })
                  .ToList();
            }

            dataGridView.Columns.Clear();

            dataGridView.DataSource = allTracks;

            dataGridView.Columns["Name"].HeaderText = "Track Name";
            dataGridView.Columns["Name"].Width = 200;
            dataGridView.Columns["Id"].Visible = false;

            // Create a new checkbox column
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "✔";
            chk.Name = "AddChk";
            chk.Width = 60;
            dataGridView.Columns.Add(chk);
        }


        // === Fill Controls
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            FillComboWithInstructors(br_Manager_Combo);

            FillComboWithInstructors(dept_mng_Combo);

            FillComboWithDepartment(trk_Dept_Combo);

            FillComboWithDepartment(inst_Dept_Combo);

            FillComboWithBranches(st_Branch_Combo);
            FillComboWithDepartment(st_Dept_Combo);


            FillDataGridWithTracks(crs_Tracks_DG, null);

            FillComboWithCourses(topic_CrsName_Combo);

            FillComboWithCourses(q_CrsName_Combo);
            FillComboWithQuestionTypes(q_Types_Combo);

        }
        // ==================


        private void InstructorFRM_Load(object sender, EventArgs e)
        {
            FillComboWithInstructors(br_Manager_Combo);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }





        // ===  Logout Button
        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do You Want To Logout ?", "Logging Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoginFRM loginFRM = new LoginFRM();
                Hide();
                loginFRM.ShowDialog();
                Close();
            }
        }
        // ==================


        // ====  Branch
        private void button2_Click(object sender, EventArgs e)
        {
            if (br_Name_TXTBOX.Text.Trim() == "" || br_Location_TXTBOX.Text.Trim() == "" || br_Phone_TXTBOX.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter All Data!", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var branch = _dbContext.Branches.SingleOrDefault(e => e.BrName == br_Name_TXTBOX.Text);
            if (branch != null)
            {
                MessageBox.Show("This Branch Name Is Already Exist!", "Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            int? managerId = null;     
            if (br_Manager_Combo.Text.Trim() != "")
            {
                if (_dbContext.Branches.Select(e => e.MngrId).Contains((int)br_Manager_Combo.SelectedValue!))
                {
                    MessageBox.Show("This Manager Is Already Manage Another Branch!", "Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    managerId = (int)br_Manager_Combo.SelectedValue!;
                }
            }

            branch = new Branch()
            {
                BrName = br_Name_TXTBOX.Text,
                BrLocation = br_Location_TXTBOX.Text,
                BrPhone = br_Phone_TXTBOX.Text,
                MngrId = managerId
            };
            _dbContext.Branches.Add(branch);
            _dbContext.SaveChanges();
            MessageBox.Show("Branch Added Successfully", "Saved Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            br_Name_TXTBOX.Text = "";
            br_Location_TXTBOX.Text = "";
            br_Phone_TXTBOX.Text = "";
            br_Manager_Combo.SelectedItem = null;

        }
        // =============



        // === Department
        private void dept_Save_BTN_Click(object sender, EventArgs e)
        {
            if (dept_Name_TXTBOX.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter All Data!", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var department = _dbContext.Departments.SingleOrDefault(e => e.DeptName == br_Name_TXTBOX.Text);
            if (department != null)
            {
                MessageBox.Show("This Department Name Is Already Exist!", "Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            int? managerId = null;
            if (dept_mng_Combo.Text.Trim() != "")
            {
                managerId = (int)dept_mng_Combo.SelectedValue!;
                if (_dbContext.Departments.Select(e => e.MngrId).Contains((int)dept_mng_Combo.SelectedValue!))
                {
                    MessageBox.Show("This Manager Is Already Manage Another Department!", "Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            
                department = new Department()
                {
                    DeptName = dept_Name_TXTBOX.Text,
                    MngrId = managerId!
                };
                _dbContext.Departments.Add(department);
                _dbContext.SaveChanges();
                MessageBox.Show("Department Added Successfully", "Saved Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dept_Name_TXTBOX.Text = "";
                dept_mng_Combo.SelectedItem = null;
            }
        
        // =====================


        // === Track
        private void button5_Click(object sender, EventArgs e)
        {
            if (trk_Name_TXTBOX.Text.Trim() == "" || trk_Name_TXTBOX.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter All Data!", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var track = _dbContext.Tracks.SingleOrDefault(e => e.TrkName == trk_Name_TXTBOX.Text);
            if (track != null)
            {
                MessageBox.Show("This Track Name Is Already Exist!", "Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                track = new Track()
                {
                    TrkName = trk_Name_TXTBOX.Text,
                    DeptId = (int)trk_Dept_Combo.SelectedValue!
                };
                _dbContext.Tracks.Add(track);
                _dbContext.SaveChanges();
                MessageBox.Show("Track Added Successfully", "Saved Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                trk_Name_TXTBOX.Text = "";
                trk_Dept_Combo.SelectedItem = null;
            }
        }
        // ==========


        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        // === Instructor
        private void inst_Save_BTN_Click(object sender, EventArgs e)
        {
            if (inst_FName_TXTBOX.Text.Trim() == "" || inst_LName_TXTBOX.Text.Trim() == "" ||
                inst_Email_TXTBOX.Text.Trim() == "" || inst_Password_TXTBOX.Text.Trim() == "" ||
                inst_ConfirmPassword_TXTBOX.Text.Trim() == "" || inst_Phone_TXTBOX.Text.Trim() == "" ||
                inst_Dept_Combo.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter All Data!", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (inst_Password_TXTBOX.Text != inst_ConfirmPassword_TXTBOX.Text)
            {
                MessageBox.Show("Passwords Are Not Matched!", "Incorrec Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var phone = _dbContext.Instructors.Where(e => e.InstPhone == inst_Phone_TXTBOX.Text)
                .Select(e => e.InstPhone).FirstOrDefault();

            if (phone != null)
            {
                MessageBox.Show("This Phone Number Is Already Exist With Another Instructor!", "Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var email = _dbContext.Instructors.Where(e => e.InstEmail == inst_Email_TXTBOX.Text)
                .Select(e => e.InstEmail).FirstOrDefault();

            if (email != null)
            {
                MessageBox.Show("This Email Is Already Exist With Another Instructor!", "Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // get all tracks IDs that user selected
            var tracksToAddInCourse = new List<int>();
            for (int i = 0; i < inst_Tracks_DG.Rows.Count; i++)
            {
                if (Convert.ToBoolean(inst_Tracks_DG.Rows[i].Cells["AddChk"].Value) == true)
                {
                    tracksToAddInCourse.Add(Convert.ToInt32(inst_Tracks_DG.Rows[i].Cells["Id"].Value));
                }
            }
            // check if user not select any track
            if (tracksToAddInCourse.Count == 0)
            {
                MessageBox.Show("Please Choose One Track At Least!", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var instructor = new Instructor()
            {
                InstFname = inst_FName_TXTBOX.Text,
                InstLname = inst_LName_TXTBOX.Text,
                InstEmail = inst_Email_TXTBOX.Text,
                InstPassword = inst_Password_TXTBOX.Text,
                InstPhone = inst_Phone_TXTBOX.Text,
                InstHiringDate = DateOnly.FromDateTime(inst_HireDate_DTPicker.Value),
                DeptId = (int)inst_Dept_Combo.SelectedValue!
            };


            // add in CourseTracks Table
            foreach (int i in tracksToAddInCourse)
            {
                var track = _dbContext.Tracks.FirstOrDefault(e => e.TrkId == i);
                instructor.Trks.Add(track!);
            }
            _dbContext.Instructors.Add(instructor);
            _dbContext.SaveChanges();
            MessageBox.Show("Instructor Added Successfully", "Saved Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            inst_FName_TXTBOX.Text = "";
            inst_LName_TXTBOX.Text = "";
            inst_Email_TXTBOX.Text = "";
            inst_Password_TXTBOX.Text = "";
            inst_ConfirmPassword_TXTBOX.Text = "";
            inst_Phone_TXTBOX.Text = "";
            inst_Tracks_DG.Columns.Clear();
            inst_Dept_Combo.SelectedItem = null;

        }
        // ==============


        // === Student
        private void button9_Click(object sender, EventArgs e)
        {
            if (st_FName_TXTBOX.Text.Trim() == "" || st_LName_TXTBOX.Text.Trim() == "" ||
                st_Email_TXTBOX.Text.Trim() == "" || st_Password_TXTBOX.Text.Trim() == "" ||
                st_ConfirmPassword_TXTBOX.Text.Trim() == "" || st_Phone_TXTBOX.Text.Trim() == "" ||
                st_Branch_Combo.Text.Trim() == "" || st_Track_Combo.Text.Trim() == "" ||
                st_Dept_Combo.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter All Data!", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (st_Password_TXTBOX.Text != st_ConfirmPassword_TXTBOX.Text)
            {
                MessageBox.Show("Passwords Are Not Matched!", "Incorrect Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var phone = _dbContext.Students.Where(e => e.StPhone == st_Phone_TXTBOX.Text)
                .Select(e => e.StPhone).FirstOrDefault();

            if (phone != null)
            {
                MessageBox.Show("This Phone Number Is Already Exist With Another Student!", "Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var email = _dbContext.Students.Where(e => e.StEmail == st_Email_TXTBOX.Text)
                .Select(e => e.StEmail).FirstOrDefault();

            if (email != null)
            {
                MessageBox.Show("This Email Is Already Exist With Another Student!", "Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var student = new Student()
            {
                StFname = st_FName_TXTBOX.Text,
                StLname = st_LName_TXTBOX.Text,
                StEmail = st_Email_TXTBOX.Text,
                StPassword = st_Password_TXTBOX.Text,
                StPhone = st_Phone_TXTBOX.Text,
                StJoinDate = DateOnly.FromDateTime(st_JoinDate_DTPicker.Value),
                BranchId = (int)st_Branch_Combo.SelectedValue!,
                TrackId = (int)st_Track_Combo.SelectedValue!,
                DeptId = (int)st_Dept_Combo.SelectedValue!
            };

            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
            MessageBox.Show("Student Added Successfully", "Saved Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            st_FName_TXTBOX.Text = "";
            st_LName_TXTBOX.Text = "";
            st_Email_TXTBOX.Text = "";
            st_Password_TXTBOX.Text = "";
            st_Phone_TXTBOX.Text = "";
            st_Dept_Combo.SelectedItem = null;
            st_Branch_Combo.SelectedItem = null;
            st_Track_Combo.SelectedItem = null;
        }
        // ===========

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }


        private void st_Dept_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (isLoading) return;

            if (st_Dept_Combo.SelectedItem == null)
            {
                st_Track_Combo.DataSource = null;
                return;
            }

            int selectedDepartmentId;
            if (!int.TryParse(st_Dept_Combo.SelectedValue?.ToString(), out selectedDepartmentId))
            {
                MessageBox.Show("Invalid Department Selected", "Incorrect Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FillComboWithTracks(st_Track_Combo, selectedDepartmentId);
        }

        private void st_Dept_Combo_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        // === Course
        private void button13_Click(object sender, EventArgs e)
        {
            if (crs_Name_TXTBOX.Text.Trim() == "" || crs_Hours_TXTBOX.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter All Data!", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // get all tracks IDs that user selected
            var tracksToAddInCourse = new List<int>();
            for (int i = 0; i < crs_Tracks_DG.Rows.Count; i++)
            {
                if (Convert.ToBoolean(crs_Tracks_DG.Rows[i].Cells["AddChk"].Value) == true)
                {
                    tracksToAddInCourse.Add(Convert.ToInt32(crs_Tracks_DG.Rows[i].Cells["Id"].Value));
                }
            }

            // check if user not select any track
            if (tracksToAddInCourse.Count == 0)
            {
                MessageBox.Show("Please Choose One Track At Least!", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // get all instructors IDs that user selected
            var instructorsToAddInCourse = new List<int>();
            for (int i = 0; i < crs_instructors_DG.Rows.Count; i++)
            {
                if (Convert.ToBoolean(crs_instructors_DG.Rows[i].Cells["AddChk"].Value) == true)
                {
                    instructorsToAddInCourse.Add(Convert.ToInt32(crs_instructors_DG.Rows[i].Cells["Id"].Value));
                }
            }
            // check if user not select any instructor
            if (instructorsToAddInCourse.Count == 0)
            {
                MessageBox.Show("Please Choose One Instructor At Least!", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // check if course name is already exisit
            var courseName = _dbContext.Courses.Where(e => e.CrsName == crs_Name_TXTBOX.Text)
                .Select(e => e.CrsName).FirstOrDefault();

            if (courseName != null)
            {
                MessageBox.Show("This Course Name Is Already Exist!", "Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // add course in courses table
            var course = new Course()
            {
                CrsName = crs_Name_TXTBOX.Text,
                CrsHours = int.Parse(crs_Hours_TXTBOX.Text),
                CrsDescription = csr_Desc_TXTBOX.Text
            };


            // add in CourseTracks Table
            foreach (int i in tracksToAddInCourse)
            {
                var track = _dbContext.Tracks.FirstOrDefault(e => e.TrkId == i);
                course.Trks.Add(track);
            }

            // add in CourseInstructors Table
            foreach (int i in instructorsToAddInCourse)
            {
                var instructor = _dbContext.Instructors.FirstOrDefault(e => e.InstId == i);
                course.Insts.Add(instructor!);
            }

            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();


            MessageBox.Show("Course Added Successfully", "Saved Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            crs_Name_TXTBOX.Text = "";
            crs_Hours_TXTBOX.Text = "";
            csr_Desc_TXTBOX.Text = "";

            for (int i = 0; i < crs_instructors_DG.Rows.Count; i++)
            {
                if (Convert.ToBoolean(crs_instructors_DG.Rows[i].Cells["AddChk"].Value) == true)
                    crs_instructors_DG.Rows[i].Cells["AddChk"].Value = false;
            }
        }
        // ==========
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // === Topic
        private void topic_Save_BTN_Click(object sender, EventArgs e)
        {
            if (topic_CrsName_Combo.Text.Trim() == "" || topic_Name_TXTBOX.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter All Data!", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var topic = _dbContext.Topics.SingleOrDefault(e => e.TopicName == topic_Name_TXTBOX.Text && e.CrsId == (int)topic_CrsName_Combo.SelectedValue);
            if (topic != null)
            {
                MessageBox.Show("This Topic Name Is Already Exist In This Course!", "Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                topic = new Topic()
                {
                    TopicName = topic_Name_TXTBOX.Text,
                    CrsId = (int)topic_CrsName_Combo.SelectedValue!
                };
                _dbContext.Topics.Add(topic);
                _dbContext.SaveChanges();
                MessageBox.Show("Topic Added Successfully", "Saved Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                topic_Name_TXTBOX.Text = "";
            }
        }
        // =========
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void inst_Email_TXTBOX_TextChanged(object sender, EventArgs e)
        {

        }

        private void inst_Dept_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (inst_Dept_Combo.SelectedItem != null)
                FillDataGridWithTracks(inst_Tracks_DG, (int)inst_Dept_Combo.SelectedValue!);
        }

        private HashSet<int> selectedTracks = new HashSet<int>();

        private void crs_Tracks_DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (crs_Tracks_DG.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)crs_Tracks_DG.Rows[e.RowIndex].Cells[e.ColumnIndex];

                int trackId = Convert.ToInt32(crs_Tracks_DG.Rows[e.RowIndex].Cells["Id"].Value);

                if (chk.Value == null || !(bool)chk.Value)
                {
                    chk.Value = true;  // تحديد الـ Checkbox
                    selectedTracks.Add(trackId);  // إضافة التراك إلى القائمة
                    SetupInstructorsGrid();
                    AddInstructorsByTrack(trackId);
                }
                else
                {
                    chk.Value = false; // إلغاء التحديد
                    selectedTracks.Remove(trackId); // إزالة التراك من القائمة
                    RemoveInstructorsByTrack(trackId);
                }
            }
        }

        private void AddInstructorsByTrack(int trackId)
        {
            var instructors = _dbContext.Instructors.
                Where(e => e.Trks.Any(t => t.TrkId == trackId)).
                    Select(e => new { Id = e.InstId, FullName = $"{e.InstFname} {e.InstLname}" }).ToList();

            if (instructors.Any())
            {
                DataTable currentData = crs_instructors_DG.DataSource as DataTable ?? new DataTable();

                if (currentData.Columns.Count == 0)
                {
                    currentData.Columns.Add("Id", typeof(int));
                    currentData.Columns.Add("FullName", typeof(string));
                }

                foreach (var instructor in instructors)
                {
                    if (!currentData.AsEnumerable().Any(row => row.Field<int>("Id") == instructor.Id))
                    {
                        currentData.Rows.Add(instructor.Id, instructor.FullName);
                    }
                }

                crs_instructors_DG.Columns[0].Visible = false;
                crs_instructors_DG.DataSource = currentData;
            }
        }
        private void RemoveInstructorsByTrack(int trackId)
        {
            DataTable currentData = crs_instructors_DG.DataSource as DataTable;
            if (currentData != null)
            {
                var instructorsToRemove = _dbContext.Instructors
                                                  .Where(i => i.Trks.Any(t => t.TrkId == trackId))
                                                  .Select(i => i.InstId)
                                                  .Distinct()
                                                  .ToList();

                foreach (var instructorId in instructorsToRemove)
                {
                    bool isStillNeeded = _dbContext.Instructors
                                                 .Any(i => selectedTracks.Any(tid => i.Trks.Any(t => t.TrkId == tid)) &&
                                                           i.InstId == instructorId);

                    if (!isStillNeeded)
                    {
                        var rowToRemove = currentData.AsEnumerable()
                                                     .FirstOrDefault(row => row.Field<int>("Id") == instructorId);

                        if (rowToRemove != null)
                            currentData.Rows.Remove(rowToRemove);
                    }
                }

                crs_instructors_DG.DataSource = currentData;
            }

        }

        private void SetupInstructorsGrid()
        {
            crs_instructors_DG.AutoGenerateColumns = false;
            crs_instructors_DG.AllowUserToAddRows = false;
            crs_instructors_DG.Columns.Clear();

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            };
            crs_instructors_DG.Columns.Add(idColumn);

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                DataPropertyName = "FullName",
                HeaderText = "Instructor Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            crs_instructors_DG.Columns.Add(nameColumn);

            DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn
            {
                Name = "AddChk",
                HeaderText = "✔",
                Width = 50
            };
            crs_instructors_DG.Columns.Add(chkColumn);


        }

        // === Questions
        private void q_Types_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            if (q_Types_Combo.SelectedIndex == 0)
            {
                q_CorrectAnswer_GROUP.Visible = true;
                q_Choices_GROUP.Visible = false;

            }
            else if (q_Types_Combo.SelectedIndex == 1)
            {
                q_Choices_GROUP.Visible = true;
                q_CorrectAnswer_GROUP.Visible = false;
            }

        }

        
        private void q_Save_BTN_Click(object sender, EventArgs e)
        {
            if (q_CrsName_Combo.Text.Trim() == "" || q_Types_Combo.Text.Trim() == "" ||
             q_Marks_TXTBOX.Text.Trim() == "" || q_Body_TXTBOX.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter All Data!", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (q_CorrectAnswer_GROUP.Visible)
            {
                if (!true_RADIO.Checked && !false_RADIO.Checked)
                {
                    MessageBox.Show("Please Choose The Correct Answer!", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (q_Choices_GROUP.Visible)
            {
                if (q_Choice1_TXTBOX.Text.Trim() == "" || q_Choice2_TXTBOX.Text.Trim() == ""||
                    q_Choice3_TXTBOX.Text.Trim() == "" || q_Choice4_TXTBOX.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter All Choices!", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!choice1_RADIO.Checked && !choice2_RADIO.Checked && !choice3_RADIO.Checked && !choice4_RADIO.Checked)
                {
                    MessageBox.Show("Please Choose The Correct Answer!", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            var questionBody = _dbContext.Questions.Where(e => e.QBody == q_Body_TXTBOX.Text && e.CrsId == (int) q_CrsName_Combo.SelectedValue!)
                .Select(e => e.QBody).FirstOrDefault();

            if (questionBody != null)
            {
                MessageBox.Show("This Question Is Already Exist In This Course!", "Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // add question
            var question = new Question()
            {
                CrsId = (int) q_CrsName_Combo.SelectedValue!,
                QType = (int) q_Types_Combo.SelectedValue!,
                QBody = q_Body_TXTBOX.Text,
                QMarks = byte.Parse(q_Marks_TXTBOX.Text)
            };

            // add choices
            List<Choice> choices = new List<Choice>();  


            if (q_Types_Combo.SelectedIndex == 0)
            {
                choices = new List<Choice>(){
                    new Choice() { ChoiceText = "True", IsCorrect = true_RADIO.Checked },
                    new Choice() { ChoiceText = "False", IsCorrect = false_RADIO.Checked },
                };
            }
            else if (q_Types_Combo.SelectedIndex == 1)
            {
                choices = new List<Choice>(){
                    new Choice() { ChoiceText = q_Choice1_TXTBOX.Text, IsCorrect = choice1_RADIO.Checked },
                    new Choice() { ChoiceText = q_Choice2_TXTBOX.Text, IsCorrect = choice2_RADIO.Checked },
                    new Choice() { ChoiceText = q_Choice3_TXTBOX.Text, IsCorrect = choice3_RADIO.Checked },
                    new Choice() { ChoiceText = q_Choice4_TXTBOX.Text, IsCorrect = choice4_RADIO.Checked },
                };
            }
            question.Choices = choices;

            _dbContext.Questions.Add(question);

            _dbContext.SaveChanges();
            MessageBox.Show("Question Added Successfully", "Saved Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            q_Marks_TXTBOX.Text = "";
            q_Body_TXTBOX.Text = "";
            q_Choice1_TXTBOX.Text = "";
            q_Choice2_TXTBOX.Text = "";
            q_Choice3_TXTBOX.Text = "";
            q_Choice4_TXTBOX.Text = "";
            choice1_RADIO.Checked = false;
            choice2_RADIO.Checked = false;
            choice3_RADIO.Checked = false;
            choice4_RADIO.Checked = false;
            true_RADIO.Checked = false;
            false_RADIO.Checked = false;
        }
        // ==================
        private void inst_Tracks_DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}

 