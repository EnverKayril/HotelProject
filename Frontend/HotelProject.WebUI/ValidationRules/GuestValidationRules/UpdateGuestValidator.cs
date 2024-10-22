using FluentValidation;
using HotelProject.WebUI.DTOs.GuestDTO;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class UpdateGuestValidator : AbstractValidator<UpdateGuestDTO>
    {
        public UpdateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim alanı boş geçilemez");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir alanı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("İsim 3 karakterden az olamaz");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Soyisim 3 karakterden az olamaz");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("Şehir 3 karakterden az olamaz");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("İsim 20 karakterden fazla olamaz");
            RuleFor(x => x.Surname).MaximumLength(30).WithMessage("Soyisim 30 karakterden fazla olamaz");
            RuleFor(x => x.City).MaximumLength(20).WithMessage("Şehir 20 karakterden fazla olamaz");
        }
    }
}
