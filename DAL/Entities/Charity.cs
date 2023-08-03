using System;
using DAL.Abstractions;

namespace DAL.Entities;

public class Charity : Entity
{
	public decimal Amount {
		get; set;
	}

	public string? Name {
		get; set;
	}
}

