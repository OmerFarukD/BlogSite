using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstratcts;
using Core.Tokens.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController(ICommentService _commentService,DecoderService _decoderService) : ControllerBase
{

    [HttpGet("getallbyuserid")]
    public IActionResult GetAllByUserId(string userId)
    {
        var result = _commentService.GetAllByUserId(userId);
        return Ok(result);
    }

    [HttpGet("owncomment")]
    public IActionResult OwnComments()
    {
        var userId = _decoderService.GetUserId();
        var result = _commentService.GetAllByUserId(userId);
        return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] CommentAddRequestDto dto)
    {
        var userId = _decoderService.GetUserId();
        var result = _commentService.Add(dto,userId);
        return Ok(result);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery] Guid id)
    {
        var result = _commentService.GetById(id);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public IActionResult Delete([FromQuery]Guid id)
    {
        var result = _commentService.Delete(id);
        return Ok(result);
    }

    [HttpGet("getallbypostid")]
    public IActionResult GetAllByPostId([FromQuery] Guid postId)
    {
        var result = _commentService.GetAllByPostId(postId);
        return Ok(result);
    }

}
