using System;
using System.Collections.Generic;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Data;

public partial class AppDBContext : DbContext
{
    public AppDBContext()
    {
    }

    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Choice> Choices { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseStudent> CourseStudents { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamType> ExamTypes { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<QuestionType> QuestionTypes { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentAnswer> StudentAnswers { get; set; }

    public virtual DbSet<StudentExam> StudentExams { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=ITIExaminationSystem;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.BrId).HasName("PK__Branch__E78A85B85524F0AA");

            entity.ToTable("Branch");

            entity.HasIndex(e => e.BrName, "UQ__Branch__0CFB29A8A6FEC8A8").IsUnique();

            entity.Property(e => e.BrId).HasColumnName("br_Id");
            entity.Property(e => e.BrLocation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("br_Location");
            entity.Property(e => e.BrName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("br_Name");
            entity.Property(e => e.BrPhone)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("br_phone");
            entity.Property(e => e.MngrId).HasColumnName("mngr_Id");

            entity.HasOne(d => d.Mngr).WithMany(p => p.Branches)
                .HasForeignKey(d => d.MngrId)
                .HasConstraintName("fk_branhc_mngr");

            entity.HasMany(d => d.Depts).WithMany(p => p.Brs)
                .UsingEntity<Dictionary<string, object>>(
                    "BranchDepartment",
                    r => r.HasOne<Department>().WithMany()
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__BrancheDe__dept___5070F446"),
                    l => l.HasOne<Branch>().WithMany()
                        .HasForeignKey("BrId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__BrancheDe__br_Id__4F7CD00D"),
                    j =>
                    {
                        j.HasKey("BrId", "DeptId").HasName("Branch_Dept_PK");
                        j.ToTable("BranchDepartments");
                        j.IndexerProperty<int>("BrId").HasColumnName("br_Id");
                        j.IndexerProperty<int>("DeptId").HasColumnName("dept_Id");
                    });
        });

        modelBuilder.Entity<Choice>(entity =>
        {
            entity.HasKey(e => e.ChoiceId).HasName("PK__Choices__3237F44265B1FADA");

            entity.Property(e => e.ChoiceId).HasColumnName("choice_Id");
            entity.Property(e => e.ChoiceText)
                .HasColumnType("text")
                .HasColumnName("choiceText");
            entity.Property(e => e.IsCorrect).HasColumnName("isCorrect");
            entity.Property(e => e.QId).HasColumnName("q_Id");

            entity.HasOne(d => d.QIdNavigation).WithMany(p => p.Choices)
                .HasForeignKey(d => d.QId)
                .HasConstraintName("FK__Choices__q_Id__3864608B");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CrsId).HasName("PK__Courses__ECAE4C9D2CF6CA87");

            entity.HasIndex(e => e.CrsName, "unique_crsName").IsUnique();

            entity.Property(e => e.CrsId).HasColumnName("crs_Id");
            entity.Property(e => e.CrsDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("crs_Description");
            entity.Property(e => e.CrsHours).HasColumnName("crs_Hours");
            entity.Property(e => e.CrsName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("crs_Name");

            entity.HasMany(d => d.Insts).WithMany(p => p.Crs)
                .UsingEntity<Dictionary<string, object>>(
                    "CourseInstructor",
                    r => r.HasOne<Instructor>().WithMany()
                        .HasForeignKey("InstId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CourseIns__Instr__1CBC4616"),
                    l => l.HasOne<Course>().WithMany()
                        .HasForeignKey("CrsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CourseIns__cours__1BC821DD"),
                    j =>
                    {
                        j.HasKey("CrsId", "InstId").HasName("C_In_pk");
                        j.ToTable("CourseInstructors");
                        j.IndexerProperty<int>("CrsId").HasColumnName("crs_id");
                        j.IndexerProperty<int>("InstId").HasColumnName("Inst_id");
                    });

            entity.HasMany(d => d.Trks).WithMany(p => p.Crs)
                .UsingEntity<Dictionary<string, object>>(
                    "CourseTrack",
                    r => r.HasOne<Track>().WithMany()
                        .HasForeignKey("TrkId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CourseTra__trk_i__0B91BA14"),
                    l => l.HasOne<Course>().WithMany()
                        .HasForeignKey("CrsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CourseTra__crs_i__0A9D95DB"),
                    j =>
                    {
                        j.HasKey("CrsId", "TrkId").HasName("C_Tr_pk");
                        j.ToTable("CourseTracks");
                        j.IndexerProperty<int>("CrsId").HasColumnName("crs_id");
                        j.IndexerProperty<int>("TrkId").HasColumnName("trk_id");
                    });
        });

        modelBuilder.Entity<CourseStudent>(entity =>
        {
            entity.HasKey(e => new { e.CrsId, e.StId }).HasName("pk_crs_stu");

            entity.Property(e => e.CrsId).HasColumnName("crs_Id");
            entity.Property(e => e.StId).HasColumnName("st_Id");
            entity.Property(e => e.Degree).HasColumnName("degree");

            entity.HasOne(d => d.Crs).WithMany(p => p.CourseStudents)
                .HasForeignKey(d => d.CrsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseStu__crs_I__2EDAF651");

            entity.HasOne(d => d.St).WithMany(p => p.CourseStudents)
                .HasForeignKey(d => d.StId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseStu__st_Id__2FCF1A8A");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK__Departme__DCA97B6C5A2F9D96");

            entity.ToTable("Department");

            entity.HasIndex(e => e.DeptName, "UQ__Departme__2EE0F2A4AFDC6926").IsUnique();

            entity.Property(e => e.DeptId).HasColumnName("dept_Id");
            entity.Property(e => e.DeptName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("dept_Name");
            entity.Property(e => e.MngrId).HasColumnName("mngr_Id");

            entity.HasOne(d => d.Mngr).WithMany(p => p.Departments)
                .HasForeignKey(d => d.MngrId)
                .HasConstraintName("fk_dept_mngr");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.ExamId).HasName("PK__Exam__9CB14671B55393A1");

            entity.ToTable("Exam");

            entity.Property(e => e.ExamId).HasColumnName("exam_Id");
            entity.Property(e => e.BrId).HasColumnName("br_Id");
            entity.Property(e => e.CrsId).HasColumnName("crs_Id");
            entity.Property(e => e.ExamDate).HasColumnName("exam_Date");
            entity.Property(e => e.ExamDuration).HasColumnName("exam_Duration");
            entity.Property(e => e.ExamType).HasColumnName("exam_Type");
            entity.Property(e => e.InstId).HasColumnName("inst_Id");
            entity.Property(e => e.TrkId).HasColumnName("trk_Id");

            entity.HasOne(d => d.Br).WithMany(p => p.Exams)
                .HasForeignKey(d => d.BrId)
                .HasConstraintName("FK__Exam__br_Id__40058253");

            entity.HasOne(d => d.Crs).WithMany(p => p.Exams)
                .HasForeignKey(d => d.CrsId)
                .HasConstraintName("FK__Exam__crs_Id__3F115E1A");

            entity.HasOne(d => d.ExamTypeNavigation).WithMany(p => p.Exams)
                .HasForeignKey(d => d.ExamType)
                .HasConstraintName("FK__Exam__exam_Type__3E1D39E1");

            entity.HasOne(d => d.Inst).WithMany(p => p.Exams)
                .HasForeignKey(d => d.InstId)
                .HasConstraintName("FK__Exam__inst_Id__3D2915A8");

            entity.HasOne(d => d.Trk).WithMany(p => p.Exams)
                .HasForeignKey(d => d.TrkId)
                .HasConstraintName("FK__Exam__trk_Id__40F9A68C");

            entity.HasMany(d => d.QIds).WithMany(p => p.Exams)
                .UsingEntity<Dictionary<string, object>>(
                    "ExamQuestion",
                    r => r.HasOne<Question>().WithMany()
                        .HasForeignKey("QId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ExamQuesti__q_id__47A6A41B"),
                    l => l.HasOne<Exam>().WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ExamQuest__exam___46B27FE2"),
                    j =>
                    {
                        j.HasKey("ExamId", "QId").HasName("pk_exam_questions");
                        j.ToTable("ExamQuestions");
                        j.IndexerProperty<int>("ExamId").HasColumnName("exam_Id");
                        j.IndexerProperty<int>("QId").HasColumnName("q_id");
                    });
        });

        modelBuilder.Entity<ExamType>(entity =>
        {
            entity.HasKey(e => e.TId).HasName("PK__ExamType__83BB1F92F02328AC");

            entity.ToTable("ExamType");

            entity.Property(e => e.TId).HasColumnName("T_Id");
            entity.Property(e => e.TypeText)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InstId).HasName("PK__Instruct__4ECD04F1FE11C500");

            entity.HasIndex(e => e.InstEmail, "UQ__Instruct__2CFB52C5D991EB11").IsUnique();

            entity.HasIndex(e => e.InstPhone, "UQ__Instruct__399761E646B943AF").IsUnique();

            entity.Property(e => e.InstId).HasColumnName("Inst_Id");
            entity.Property(e => e.DeptId).HasColumnName("dept_id");
            entity.Property(e => e.InstEmail)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Inst_Email");
            entity.Property(e => e.InstFname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Inst_fname");
            entity.Property(e => e.InstHiringDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Inst_hiringDate");
            entity.Property(e => e.InstLname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Inst_lname");
            entity.Property(e => e.InstPassword)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Inst_password");
            entity.Property(e => e.InstPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Inst_phone");

            entity.HasOne(d => d.Dept).WithMany(p => p.Instructors)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK__Instructo__dept___114A936A");

            entity.HasMany(d => d.Trks).WithMany(p => p.Insts)
                .UsingEntity<Dictionary<string, object>>(
                    "InstructorTrack",
                    r => r.HasOne<Track>().WithMany()
                        .HasForeignKey("TrkId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Instructo__Trk_I__731B1205"),
                    l => l.HasOne<Instructor>().WithMany()
                        .HasForeignKey("InstId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Instructo__Inst___7226EDCC"),
                    j =>
                    {
                        j.HasKey("InstId", "TrkId").HasName("pk_instTracks");
                        j.ToTable("InstructorTracks");
                        j.IndexerProperty<int>("InstId").HasColumnName("Inst_Id");
                        j.IndexerProperty<int>("TrkId").HasColumnName("Trk_Id");
                    });
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QId).HasName("PK__Question__3D5687680B104C33");

            entity.ToTable("Question");

            entity.Property(e => e.QId).HasColumnName("q_Id");
            entity.Property(e => e.CrsId).HasColumnName("crs_Id");
            entity.Property(e => e.QBody)
                .HasColumnType("varchar(max)")
                .HasColumnName("q_Body");
            entity.Property(e => e.QMarks).HasColumnName("q_marks");
            entity.Property(e => e.QType).HasColumnName("q_Type");

            entity.HasOne(d => d.Crs).WithMany(p => p.Questions)
                .HasForeignKey(d => d.CrsId)
                .HasConstraintName("FK__Question__crs_Id__3493CFA7");

            entity.HasOne(d => d.QTypeNavigation).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QType)
                .HasConstraintName("FK__Question__q_Type__3587F3E0");
        });

        modelBuilder.Entity<QuestionType>(entity =>
        {
            entity.HasKey(e => e.TId).HasName("PK__Question__83BB1F923CC15813");

            entity.ToTable("QuestionType");

            entity.Property(e => e.TId).HasColumnName("T_Id");
            entity.Property(e => e.QType)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("q_Type");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StId).HasName("PK__students__A85E81CF8718AEBA");

            entity.ToTable("students", tb => tb.HasTrigger("InsertCoursesToStudentAfterInsert"));

            entity.HasIndex(e => e.StEmail, "UQ__students__61D55CD16F18A282").IsUnique();

            entity.HasIndex(e => e.StPhone, "UQ__students__C42AE2912F872513").IsUnique();

            entity.Property(e => e.StId).HasColumnName("st_id");
            entity.Property(e => e.BranchId).HasColumnName("branch_id");
            entity.Property(e => e.DeptId).HasColumnName("dept_id");
            entity.Property(e => e.StEmail)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("st_Email");
            entity.Property(e => e.StFname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("st_fname");
            entity.Property(e => e.StJoinDate).HasColumnName("st_JoinDate");
            entity.Property(e => e.StLname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("st_lname");
            entity.Property(e => e.StPassword)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("st_password");
            entity.Property(e => e.StPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("st_phone");
            entity.Property(e => e.TrackId).HasColumnName("track_id");

            entity.HasOne(d => d.Branch).WithMany(p => p.Students)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_students_branches");

            entity.HasOne(d => d.Dept).WithMany(p => p.Students)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK__students__dept_i__04E4BC85");

            entity.HasOne(d => d.Track).WithMany(p => p.Students)
                .HasForeignKey(d => d.TrackId)
                .HasConstraintName("FK_students_tracks");
        });

        modelBuilder.Entity<StudentAnswer>(entity =>
        {
            entity.HasKey(e => new { e.StId, e.ExamId, e.QId, e.StAnswer }).HasName("pk_stuAnswer");

            entity.Property(e => e.StId).HasColumnName("st_Id");
            entity.Property(e => e.ExamId).HasColumnName("exam_Id");
            entity.Property(e => e.QId).HasColumnName("q_id");
            entity.Property(e => e.StAnswer).HasColumnName("st_answer");

            entity.HasOne(d => d.Exam).WithMany(p => p.StudentAnswers)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentAn__exam___7EF6D905");

            entity.HasOne(d => d.QIdNavigation).WithMany(p => p.StudentAnswers)
                .HasForeignKey(d => d.QId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentAns__q_id__7FEAFD3E");

            entity.HasOne(d => d.StAnswerNavigation).WithMany(p => p.StudentAnswers)
                .HasForeignKey(d => d.StAnswer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentAn__st_an__00DF2177");

            entity.HasOne(d => d.St).WithMany(p => p.StudentAnswers)
                .HasForeignKey(d => d.StId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentAn__st_Id__7E02B4CC");
        });

        modelBuilder.Entity<StudentExam>(entity =>
        {
            entity.HasKey(e => new { e.StId, e.ExamId }).HasName("pk_stu_exam");

            entity.Property(e => e.StId).HasColumnName("st_Id");
            entity.Property(e => e.ExamId).HasColumnName("exam_id");
            entity.Property(e => e.Degree)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("degree");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Exam).WithMany(p => p.StudentExams)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentEx__exam___540C7B00");

            entity.HasOne(d => d.St).WithMany(p => p.StudentExams)
                .HasForeignKey(d => d.StId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentEx__st_Id__531856C7");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PK__topics__D5DAA3E9ABE5E037");

            entity.ToTable("Topic");

            entity.Property(e => e.TopicId).HasColumnName("Topic_Id");
            entity.Property(e => e.CrsId).HasColumnName("Crs_id");
            entity.Property(e => e.TopicName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Topic_Name");

            entity.HasOne(d => d.Crs).WithMany(p => p.Topics)
                .HasForeignKey(d => d.CrsId)
                .HasConstraintName("FK__topics__crs_id__370627FE");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.TrkId).HasName("PK__Track__FF48DFD1DDB6CAE5");

            entity.ToTable("Track");

            entity.Property(e => e.TrkId).HasColumnName("trk_Id");
            entity.Property(e => e.DeptId).HasColumnName("Dept_Id");
            entity.Property(e => e.TrkName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("trk_Name");

            entity.HasOne(d => d.Dept).WithMany(p => p.Tracks)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK__Track__Dept_Id__534D60F1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
