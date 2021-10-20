using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApplication20.models
{
    public partial class EmployeAttendance
    {     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public TimeSpan Attendance { get; set; }
        public TimeSpan Leaving { get; set; }
        [ForeignKey("Employe")]
        public int EmpId { get; set; }
        public virtual Employe Employe { get; set; }
    }
}
