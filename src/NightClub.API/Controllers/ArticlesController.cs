using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NightClub.API.Dtos.Article;
using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.API.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var articles = await _articleService.GetAll();

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

            var article = _mapper.Map<Article>(articleDto);
            article.PublishingDate = DateTime.Now.Date;

            var articleResult = await _articleService.Add(article);

            if (articleResult == null) return BadRequest();

            return Ok(_mapper.Map<ArticleResultDto>(articleResult));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ArticleEditDto articleDto)
        {
            if (id != articleDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var article = _mapper.Map<Article>(articleDto);
            var articleResult = await _articleService.Update(article);

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
