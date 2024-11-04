using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Categories.Responses;
using Core.Responses;

namespace BlogSite.Service.Abstratcts;
public interface ICategoryService
{
    ReturnModel<List<CategoryResponseDto>> GetAll();
    ReturnModel<CategoryResponseDto> GetById(int id);

    ReturnModel<NoData> Add(CategoryAddRequestDto dto);
    ReturnModel<NoData> Update(CategoryUpdateRequestDto dto);
    ReturnModel<NoData> Delete(int id);
}
