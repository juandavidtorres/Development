using System;

namespace POSstation.Tmex
{
	[SerializableAttribute]
	public class TmexStartSessionException : Exception
	{
		public TmexStartSessionException()
		{
		}

		public TmexStartSessionException(string message)
			: base(message)
		{
		}

		public TmexStartSessionException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}

	[SerializableAttribute]
	public class TmexVersionException : Exception
	{
		public TmexVersionException()
		{
		}

		public TmexVersionException(string message)
			: base(message)
		{
		}

		public TmexVersionException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}