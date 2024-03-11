﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace test.Models;

[PrimaryKey("StId", "ExamId", "Qid")]
public partial class StudentExamAn
{
    [Key]
    [Column("StID")]
    public int StId { get; set; }

    [Key]
    [Column("ExamID")]
    public int ExamId { get; set; }

    [Key]
    [Column("QID")]
    public int Qid { get; set; }

    [Column("StudentChoiceID")]
    public int? StudentChoiceId { get; set; }

    public int? IsCorrect { get; set; }

    [Column("RN")]
    public int? Rn { get; set; }

    [ForeignKey("ExamId")]
    [InverseProperty("StudentExamen")]
    public virtual Exam Exam { get; set; }

    [ForeignKey("Qid")]
    [InverseProperty("StudentExamen")]
    public virtual Question QidNavigation { get; set; }

    [ForeignKey("StId")]
    [InverseProperty("StudentExamen")]
    public virtual Student St { get; set; }

    [ForeignKey("StudentChoiceId")]
    [InverseProperty("StudentExamen")]
    public virtual Choice StudentChoice { get; set; }
}