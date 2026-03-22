using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands
{
    public class CreateStreamerCommandValidator : AbstractValidator<StreamerCommand>
    {
        public CreateStreamerCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} no puede ser vacío.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} no puede exceder los 50 caracteres.");

            RuleFor(p => p.Url)
                .NotEmpty().WithMessage("La {Url} no puede ser vacío.");
        }
    }
}
