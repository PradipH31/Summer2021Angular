using Microsoft.AspNetCore.Mvc;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Summer2021Angular.Data;
using Summer2021Angular.Models.Courses;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Summer2021Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiscController : ControllerBase
    {
        private readonly Summer2021AngularContext _context;

        public MiscController(Summer2021AngularContext context)
        {
            _context = context;
        }

        [HttpGet("files/{courseId}")]
        public ActionResult<IEnumerable<Models.Courses.File>> GetCourseFile(int courseId)
        {
            //return await _context.File
            var results = _context.File
                .Select(f => new Models.Courses.File
                {
                    FileId = f.FileId,
                    Name = f.Name,
                    ContentType = f.ContentType,
                    CourseId = f.CourseId,
                    Content = null
                })
                .Where(i => i.CourseId == courseId);

            return results.ToList<Models.Courses.File>();
        }

        [HttpPost("githubFile")]
        public async Task<ActionResult<Models.Courses.File>> PostFromGithub(int courseid, string githubpath)
        {
            Random header = new Random();
            var client = new GitHubClient(new ProductHeaderValue(header.Next().ToString()));
            client.Credentials = new Credentials("token", AuthenticationType.Anonymous);

            var allsegments = githubpath.Split("%2F");

            var user = allsegments[0];
            var repo = allsegments[1];

            var filepath = String.Join("/", allsegments.Skip(2).Take(allsegments.Length - 2).ToArray());
            var content = await client.Repository.Content.GetRawContent(user, repo, filepath);
            string sfcontent = Convert.ToBase64String(content);
            string name = allsegments[^1];

            var contenttype = MimeMapping.MimeUtility.GetMimeMapping(filepath);

            Models.Courses.File file = new Models.Courses.File { Name = name, ContentType = contenttype, Content = sfcontent, CourseId = courseid };
            _context.File.Add(file);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFile", new { id = file.FileId }, file);
        }

        [HttpGet("notebook/{id}")]
        public async Task<ActionResult<IEnumerable<Notebook>>> GetNotebookJH(int id)
        {
            return await _context.Notebook
                .Where(n => n.CourseId == id)
                .Select(n => new Notebook()
                {
                    NotebookId = n.NotebookId,
                    GithubLink = n.GithubLink,
                    Title = n.Title,
                    Description = n.Description,
                    CourseId = n.CourseId,
                    CreatedDate = n.CreatedDate,
                    JupyterHubLink = getJupyter(n.GithubLink)
                })
                .OrderBy(n => n.CreatedDate)
                .ToListAsync();
        }
        [NonAction]
        public static string getJupyter(string link)
        {
            string Try = link.Replace("/blob/master", "");
            int direct = link.IndexOf("/blob/master/");
            string repo = Try.Substring(19, direct - 19).Replace("/", "%2F");
            string file = Try.Substring(direct + 1).Replace("/", "%2F");
            string retLink = "localhost:12000/hub/user-redirect/git-pull?repo=https:%2F%2Fgithub.com%2F" + repo + "&subPath=" + file + "&app=lab";
            return retLink;
        }
    }
}
