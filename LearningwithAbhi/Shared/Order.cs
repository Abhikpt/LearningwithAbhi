using System.ComponentModel.DataAnnotations;

namespace LearningwithAbhi.Shared
{
    public class Order
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Address { get; set; }
    }
}
