namespace Salon.Application.Clients.Commands.UpdateNotes
{
    using FluentValidation;

    public class UpdateClientNotesCommandValidator : AbstractValidator<UpdateClientNotesCommand>
    {
        public UpdateClientNotesCommandValidator()
        {
            this.RuleFor(c => c.Notes).MaximumLength(2000);
        }
    }
}
