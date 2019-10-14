using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Domain.Validations
{
    public static class Extension
    {
        public static ValidationResult CheckTaskInformation(this Entities.Task task)
        {
            var validator = new TaskValidator();
            ValidationResult result = validator.Validate(task);
            return result;
        }
    }
}
