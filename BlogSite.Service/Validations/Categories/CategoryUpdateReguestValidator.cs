using BlogSite.Models.Dtos.Categories.Requests;
using FluentValidation;

namespace BlogSite.Service.Validations.Categories;

public class CategoryUpdateReguestValidator : AbstractValidator<CategoryUpdateRequestDto>
{
    public CategoryUpdateReguestValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id alanı boş olamaz.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori Adı Boş olamaz.");
    }
}
