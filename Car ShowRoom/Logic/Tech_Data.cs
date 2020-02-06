using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_ShowRoom.Logic
{
	class Tech_Data : DB_Element
	{
		public Tech_Data(DB_Element car_case, Engine engine, int doors_count, int seats_count)
		{
			Car_case = car_case ?? throw new ArgumentNullException(nameof(car_case));
			Engine = engine ?? throw new ArgumentNullException(nameof(engine));
			Doors_count = doors_count;
			Seats_count = seats_count;
		}

		public DB_Element Car_case { get; private set; }
		public Engine Engine { get; private set; }
		public int Doors_count { get; private set; }
		public int Seats_count { get; private set; }
	}
}
