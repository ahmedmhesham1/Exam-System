﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entities;

[Table("Person", Schema = "HumanResources")]
[Index("Email", Name = "CEmail", IsUnique = true)]
[Index("Phone", Name = "CPhone", IsUnique = true)]
[Index("Username", Name = "CUserName", IsUnique = true)]
public partial class Person
{
    [Key]
    public int ID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Address { get; set; }

    [Required]
    [StringLength(13)]
    [Unicode(false)]
    public string Phone { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Fname { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Lname { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Password { get; set; }

    [Required]
    [StringLength(10)]
    [Unicode(false)]
    public string UserRole { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Username { get; set; }

    public int DeptID { get; set; }

    [InverseProperty("Person")]
    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    [InverseProperty("Person")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}