using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_ShowRoom.Logic
{
	class Sale : DB_Element
	{
		public Sale(DB_Element client, DB_Element product, DB_Element payment_type)
		{
			Client = client ?? throw new ArgumentNullException(nameof(client));
			Product = product ?? throw new ArgumentNullException(nameof(product));
			Payment_type = payment_type ?? throw new ArgumentNullException(nameof(payment_type));
		}

		public DB_Element Client { get; private set; }
		public DB_Element Product { get; private set; }
		public DB_Element Payment_type { get; private set; }
	}
}
