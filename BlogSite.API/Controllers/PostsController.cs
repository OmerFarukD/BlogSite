using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Service.Abstratcts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController(IPostService _postService): ControllerBase
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
        var result = _postService.Add(dto);
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

}
