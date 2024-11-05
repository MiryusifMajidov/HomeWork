using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgrammingTask.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }  // "Userİd" yerine "UserId" olaraq dəyişdirildi
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
