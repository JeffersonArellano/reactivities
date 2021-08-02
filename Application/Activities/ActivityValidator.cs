﻿using Domain.Model;
using FluentValidation;

namespace Application.Activities
{
    public class ActivityValidator : AbstractValidator<ActivityModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityValidator"/> class.
        /// </summary>
        public ActivityValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Venue).NotEmpty();
        }
    }
}
