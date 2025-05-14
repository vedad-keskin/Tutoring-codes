using FluentValidation;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Endpoints.StudentEndpoints;

namespace RS1_2024_25.API.Endpoints.SemesterEndpoints;
public class SemesterInsertOrUpdateValidator : AbstractValidator<SemesterInsertOrUpdateEndpoint.SemesterUpdateOrInsertRequest>
{
    public SemesterInsertOrUpdateValidator(ApplicationDbContext dbContext)
    {

        // Validacija Price
        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(50)
            .LessThanOrEqualTo(2000)
            .WithMessage("Price must be between 50 and 2000");

        //RuleFor(x => x.Price)
        //     .InclusiveBetween(50,2000)
        //     .WithMessage("Price must be between 50 and 2000");


    }
}

