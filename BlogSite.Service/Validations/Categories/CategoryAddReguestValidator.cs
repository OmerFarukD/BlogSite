using BlogSite.Models.Dtos.Categories.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Validations.Categories;

public class CategoryAddReguestValidator : AbstractValidator<CategoryAddRequestDto>
{
    public CategoryAddReguestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori Adı Boş olamaz.");

    }
}
