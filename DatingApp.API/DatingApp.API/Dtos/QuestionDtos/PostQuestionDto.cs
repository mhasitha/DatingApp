using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Dtos.QuestionDtos
{
    public class PostQuestionDto
    {
        public string Heading { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
    }
}
