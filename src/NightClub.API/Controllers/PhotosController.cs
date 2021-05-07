using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NightClub.API.Dtos.Photo;
using NightClub.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.API.Controllers
{
    [Route("api/{articleId:int}/[controller]")]
    [ApiController]
    public class PhotosController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;

        public PhotosController(IMapper mapper, IPhotoService photoService)
        {
            _mapper = mapper;
            _photoService = photoService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(int articleId, IFormFile file)
        {
            if (file == null) return BadRequest("Null file");

            if (file.Length == 0) return BadRequest("Empty file");

            var photoResult = await _photoService.Add(articleId, file);

            if (photoResult == null) return BadRequest();

            return Ok(_mapper.Map<PhotoResultDto>(photoResult));
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int articleId)
        {
            var photo = await _photoService.GetByArticleId(articleId);

            if (photo == null) return BadRequest();

            var result = await _photoService.Remove(photo);

            if (!result) return BadRequest();

            return Ok();
        }
    }
}
     