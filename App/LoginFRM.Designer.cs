namespace App
{
    partial class LoginFRM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFRM));
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            inst_radiobtn = new RadioButton();
            stu_radiobtn = new RadioButton();
            button2 = new Button();
            button1 = new Button();
            passwordTXTBOX = new TextBox();
            emailTXTBOX = new TextBox();
            label3 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(9, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(216, 101);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(3, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1213, 125);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Wide Latin", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(254, 41);
            label1.Name = "label1";
            label1.Size = new Size(764, 42);
            label1.TabIndex = 1;
            label1.Text = "ITI Examination System";
            label1.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(inst_radiobtn);
            panel2.Controls.Add(stu_radiobtn);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(passwordTXTBOX);
            panel2.Controls.Add(emailTXTBOX);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panel2.Location = new Point(339, 283);
            panel2.Name = "panel2";
            panel2.Size = new Size(549, 342);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // inst_radiobtn
            // 
            inst_radiobtn.AutoSize = true;
            inst_radiobtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            inst_radiobtn.Location = new Point(334, 194);
            inst_radiobtn.Name = "inst_radiobtn";
            inst_radiobtn.Size = new Size(165, 29);
            inst_radiobtn.TabIndex = 7;
            inst_radiobtn.TabStop = true;
            inst_radiobtn.Text = "as an instructor";
            inst_radiobtn.UseVisualStyleBackColor = true;
            // 
            // stu_radiobtn
            // 
            stu_radiobtn.AutoSize = true;
            stu_radiobtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stu_radiobtn.Location = new Point(180, 194);
            stu_radiobtn.Name = "stu_radiobtn";
            stu_radiobtn.Size = new Size(136, 29);
            stu_radiobtn.TabIndex = 6;
            stu_radiobtn.TabStop = true;
            stu_radiobtn.Text = "as a student";
            stu_radiobtn.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(336, 243);
            button2.Name = "button2";
            button2.Size = new Size(163, 48);
            button2.TabIndex = 5;
            button2.Text = "Close";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(173, 243);
            button1.Name = "button1";
            button1.Size = new Size(157, 48);
            button1.TabIndex = 4;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // passwordTXTBOX
            // 
            passwordTXTBOX.ForeColor = SystemColors.HotTrack;
            passwordTXTBOX.Location = new Point(171, 137);
            passwordTXTBOX.Name = "passwordTXTBOX";
            passwordTXTBOX.PasswordChar = '.';
            passwordTXTBOX.Size = new Size(326, 38);
            passwordTXTBOX.TabIndex = 3;
            passwordTXTBOX.TextAlign = HorizontalAlignment.Center;
            // 
            // emailTXTBOX
            // 
            emailTXTBOX.ForeColor = SystemColors.HotTrack;
            emailTXTBOX.Location = new Point(171, 75);
            emailTXTBOX.Name = "emailTXTBOX";
            emailTXTBOX.Size = new Size(326, 38);
            emailTXTBOX.TabIndex = 2;
            emailTXTBOX.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 135);
            label3.Name = "label3";
            label3.Size = new Size(126, 31);
            label3.TabIndex = 1;
            label3.Text = "Password: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 77);
            label2.Name = "label2";
            label2.Size = new Size(85, 31);
            label2.TabIndex = 0;
            label2.Text = "Email: ";
            // 
            // LoginFRM
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1222, 729);
            ControlBox = false;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "LoginFRM";
            StartPosition = FormStartPosition.CenterScreen;
            Load += LoginFRM_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private TextBox passwordTXTBOX;
        private TextBox emailTXTBOX;
        private Label label3;
        private Label label2;
        private Button button2;
        private Button button1;
        private RadioButton stu_radiobtn;
        private RadioButton inst_radiobtn;
    }
}
