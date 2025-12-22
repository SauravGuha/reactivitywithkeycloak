

using Application.Commands.Activity;
using FluentValidation;

namespace Application.Validators.Activities
{
    public class UpdateActivityValidator : AbstractValidator<UpdateActivityRequest>
    {
        public UpdateActivityValidator()
        {
            RuleFor(r => r.ActivityCommand.Title)
                .NotEmpty().WithMessage("Title is required");
            RuleFor(r => r.ActivityCommand.Description)
                .NotEmpty().WithMessage("Description is required");
            RuleFor(r => r.ActivityCommand.Category)
                .NotEmpty().WithMessage("Category is required");
            RuleFor(r => r.ActivityCommand.City)
                .NotEmpty().WithMessage("City is required");
            RuleFor(r => r.ActivityCommand.Venue)
                .NotEmpty().WithMessage("Venue is required");
            RuleFor(a => a.ActivityCommand.EventDate)
            .Custom((dt, vc) =>
            {
                var eventDay = (int)(dt - DateTime.MinValue).TotalDays;
                var currentDay = (int)(DateTime.UtcNow - DateTime.MinValue).TotalDays;

                if (eventDay <= currentDay)
                {
                    vc.AddFailure("Event date cannot be less than or eqaul to today");
                }
            });
            RuleFor(r => r.ActivityCommand.Latitude)
                .ExclusiveBetween(-1, 91)
                .WithMessage("Invalid value for venue latitiude");
            RuleFor(r => r.ActivityCommand.Longitude)
                .ExclusiveBetween(-1, 181)
                .WithMessage("Invalid value for venue longitude");
        }
    }
}