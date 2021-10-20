using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApplication20.models
{
    public partial class Employe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
    }
}
