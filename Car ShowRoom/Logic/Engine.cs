using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_ShowRoom.Logic
{
	class Engine : DB_Element
	{
		public Engine(DB_Element type, DB_Element place, float capacity)
		{
			Type = type ?? throw new ArgumentNullException(nameof(type));
			Place = place ?? throw new ArgumentNullException(nameof(place));
			Capacity = capacity;
		}

		public DB_Element Type { get; private set; }
		public DB_Element Place { get; private set; }
		public float Capacity { get; private set; }
	}
}
