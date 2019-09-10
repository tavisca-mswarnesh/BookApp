using System.Linq;
using CommonModels;
using FluentValidation;
namespace BookAppServices.Controllers
{
    class BookvValidator : AbstractValidator<Book>
    {
        public BookvValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Invalid Id");
            RuleFor(x => x.Price).GreaterThan(-1).WithMessage("Invalid Price");
            RuleFor(x => x.Author).Must(AuthourValidate).WithMessage("Author name only contains characters , spaces and .");
        }
        public bool AuthourValidate(string authour)
        {
            if (!authour.All(x => char.IsLetter(x) || x == ' ' || x == '.'))
                return false;
            return true;
        }

    }
}
