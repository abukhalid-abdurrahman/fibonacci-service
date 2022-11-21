using FluentValidation;
using Entity.DTO.FibonacciSubsequence;

namespace Entity.Validation;

public class FibonacciSubsequenceRequestValidator : AbstractValidator<FibonacciSubsequenceRequest> 
{
    public FibonacciSubsequenceRequestValidator()
    {
        RuleFor(request => request.FirstIndex)
            .GreaterThan(0)
            .WithMessage("FirstIndex field must be greater than 0.");
        
        RuleFor(request => request.LastIndex)
            .GreaterThan(request => request.FirstIndex)
            .WithMessage("LastIndex field must be greater than FirstIndex field value.");

        RuleFor(request => request.TimeoutInMilliseconds)
            .GreaterThan(0)
            .WithMessage("TimeoutInMilliseconds field must be greater than 0.");
    }
}
