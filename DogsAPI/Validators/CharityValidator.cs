using System;
using DAL.Entities;
using FluentValidation;

namespace DogsAPI.Validators;

public class CharityValidator : AbstractValidator<Charity>
{
	public CharityValidator()
	{
		RuleFor(c => c.Amount)
			.GreaterThan(0)
			.WithMessage("Amount can not be 0");
	}
}

