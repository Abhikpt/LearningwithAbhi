using System.ComponentModel.DataAnnotations;

namespace LearningwithAbhi.Shared;
   public class Employee
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        //[Phone]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public string Department { get; set; } = string.Empty;

      //  [Range(18, 65)]
        public int Age { get; set; }

        public Address? Address { get; set; }

        public List<EmpSkill> Skills { get; set; } = new();

        public EmploymentDetails? EmploymentDetails { get; set; }

        public bool IsActive { get; set; } = true;
    }

    public class Address
    {
        [Required]
        public string Street { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string State { get; set; } = string.Empty;

        [Required, StringLength(6, MinimumLength = 5)]
        public string ZipCode { get; set; } = string.Empty;
    }

    public class EmpSkill
    {
        public string Name { get; set; } = string.Empty;
        public int ExperienceYears { get; set; }
    }

    public class EmploymentDetails
    {
        public DateTime JoiningDate { get; set; }

        [Range(10000, 1000000)]
        public decimal Salary { get; set; }

        public string JobTitle { get; set; } = string.Empty;

        public bool IsPermanent { get; set; }
    }