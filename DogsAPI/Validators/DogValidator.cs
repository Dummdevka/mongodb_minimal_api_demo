using System;
using DAL.Entities;
using FluentValidation;

namespace DogsAPI.Validators;

public class DogValidator : AbstractValidator<Dog>
{
	public DogValidator() {
		RuleFor(d => d.Name)
			.NotEmpty();

		RuleFor(d => d.Breed)
			.NotEmpty();

		RuleFor(d => d.Age)
			.NotEmpty()
			.InclusiveBetween(1, 35)
			.WithMessage("Enter valid age!");

		RuleFor(d => d.Height)
			.NotEmpty()
			.InclusiveBetween(20, 250)
			.WithMessage("Enter valid height in centimeters");
	}
}

