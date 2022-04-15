using FluentValidation;
using PracticalTest.Core.Dtos;

namespace PracticalTest.Service.Validators
{
    public class LoanInsertDtoValidator:AbstractValidator<LoanInsertDto>
    {
        public LoanInsertDtoValidator()
        {
            RuleFor(x => x.ClientId).InclusiveBetween(1, int.MaxValue).WithMessage("Client is required");
            RuleFor(x => x.InterestRate).InclusiveBetween(1, 100)
                .WithMessage("Interest rate is 1 between 100.");
            RuleFor(x => x.LoanPeriod).InclusiveBetween(3, 24).WithMessage("Loan period is 3 between 24.");
            RuleFor(x => x.Amount).InclusiveBetween(100, 5000).WithMessage("Amount is 100 between 5000.");
            RuleFor(x => x.PayoutDate).NotNull().WithMessage("Payout date is required").NotEmpty()
                .WithMessage("Payout date is required");

        }
    }
}