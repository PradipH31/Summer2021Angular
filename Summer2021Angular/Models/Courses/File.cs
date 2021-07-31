using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Summer2021Angular.Models.Courses
{
    public class File
    {
        public int FileId { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public string Content { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
