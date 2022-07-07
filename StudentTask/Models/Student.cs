using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTask.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Surname { get; set; }
        [Required]
        public int Fin { get; set; }
        public string Enterprise { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
