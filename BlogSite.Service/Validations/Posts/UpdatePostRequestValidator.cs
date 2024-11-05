using BlogSite.Models.Dtos.Posts.Requests;
using FluentValidation;

namespace BlogSite.Service.Validations.Posts;

public class UpdatePostRequestValidator : AbstractValidator<UpdatePostRequest>
{
    public UpdatePostRequestValidator()
    {

        RuleFor(x => x.Id).NotEmpty().WithMessage("Id Alanı boş olamaz.");


        RuleFor(x => x.Title).NotEmpty().WithMessage("Post Başlığı boş olamaz.")
            .MinimumLength(2).WithMessage("Post Başlığı minimum 2 Haneli olmalıdır.");

        RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik boş olamaz.")
            .MinimumLength(10).WithMessage("İçerik minimum 10 haneli olmalıdır.");
    }
}