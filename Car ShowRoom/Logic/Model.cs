using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_ShowRoom.Logic
{
	class Model : DB_Element
	{
		public Model(int id, string value, DB_Element brand) : base(id, value)
		{
			Brand = brand ?? throw new ArgumentNullException(nameof(brand));
		}

		public Model(string value, int brand_id):base(value)
		{
			Brand = new DB_Element(brand_id);
		}

		public Model(int id, string value) : base(id, value)
		{
		}

		public DB_Element Brand { get; set; }
	}
}
