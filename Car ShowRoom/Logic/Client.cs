using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_ShowRoom.Logic
{
	class Client : DB_Element
	{
		public Client(string value, string phone, DB_Element city) : base(value)
		{
			Phone = phone;
			City = city ?? throw new ArgumentNullException(nameof(city));
		}

		public Client(int id , string value, string phone, DB_Element city) : base(id, value)
		{
			Phone = phone;
			City = city ?? throw new ArgumentNullException(nameof(city));
		}

		public Client()
		{

		}

		public DB_Element City { get; set; }
		public string Phone { get; set; }

	}
}
