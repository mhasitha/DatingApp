using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Dtos.QuestionDtos
{
    public class AnswerToPostDto
    {
        public int QuestionId { get; set; }
        public string Solution { get; set; }
        public int UserId { get; set; }
    }
}
