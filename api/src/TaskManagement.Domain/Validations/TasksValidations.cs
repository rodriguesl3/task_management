using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Validations
{
    public class TaskValidator : AbstractValidator<Task>
    {

        public TaskValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("Name is required")
                .NotEmpty()
                .WithMessage("Name is required")
                .MinimumLength(5)
                .WithMessage("Name must to be 5 character at least")
                .MaximumLength(50)
                .WithMessage("Name musto to be 50 carachters maximun");


        }


    }
}
