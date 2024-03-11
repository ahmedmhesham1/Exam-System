﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

public partial class ExamSystemContext : DbContext
{
    public ExamSystemContext()
    {
    }

    public ExamSystemContext(DbContextOptions<ExamSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Choice> Choices { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamQuestion> ExamQuestions { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentCourse> StudentCourses { get; set; }

    public virtual DbSet<StudentExamAn> StudentExamAns { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ExamSystem;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<Choice>(entity =>
        {
            entity.HasKey(e => e.ChoiceID).HasName("PK__Choices__76F5168618121EA5");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CrsID).HasName("PK__Courses__FAC236BD9BD98F06");

            entity.HasOne(d => d.Dept).WithMany(p => p.Courses).HasConstraintName("FK__Courses__DeptID__4BAC3F29");

            entity.HasOne(d => d.Ins).WithMany(p => p.Courses).HasConstraintName("FK__Courses__InsID__4AB81AF0");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptID).HasName("PK__Departme__0148818E2062603B");

            entity.HasOne(d => d.Mgr).WithMany(p => p.Departments).HasConstraintName("FK__Departmen__MgrID__46E78A0C");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.ExamID).HasName("PK__Exam__297521A7558527F5");

            entity.HasOne(d => d.Crs).WithMany(p => p.Exams).HasConstraintName("FK__Exam__CrsID__628FA481");
        });

        modelBuilder.Entity<ExamQuestion>(entity =>
        {
            entity.HasKey(e => new { e.ExamID, e.QID }).HasName("PK__ExamQues__85DE35DBC2D24874");

            entity.HasOne(d => d.Exam).WithMany(p => p.ExamQuestions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExamQuest__ExamI__656C112C");

            entity.HasOne(d => d.QIDNavigation).WithMany(p => p.ExamQuestions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExamQuestio__QID__66603565");

            entity.HasOne(d => d.St).WithMany(p => p.ExamQuestions).HasConstraintName("FK_ExamQuestions_Student");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InsID).HasName("PK__Instruct__9D104D8FFCFB00A2");

            entity.Property(e => e.Position).HasDefaultValue("Employee");

            entity.HasOne(d => d.Person).WithMany(p => p.Instructors)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Instructo__Perso__412EB0B6");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Person__3214EC2701E1AB17");

            entity.ToTable("Person", "HumanResources", tb =>
                {
                    tb.HasTrigger("PersonTrigger");
                    tb.HasTrigger("PersonTriggerDelete");
                });

            entity.Property(e => e.UserRole).HasDefaultValue("Student");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QID).HasName("PK__Question__CAB147CB975E24BC");

            entity.Property(e => e.Complexity).HasDefaultValue("easy");
            entity.Property(e => e.Type).HasDefaultValue("MCQ");
            entity.Property(e => e.Weight).HasComputedColumnSql("(case when [Complexity]='easy' then (1) when [Complexity]='medium' then (2) else (3) end)", true);

            entity.HasOne(d => d.Crs).WithMany(p => p.Questions).HasConstraintName("FK__Questions__CrsID__59063A47");

            entity.HasOne(d => d.ModelAnsNavigation).WithMany(p => p.Questions).HasConstraintName("FK__Questions__Model__59FA5E80");

            entity.HasMany(d => d.Choices).WithMany(p => p.QIDs)
                .UsingEntity<Dictionary<string, object>>(
                    "QuestionChoice",
                    r => r.HasOne<Choice>().WithMany()
                        .HasForeignKey("ChoiceID")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__QuestionC__Choic__5FB337D6"),
                    l => l.HasOne<Question>().WithMany()
                        .HasForeignKey("QID")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__QuestionCho__QID__5EBF139D"),
                    j =>
                    {
                        j.HasKey("QID", "ChoiceID").HasName("PK__Question__BDDE16A3AA05CD38");
                        j.ToTable("QuestionChoices");
                    });
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StID).HasName("PK__Student__C33CEFE2E64355F2");

            entity.HasOne(d => d.Person).WithMany(p => p.Students).HasConstraintName("FK__Student__PersonI__440B1D61");
        });

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity.HasKey(e => new { e.StID, e.CrsID }).HasName("PK__StudentC__0C90CC89D1C0EB34");

            entity.HasOne(d => d.Crs).WithMany(p => p.StudentCourses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentCo__CrsID__52593CB8");

            entity.HasOne(d => d.St).WithMany(p => p.StudentCourses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentCou__StID__5165187F");
        });

        modelBuilder.Entity<StudentExamAn>(entity =>
        {
            entity.HasKey(e => new { e.StID, e.ExamID, e.QID }).HasName("PK__StudentE__6B610CBF484D2754");

            entity.HasOne(d => d.Exam).WithMany(p => p.StudentExamen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentEx__ExamI__6A30C649");

            entity.HasOne(d => d.QIDNavigation).WithMany(p => p.StudentExamen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentExam__QID__6B24EA82");

            entity.HasOne(d => d.St).WithMany(p => p.StudentExamen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentExa__StID__693CA210");

            entity.HasOne(d => d.StudentChoice).WithMany(p => p.StudentExamen).HasConstraintName("FK__StudentEx__Stude__6C190EBB");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.TopicID).HasName("PK__Topics__022E0F7D0B67D028");

            entity.HasOne(d => d.Crs).WithMany(p => p.Topics).HasConstraintName("FK__Topics__CrsID__4E88ABD4");
        });

        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}