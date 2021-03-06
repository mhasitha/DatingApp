﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Helpers;
using DatingApp.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/users/{userId}/photos")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;
        public PhotosController(IDatingRepository repo, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _mapper = mapper;
            _repo = repo;
            _cloudinaryConfig = cloudinaryConfig;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }

        [HttpGet("{id}", Name = "GetPhoto")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var photoFromRepo = await _repo.GetPhoto(id);
            var photo = _mapper.Map<PhotoForReturnDto>(photoFromRepo);
            return Ok(photo);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotoForUser(int userId, [FromForm]PhotosForCreationDto photosForCreationDto)
        {
            try
            {
                if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                {
                    return Unauthorized();
                }
                var userFromRepo = await _repo.GetUser(userId);

                var file = photosForCreationDto.File;
                var uploadResults = new ImageUploadResult();
                if (file.Length > 0)
                {
                    using (var stream = file.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(file.Name, stream),
                            Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                        };
                        uploadResults = _cloudinary.Upload(uploadParams);
                    }
                }
                photosForCreationDto.Url = uploadResults.Uri.ToString();
                photosForCreationDto.PublicId = uploadResults.PublicId;

                var photo = _mapper.Map<Photo>(photosForCreationDto);

                if (!userFromRepo.Photos.Any(m => m.IsMain))
                    photo.IsMain = true;

                userFromRepo.Photos.Add(photo);

                if (await _repo.SaveAll())
                {
                    var photoToReturn = _mapper.Map<PhotoForReturnDto>(photo);
                    return CreatedAtRoute("GetPhoto", new { id = photo.Id }, photoToReturn);
                }

                return BadRequest("Could not add the photo");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost("{id}/setMain")]
        public async Task<IActionResult> SetMainPhoto(int userId,int id)
        {
            try
            {
                if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                    return Unauthorized();

                var user = await _repo.GetUser(userId);

                if(!user.Photos.Any(m=>m.Id==id))
                    return Unauthorized();

                var photoFromRepo = await _repo.GetPhoto(id);

                if (photoFromRepo.IsMain)
                    return BadRequest("This is already a main photo");

                var currentMainPhoto = await _repo.GetMainPhoto(userId);

                currentMainPhoto.IsMain = false;
                photoFromRepo.IsMain = true;

                if (await _repo.SaveAll())
                    return NoContent();

                return BadRequest("Could not set photo to main");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeletePhoto(int userId,int id)
        {
            try
            {
                if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                    return Unauthorized();

                var user = await _repo.GetUser(userId);

                if (!user.Photos.Any(m => m.Id == id))
                    return Unauthorized();

                var photoFromRepo = await _repo.GetPhoto(id);

                if (photoFromRepo.IsMain)
                    return BadRequest("This is a main photo");

                if (photoFromRepo.PublicId != null)
                {
                    var deleteParams = new DeletionParams(photoFromRepo.PublicId);
                    var result = _cloudinary.Destroy(deleteParams);
                    if (result.Result == "ok")
                        _repo.Delete(photoFromRepo);
                }
                else
                {
                    _repo.Delete(photoFromRepo);
                }


                if (await _repo.SaveAll())
                    return Ok();
                return BadRequest("Failed to delete the photo");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}