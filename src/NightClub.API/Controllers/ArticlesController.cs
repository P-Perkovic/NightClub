using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NightClub.API.Dtos.Article;
using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NightClub.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "IsAdmin")]
    [ApiController]
    public class ArticlesController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IArticleService _articleService;

        public ArticlesController(IMapper mapper, IArticleService articleService)
        {
            _mapper = mapper;
            _articleService = articleService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var articles = await _articleService.GetAll();
            articles = articles.OrderByDescending(a => a.PublishingDate);

            if (User.Identity.IsAuthenticated)
            {
                string userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            }

            return Ok(_mapper.Map<IEnumerable<ArticleResultDto>>(articles));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var article = await _articleService.GetById(id);

            if (article == null) return NotFound();

            return Ok(_mapper.Map<ArticleResultDto>(article));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ArticleAddDto articleDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var photoURL = articleDto.PhotoURL;

            var article = _mapper.Map<Article>(articleDto);
            article.PublishingDate = DateTime.Now;

            var articleResult = await _articleService.Add(article, photoURL);

            if (articleResult == null) return BadRequest();

            return Ok(_mapper.Map<ArticleResultDto>(articleResult));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ArticleEditDto articleDto)
        {
            if (id != articleDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var photoURL = articleDto.PhotoURL;

            var article = _mapper.Map<Article>(articleDto);
            article.PublishingDate = DateTime.Now;

            var articleResult = await _articleService.Update(article, photoURL);

            if (articleResult == null) return BadRequest();

            return Ok(_mapper.Map<ArticleResultDto>(articleResult));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var article = await _articleService.GetById(id);

            if (article == null) return BadRequest();

            var result = await _articleService.Remove(article);

            if (!result) return BadRequest();

            return Ok();
        }
    }
}
