using System.ComponentModel.DataAnnotations;

namespace LearningwithAbhi.Shared
{
    public class Order
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        [Required, MaxLength(5)]
        public string? ZipCode {get;set;}


    }
}
