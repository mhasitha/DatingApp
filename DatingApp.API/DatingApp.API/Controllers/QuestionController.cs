using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.Dtos.QuestionDtos;
using DatingApp.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IConfiguration configuration, IMapper mapper, IQuestionRepository questionRepository)
        {
            _configuration = configuration;
            _mapper = mapper;
            _questionRepository = questionRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<QuestionForList>> GetQuestions()
        {
            try
            {
                var list = await _questionRepository.GetAllQuestions();
                var listDto = _mapper.Map<IEnumerable<QuestionForList>>(list);
                return listDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostQuestion(PostQuestionDto questionDto)
        {
            try
            {
                var obj = _mapper.Map<Question>(questionDto);
                obj = await _questionRepository.AddQuestion(obj);
                var objDto = _mapper.Map<QuestionForList>(obj);
                return Ok(objDto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestions(int Id)
        {
            try
            {
                var obj = await _questionRepository.GetQuestionById(Id);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("answer")]
        public async Task<IActionResult> PostAnswer(AnswerToPostDto answerToPostDto)
        {
            try
            {
                var ans = await _questionRepository.PostAnswer(answerToPostDto);
                return Ok(ans);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}