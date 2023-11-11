﻿using System.ComponentModel.DataAnnotations;

namespace Trif_Andrei_Lab2.Models
{
    public class Member
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        public string? Adress { get; set; }

        public string Email { get; set; }

        public string? Phone { get; set; }

        [Display(Name = "Full Name")]
        public string? FullName => $"{FirstName} {LastName}";
        
        public ICollection<Borrowing>? Borrowings { get; set; }
    }
}
