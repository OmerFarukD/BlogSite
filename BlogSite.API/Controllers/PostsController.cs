using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Service.Abstratcts;
using Core.Tokens.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PostsController(IPostService _postService,DecoderService decoderService): CustomBaseController(decoderService)
{

    [HttpGet("getall")]
 
    public IActionResult GetAll()
    {
        var result = _postService.GetAll();
        return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] CreatePostRequest dto)
    {
        var userId = GetUser();
        var result = _postService.Add(dto,userId);
        return Ok(result);
    }

    [HttpGet("getbyid/{id}")]

    public IActionResult GetById([FromRoute]Guid id)
    {
        var result = _postService.GetById(id);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public IActionResult Delete([FromQuery]Guid id)
    {

        var result = _postService.Remove(id);
        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update([FromBody] UpdatePostRequest dto)
    {
        var result = _postService.Update(dto);
        return Ok(result);
    }

    [HttpGet("author")]
    public IActionResult GetAllByAuthorId([FromQuery]string authorId)
    {
        var result = _postService.GetAllByAuthorId(authorId);
        return Ok(result);
    }

}
