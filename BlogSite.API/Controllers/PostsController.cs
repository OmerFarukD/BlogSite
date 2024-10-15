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

}
