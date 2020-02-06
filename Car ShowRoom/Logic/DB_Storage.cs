using Car_ShowRoom.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_ShowRoom.DateBase
{
	class DB_Storage
	{
		public List<DB_Element> Payment_types { get; private set; }
		public List<DB_Element> Brands { get; private set; }
		public List<Model> Models { get; private set; }
		public List<DB_Element> Carcases { get; private set; }
		public List<DB_Element> Cities { get; private set; }
		public List<DB_Element> Countries { get; private set; }
		public List<DB_Element> Engine_places { get; private set; }
		public List<DB_Element> Engine_types { get; private set; }
		public List<Client> Clients { get; private set; }


		public DB_Storage()
		{
			Brands = DB_Product_Query.GetAllBrands();
			Models = DB_Product_Query.GetAllModels();
			Carcases = DB_TechData_Query.GetAllCarcases();
			Countries = DB_Product_Query.GetAllCountries();
			Engine_places = DB_TechData_Query.GetAllEngine_places();
			Engine_types = DB_TechData_Query.GetAllEngine_types();
			Cities = DB_Sale_Query.GetAllCities();
			Clients = DB_Sale_Query.GetAllClients();
			Payment_types = DB_Sale_Query.GetAllPayment_types();
		}


		public List<double> GetCapacity()
		{
			var temp = new List<double>();

			for (double i = 1.3; i < 8.5; i += 0.1)
			{
				temp.Add(Math.Round(i, 1));
			}
			return temp;
		}

		public List<int> GetDoors()
		{
			var temp = new List<int>();

			for (int i = 1; i <= 5; i ++)
			{
				temp.Add(i);
			}
			return temp;
		}

		public List<int> GetSeats()
		{
			var temp = new List<int>();

			for (int i = 1; i <= 6; i ++)
			{
				temp.Add(i);
			}
			return temp;
		}

		public List<Model> GetBrandModels(int brand_id)
		{
			return DB_Product_Query.GetBrandModels(brand_id);
		}

		public bool CheckModel(string model)
		{
			foreach (var item in Models)
			{
				if (item.Value == model)
					return false;
			}
			return true;
		}

		public bool CheckBrand(string brand)
		{
			foreach (var item in Brands)
			{
				if (item.Value == brand)
					return false;
			}
			return true;
		}

	}
}
