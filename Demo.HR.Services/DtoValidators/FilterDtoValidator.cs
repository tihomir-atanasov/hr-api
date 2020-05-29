using Demo.HR.Models.Dtos.Request;
using FluentValidation;

namespace Demo.HR.Services.DtoValidators
{
    public class FilterDtoValidator : AbstractValidator<FilterDto>
    {
        public FilterDtoValidator()
            : base()
        {
            RuleSet("FilterDto", () =>
            {
                RuleFor(p => p.Page).NotEmpty().WithMessage("Page number is mandatory").GreaterThan(0).WithMessage("Page number must be greater than 0.");
                RuleFor(p => p.Per).NotEmpty().WithMessage("Page size is mandatory");
                RuleFor(p => p.SortDir)
                    .Must(dir =>
                        string.Equals(dir, string.Empty, System.StringComparison.InvariantCultureIgnoreCase) ||
                        string.Equals(dir, "asc", System.StringComparison.InvariantCultureIgnoreCase) ||
                        string.Equals(dir, "desc", System.StringComparison.InvariantCultureIgnoreCase))
                    .WithMessage("Sort dir can be empty, asc or desc");
            });
        }
    }
}
