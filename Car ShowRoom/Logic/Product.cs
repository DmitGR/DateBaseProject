using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_ShowRoom.Logic
{
	class Product : DB_Element
	{
		public Product(string value, DB_Element country, Engine engine, Model model, Tech_Data tech_Data, bool in_stock, decimal price) : base(value)
		{
			Country = country ?? throw new ArgumentNullException(nameof(country));
			Engine = engine ?? throw new ArgumentNullException(nameof(Engine));
			Model = model ?? throw new ArgumentNullException(nameof(model));
			Tech_Data = tech_Data ?? throw new ArgumentNullException(nameof(tech_Data));
			In_stock = in_stock;
			Price = price;
		}

		public Product(Model model, decimal price)
		{
			Model = model;
			Price = price;
		}

		public DB_Element Country { get; private set; }
		public DB_Element Engine { get; private set; }
		public bool In_stock { get; private set; }
		public decimal Price { get; private set; }
		internal Model Model { get; private set; }
		internal Tech_Data Tech_Data { get; private set; }
	}
}
