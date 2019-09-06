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
        [HttpPost]
        public async Task<IActionResult> PostQuestion(PostQuestionDto questionDto)
        {
            try
            {
                var obj = _mapper.Map<Question>(questionDto);
                obj = await _questionRepository.AddQuestion(obj);
                return Ok("Question posted");
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
}