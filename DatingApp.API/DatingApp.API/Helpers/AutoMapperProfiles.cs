using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Dtos.QuestionDtos;
using DatingApp.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest=>dest.PhotoUrl,opt=> {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest=>dest.Age,opt=> {
                    opt.MapFrom(src => Extensions.CalculateAge(src.DateOfBirth));
                });
            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt => {
                    opt.MapFrom(src => Extensions.CalculateAge(src.DateOfBirth));
                });
            CreateMap<Photo, PhotosForDetailedDto>();
            CreateMap<UserForUpdateDto,User>();
            CreateMap<UserForRegisterDto,User>();
            CreateMap<Photo,PhotoForReturnDto>();
            CreateMap<PhotosForCreationDto,Photo>();
            CreateMap<PostQuestionDto, Question>()
                 .ForMember(o => o.User, m => m.Ignore())
                 .ForMember(o => o.Answers, m => m.Ignore())
                 .ForMember(o => o.Resolved, m => m.Ignore())
                 .ForMember(o => o.CreatedDate, m => m.Ignore());

        }

      
    }
}
