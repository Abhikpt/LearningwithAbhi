using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningwithAbhi.Shared
{
    public class ProductModel
    {

        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty; 
        public double Price { get; set; }
        public string ImageUrl { get; set; } = String.Empty; 
    }

}
