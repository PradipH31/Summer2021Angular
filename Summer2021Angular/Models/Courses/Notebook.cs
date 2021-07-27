using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Summer2021Angular.Models.Courses
{
    public class Notebook
    {
        public int NotebookId { get; set; }
        public string GithubLink { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        [NotMapped]
        public string JupyterHubLink { get; set; }
    }
}
