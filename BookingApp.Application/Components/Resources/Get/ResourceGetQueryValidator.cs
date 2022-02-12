using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Components.Resources.Get
{
    public class ResourceGetQueryValidator : AbstractValidator<ResourceGetQuery>
    {
        public ResourceGetQueryValidator(IResourceService resourceService)
        {
            RuleFor(c => c.Id)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithErrorCode("1000").WithMessage("Mandatory")
               .NotEmpty().WithErrorCode("1000").WithMessage("Mandatory")
               .MustAsync(resourceService.Exists).WithErrorCode("1001").WithMessage("NotFound");
        }
    }
}
