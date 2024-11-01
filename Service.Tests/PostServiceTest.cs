using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Concretes;
using BlogSite.Service.Rules;
using Core.Exceptions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests;

public class PostServiceTest
{
    private PostService _postService;
    private Mock<IMapper> _mockMapper;
    private Mock<IPostRepository> _repositoryMock;
    private Mock<PostBusinessRules> _rulesMock;


    [SetUp]
    public void SetUp()
    {
        _repositoryMock = new Mock<IPostRepository>();
        _mockMapper = new Mock<IMapper>();
        _rulesMock = new Mock<PostBusinessRules>();
        _postService = new PostService(_repositoryMock.Object,_mockMapper.Object,_rulesMock.Object);
    }


    [Test]
    public void GetAll_ReturnsSuccess()
    {
        // Arange
        List<Post> posts = new List<Post>();
        List<PostResponseDto> responses = new();
        _repositoryMock.Setup(x => x.GetAll(null, true)).Returns(posts);
        _mockMapper.Setup(x => x.Map<List<PostResponseDto>>(posts)).Returns(responses);

        // Act 

        var result = _postService.GetAll();

        // Assert
        Assert.IsTrue(result.Success);
        Assert.AreEqual(responses, result.Data);
        Assert.AreEqual(200,result.StatusCode);
        Assert.AreEqual(string.Empty, result.Message);
    }

    [Test]
    public void Add_WhenProductAdded_ReturnsSuccess()
    {
        // Arange
        CreatePostRequest dto = new CreatePostRequest("Deneme","Content",1);
        Post post = new Post
        {
            Id = new Guid("{6C95E9E2-3ECE-4465-8A1D-8E38CA2BFFDC}"),
            AuthorId = "{5C95E9E2-3ECE-4465-8A1D-8E38CA2BFFDC}",
            Title = "Deneme",
            Content = "Deneme",
            CategoryId = 100,
            CreatedDate = DateTime.Now
        };

        PostResponseDto response = new PostResponseDto
        {
            Id = new Guid("{6C95E9E2-3ECE-4465-8A1D-8E38CA2BFFDC}"),
            Category = "Deneme",
            Content = "Deneme",
            CreatedDate = DateTime.Now,
            Title = "Deneme",
            UserName = "Talhişko"
        };

        _mockMapper.Setup(x => x.Map<Post>(dto)).Returns(post);
        _repositoryMock.Setup(x => x.Add(post)).Returns(post);
        _mockMapper.Setup(x=>x.Map<PostResponseDto>(post)).Returns(response);


        // Act
        var result = _postService.Add(dto, "{5C95E9E2-3ECE-4465-8A1D-8E38CA2BFFDC}");

        //Assert
        Assert.AreEqual(response, result.Data);
        Assert.IsTrue(result.Success);


    }

    [Test]
    public void GetById_WhenPostIsNotPresent_ThrowsException()
    {
        // Arange 
        Guid id = new Guid("{BA663833-98D6-4BE6-93C3-65997006B13A}");
        Post post = null;
        _rulesMock.Setup(x => x.PostIsNullCheck(post)).Throws(new NotFoundException("İlgili post bulunamadı."));




        // Assert
        Assert.Throws<NotFoundException>(() => _postService.GetById(id), "İlgili post bulunamadı.");
    }


    [Test]
    public void GetById_WhenPostIsPresent_ReturnsSuccess()
    {
        Post post = new Post
        {
            Id = new Guid("{BA663833-98D6-4BE6-93C3-65997006B13A}")
        };

        Guid id = new Guid("{BA663833-98D6-4BE6-93C3-65997006B13A}");

        PostResponseDto response = new PostResponseDto
        {
            Id = new Guid("{6C95E9E2-3ECE-4465-8A1D-8E38CA2BFFDC}"),
            Category = "Deneme",
            Content = "Deneme",
            CreatedDate = DateTime.Now,
            Title = "Deneme",
            UserName = "Talhişko"
        };

        _repositoryMock.Setup(x => x.GetById(id)).Returns(post);
        _rulesMock.Setup(x => x.PostIsNullCheck(post));
        _mockMapper.Setup(x => x.Map<PostResponseDto>(post)).Returns(response);


        var result = _postService.GetById(id);



        Assert.AreEqual(response, result.Data);
        Assert.IsTrue(result.Success);
    }
}
