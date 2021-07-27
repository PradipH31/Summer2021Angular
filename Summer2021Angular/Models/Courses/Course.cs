using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Summer2021Angular.Models.Courses
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CourseInstructor { get; set; }
        [NotMapped]
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        public string ImageSrc { get; set; }
        //[NotMapped]
        //public virtual ICollection<Notebook> Notebooks { get; set; } = new List<Notebook>();
        //public int InfoFileId { get; set; }
        //public virtual ICollection<InfoFile> CourseFiles { get; set; } = new List<InfoFile>();
        //public virtual ICollection<Enrollment> Users { get; set; } = new List<Enrollment>();
    }
}
