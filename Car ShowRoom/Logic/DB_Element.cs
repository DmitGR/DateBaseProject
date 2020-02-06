using System;

namespace Car_ShowRoom
{
	public class DB_Element
	{
		private string value;
		public int Id { get; set; }

		public string Value
		{
			get => value;
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException(nameof(value));
				}

				this.value = value;
			}
		}
		
		public DB_Element(int id, string value)
		{
			Id = id;
			Value = string.IsNullOrEmpty(value) ? throw new ArgumentNullException(nameof(value)) : value;
		}

		public DB_Element(int id)
		{
			Id = id;
		}

		public DB_Element(string value)
		{
			Value = string.IsNullOrEmpty(value) ? throw new ArgumentNullException(nameof(value)) : value;
		}

		public DB_Element() { }

		public override string ToString()
		{
			return value;
		}
	}
}
