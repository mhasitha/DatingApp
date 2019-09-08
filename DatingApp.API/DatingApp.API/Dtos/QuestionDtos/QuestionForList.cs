using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Dtos.QuestionDtos
{
    public class QuestionForList
    {
        public int Id { get; set; }
        public string heading { get; set; }
        public string userId { get; set; }
        public string description { get; set; }
        public DateTime createdDate { get; set; }
        public bool resolved { get; set; }
        
    }
}
