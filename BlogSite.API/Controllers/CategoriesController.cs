using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Service.Abstratcts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService _categoryService) : ControllerBase
{

    [HttpPost("add")]
    [Authorize(Roles ="Admin")]
    public IActionResult Add([FromBody] CategoryAddRequestDto dto)
    {
        var result = _categoryService.Add(dto);
        return Ok(result);
    }

    [HttpPut("update")]
    [Authorize(Roles = "Admin")]
    public IActionResult Update([FromBody] CategoryUpdateRequestDto dto)
    {
        var result = _categoryService.Update(dto);
        return Ok(result);
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _categoryService.GetAll();
        return Ok(result);
    }


    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery]int id)
    {
        var result = _categoryService.GetById(id);
        return Ok(result);
    }

    [HttpDelete("delete")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete([FromQuery] int id)
    {
        var result = _categoryService.Delete(id);
        return Ok(result);
    }
}

