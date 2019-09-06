using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Model
{
    public class Answer
    {
        public int Id { get; set; }
        public Question Question { get; set; }
        public string Solution { get; set; }
        public User User { get; set; }
    }
}
