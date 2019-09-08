using DatingApp.API.Dtos.QuestionDtos;
using DatingApp.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Data
{
    public interface IQuestionRepository
    {
        Task<Question> AddQuestion(Question question);
        Task<IEnumerable<Question>> GetAllQuestions();
        Task<Question> GetQuestionById(int Id);
        Task<Answer> PostAnswer(AnswerToPostDto answerToPostDto);
    }
}
