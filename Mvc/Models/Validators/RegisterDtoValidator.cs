using FluentValidation;
using Mvc.Models.Dtos;

namespace Mvc.Models.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(a => a.FirstName).NotNull().WithMessage("İsim boş bırakılamaz")
                .MaximumLength(20).WithMessage("İsim 20 karakterden uzun olamaz")
                .MinimumLength(2).WithMessage("Soyisim 2 karakterden kısa olamaz");

            RuleFor(a => a.LastName).NotNull().WithMessage("İsim boş bırakılamaz")
                .MaximumLength(20).WithMessage("İsim 20 karakterden uzun olamaz")
                .MinimumLength(2).WithMessage("Soyisim 2 karakterden kısa olamaz");

            RuleFor(a => a.Email).NotEmpty().WithMessage("Email boş bırakılamaz")
                     .EmailAddress().WithMessage("Geçerli bir mail adresi giriniz");

            RuleFor(a => a.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz")
                .MinimumLength(8).WithMessage("Şifre 8 karakterden kısa olamaz")
                .Matches(@"[A-Z]+").WithMessage("Şifreniz en az bir büyük karakter içermeli.")
                .Matches(@"[a-z]+").WithMessage("Şifreniz en az bir küçük karakter içermeli.")
                .Matches(@"[0-9]+").WithMessage("Şifreniz en az bir sayı içermeli.");

            RuleFor(a => a.ConfirmPassword).NotEmpty().WithMessage("Bu alan boş bırakılamaz")
                .Equal(a => a.Password).WithMessage("Bu alan şifre ile eşleşmeli");

        }
    }
}
