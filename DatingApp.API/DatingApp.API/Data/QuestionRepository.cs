using DatingApp.API.Dtos.QuestionDtos;
using DatingApp.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Data
{
    public class QuestionRepository : IQuestionRepository
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
        public async Task<IEnumerable<Question>> GetAllQuestions()
        {
            var list = await _context.Questions.ToListAsync();
            return list;
        }
        public async Task<Question> GetQuestionById(int Id)
        {
            var obj = await _context.Questions.FirstOrDefaultAsync(m => m.Id == Id);
            return obj;
        }
        public async Task<Answer> PostAnswer(AnswerToPostDto answerToPostDto)
        {
            var qobj = await GetQuestionById(answerToPostDto.QuestionId);
            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == answerToPostDto.UserId);
            var ans = new Answer { Question = qobj, Solution = answerToPostDto.Solution, User = user };
            var a = _context.Answers.Add(ans);
            if(await _context.SaveChangesAsync()>0)
            {
                return ans;
            }
            return null;
        }
    }
}
