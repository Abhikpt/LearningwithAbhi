using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningwithAbhi.Shared
{
    public partial class ResumeData
    {
        public List<Skill>? Skill { get; set; } 
        public List<Education>? Education { get; set; }
        public string Course { get; set; } = String.Empty;
        public string Discipline { get; set; } = String.Empty ;
        public string Board { get; set; } = String.Empty;
        public string Percentage { get; set; } = String.Empty;
        public long PassYear { get; set; }
    }

    public partial  class Education
    {
        public string ECourse { get; set; } = String.Empty;
        public string EDiscipline { get; set; } = String.Empty;
        public string EBoard { get; set; } = String.Empty;
        public string EPercentage { get; set; } = String.Empty;
        public long EPassYear { get; set; } 
    }

    public partial class Skill
    {
        public static string Type { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
    }
}