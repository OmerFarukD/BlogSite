using BlogSite.Models.Dtos.Posts.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Validations.Posts;

public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
{
    public CreatePostRequestValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Post Başlığı boş olamaz.")
            .MinimumLength(2).WithMessage("Post Başlığı minimum 2 Haneli olmalıdır.");

        RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik boş olamaz.")
            .MinimumLength(10).WithMessage("İçerik minimum 10 haneli olmalıdır.");
    }
}
