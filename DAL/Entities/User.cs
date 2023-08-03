using System;
using DAL.Abstractions;

namespace DAL.Entities
{
	public class User : Entity 
	{
		public string Email {
			get; set;
		}

		public string Name {
			get; set;
		}
	}
}

