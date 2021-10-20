﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication20.models
{
    public partial class EmployeeAttendanceContext : DbContext
    {
        public EmployeeAttendanceContext()
        {
        }

        public EmployeeAttendanceContext(DbContextOptions<EmployeeAttendanceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employe> Employes { get; set; }
        public virtual DbSet<EmployeAttendance> EmployeAttendances { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=EmployeeAttendance2;Trusted_Connection=True;");
            }
        }

       
    }
}
