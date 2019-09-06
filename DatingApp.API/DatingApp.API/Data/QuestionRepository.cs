using DatingApp.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Data
{
    public class QuestionRepository: IQuestionRepository
    {
        private DataContext _context;
        public QuestionRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Question> AddQuestion(Question question)
        {
            _context.Questions.Add(question);
            if (await _context.SaveChangesAsync() > 0)
                return question;
            return null;
        }
    }
}
