using System;
namespace DogsAPI.Exceptions
{
	public class DuplicateDogException : Exception
	{
		public DuplicateDogException() {
		}

		public DuplicateDogException(string message) : base(message) {

		}

	}
}

