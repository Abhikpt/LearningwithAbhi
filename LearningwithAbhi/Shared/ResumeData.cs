using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningwithAbhi.Shared
{
   


    public partial class ResumeData
    {
        public List<Skill> skill { get; set; }
        public List<Education> education { get; set; }
        public string Course { get; set; }
        public string Discipline { get; set; }
        public string Board { get; set; }
        public string Percentage { get; set; }
        public long PassYear { get; set; }
    }

    public partial  class Education
    {
        public string ECourse { get; set; }
        public string EDiscipline { get; set; }
        public string EBoard { get; set; }
        public string EPercentage { get; set; }
        public long EPassYear { get; set; }
    }

    public partial class Skill
    {
        public  static string   Type { get; set; }
        public string Description { get; set; }
    }
}