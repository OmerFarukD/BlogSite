using AutoMapper;
using Azure;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Categories.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstratcts;
using Core.Exceptions;
using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Concretes;

public sealed class CategoryService(IMapper _mapper, ICategoryRepository _categoryRepository) : ICategoryService
{
    public ReturnModel<NoData> Add(CategoryAddRequestDto dto)
    {
        Category category = _mapper.Map<Category>(dto);
        _categoryRepository.Add(category);

        return new ReturnModel<NoData>
        {
            Message = "Kategori Eklendi.",
            StatusCode = 201,
            Success = true
        };
    }

    public ReturnModel<NoData> Delete(int id)
    {
        Category category = CheckById(id);
        _categoryRepository.Remove(category);

        return new ReturnModel<NoData>
        {
            Message = "Kategori Silindi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<CategoryResponseDto>> GetAll()
    {
        var categories = _categoryRepository.GetAll();
        var responses = _mapper.Map<List<CategoryResponseDto>>(categories);

        return new ReturnModel<List<CategoryResponseDto>>
        {
            Data = responses,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CategoryResponseDto> GetById(int id)
    {
        Category category = CheckById(id);

        CategoryResponseDto responseDto = _mapper.Map<CategoryResponseDto>(category);

        return new ReturnModel<CategoryResponseDto>
        {
            Data = responseDto,
            StatusCode = 200,
            Success = true,
            Message = "Kategori Getirildi."
        };
    }

    public ReturnModel<NoData> Update(CategoryUpdateRequestDto dto)
    {
        Category category = CheckById(dto.Id);
        category.Name = dto.Name;

        _categoryRepository.Update(category);

        return new ReturnModel<NoData>
        {
            Message = "Kategori Güncellendi.",
            StatusCode = 200,
            Success = true
        };

    }
    private Category CheckById(int id)
    {
        var category = _categoryRepository.GetById(id);
        if(category is null)
        {
            throw new NotFoundException("İlgili Kategori bulunamadı.");
        }

        return category;
    }
}
