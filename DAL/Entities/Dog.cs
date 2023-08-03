using System;
using DAL.Abstractions;

namespace DAL.Entities;

public class Dog : Entity
{
	public string Name {
		get; set;
	}

	public string Breed {
		get; set;
	}

	public int Age {
		get; set;
	}

	public float Height {
		get; set;
	}

	public bool Adopted {
		get; set;
	} = false;

	public string? DateAdopted {
		get; set;
	}
}

