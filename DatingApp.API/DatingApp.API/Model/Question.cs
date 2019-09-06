using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Model
{
    public class Question
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Resolved { get; set; }
    }
}
