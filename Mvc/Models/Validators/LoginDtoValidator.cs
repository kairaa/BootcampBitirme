using FluentValidation;
using Mvc.Models.Dtos;

namespace Mvc.Models.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(a => a.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz")
                .MinimumLength(8).WithMessage("Şifre 8 karakterden kısa olamaz")
                .Matches(@"[A-Z]+").WithMessage("Şifreniz en az bir büyük karakter içermeli.")
                .Matches(@"[a-z]+").WithMessage("Şifreniz en az bir küçük karakter içermeli.")
                .Matches(@"[0-9]+").WithMessage("Şifreniz en az bir sayı içermeli.");

            RuleFor(a => a.Email).NotEmpty().WithMessage("Email boş bırakılamaz")
                     .EmailAddress().WithMessage("Geçerli bir mail adresi giriniz");
        }
    }
}
