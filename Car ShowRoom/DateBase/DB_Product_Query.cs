using Car_ShowRoom.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_ShowRoom.DateBase
{
	static class DB_Product_Query
	{
		const string connectionString = @"Data Source=SMILEX-PC\SQLEXPRESS;Initial Catalog=car_showroom;Integrated Security=True";

		public static DataTable GetAllProducts()
		{
			// название процедуры
			string sqlExpression = "getAllProducts";
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					SqlCommand command = new SqlCommand(sqlExpression, connection)
					{
						// указываем, что команда представляет хранимую процедуру
						CommandType = System.Data.CommandType.StoredProcedure
					};
					// Адаптер для работы с полученными данными
					SqlDataAdapter adapter = new SqlDataAdapter(command);
					// Таблица для данных
					DataTable tempTable = new DataTable();
					adapter.Fill(tempTable);
					
					tempTable.Columns[0].ColumnName = "VIN";
					tempTable.Columns[1].ColumnName = "Марка";
					tempTable.Columns[2].ColumnName = "Модель";
					tempTable.Columns[3].ColumnName = "Тип корпуса";
					tempTable.Columns[4].ColumnName = "Кол-во дверей";
					tempTable.Columns[5].ColumnName = "Кол-во мест";
					tempTable.Columns[6].ColumnName = "Страна";
					tempTable.Columns[7].ColumnName = "Тип двигателя";
					tempTable.Columns[8].ColumnName = "Ёмкость";
					tempTable.Columns[9].ColumnName = "Расположение";
					tempTable.Columns[10].ColumnName = "Цена (руб)";
					tempTable.Columns[11].ColumnName = "В наличии";

					for (int i = 0; i < tempTable.Columns.Count; i++)
					{
						tempTable.Columns[i].ReadOnly = true;
					}

					return tempTable;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static DataTable SearchAuto(string search)
		{
			// название процедуры
			string sqlExpression = "SearchAuto";
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					SqlCommand command = new SqlCommand(sqlExpression, connection)
					{
						// указываем, что команда представляет хранимую процедуру
						CommandType = System.Data.CommandType.StoredProcedure
					};
					// параметр для ввода
					SqlParameter Search = new SqlParameter
					{
						ParameterName = "@search",
						Value = search
					};
					// добавляем параметр
					command.Parameters.Add(Search);
					// Адаптер для работы с полученными данными
					SqlDataAdapter adapter = new SqlDataAdapter(command);
					// Таблица для данных
					DataTable tempTable = new DataTable();
					adapter.Fill(tempTable);

					tempTable.Columns[0].ColumnName = "VIN";
					tempTable.Columns[1].ColumnName = "Марка";
					tempTable.Columns[2].ColumnName = "Модель";
					tempTable.Columns[3].ColumnName = "Тип корпуса";
					tempTable.Columns[4].ColumnName = "Кол-во дверей";
					tempTable.Columns[5].ColumnName = "Кол-во мест";
					tempTable.Columns[6].ColumnName = "Страна";
					tempTable.Columns[7].ColumnName = "Тип двигателя";
					tempTable.Columns[8].ColumnName = "Ёмкость";
					tempTable.Columns[9].ColumnName = "Расположение";
					tempTable.Columns[10].ColumnName = "Цена (руб)";
					tempTable.Columns[11].ColumnName = "В наличии";

					for (int i = 0; i < tempTable.Columns.Count; i++)
					{
						tempTable.Columns[i].ReadOnly = true;
					}

					return tempTable;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static List<DB_Element> GetAllBrands()
		{
			// название процедуры
			string sqlExpression = "getAllBrands";
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					SqlCommand command = new SqlCommand(sqlExpression, connection)
					{
						// указываем, что команда представляет хранимую процедуру
						CommandType = System.Data.CommandType.StoredProcedure
					};
					// Адаптер для работы с полученными данными
					SqlDataAdapter adapter = new SqlDataAdapter(command);
					// Таблица для данных
					List<DB_Element> temp = new List<DB_Element>();
					DataTable tempTable = new DataTable();
					adapter.Fill(tempTable);

					foreach (DataRow item in tempTable.Rows)
					{
						temp.Add(new DB_Element((int)item[0], item[1].ToString()));

					}

					return temp;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

		}

		public static List<DB_Element> GetAllCountries()
		{
			// название процедуры
			string sqlExpression = "getAllCountries";
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					SqlCommand command = new SqlCommand(sqlExpression, connection)
					{
						// указываем, что команда представляет хранимую процедуру
						CommandType = System.Data.CommandType.StoredProcedure
					};
					// Адаптер для работы с полученными данными
					SqlDataAdapter adapter = new SqlDataAdapter(command);
					// Таблица для данных
					List<DB_Element> temp = new List<DB_Element>();
					DataTable tempTable = new DataTable();
					adapter.Fill(tempTable);

					foreach (DataRow item in tempTable.Rows)
					{
						temp.Add(new DB_Element((int)item[0], item[1].ToString()));

					}

					return temp;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

		}

		public static List<Model> GetAllModels()
		{
			// название процедуры
			string sqlExpression = "getAllModels";
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					SqlCommand command = new SqlCommand(sqlExpression, connection)
					{
						// указываем, что команда представляет хранимую процедуру
						CommandType = System.Data.CommandType.StoredProcedure
					};
					// Адаптер для работы с полученными данными
					SqlDataAdapter adapter = new SqlDataAdapter(command);
					// Таблица для данных
					List<Model> temp = new List<Model>();
					DataTable tempTable = new DataTable();
					adapter.Fill(tempTable);

					foreach (DataRow item in tempTable.Rows)
					{
						temp.Add(new Model((int)item[0], item[2].ToString()));

					}

					return temp;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

		}
		
		public static List<Model> GetBrandModels(int brand_id)
		{
			// название процедуры
			string sqlExpression = "getBrandModels";
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					SqlCommand command = new SqlCommand(sqlExpression, connection)
					{
						// указываем, что команда представляет хранимую процедуру
						CommandType = System.Data.CommandType.StoredProcedure
					};
					// параметр для ввода
					SqlParameter param = new SqlParameter
					{
						ParameterName = "@brand_id",
						Value = brand_id
					};
					// добавляем параметр
					command.Parameters.Add(param);
					// Адаптер для работы с полученными данными
					SqlDataAdapter adapter = new SqlDataAdapter(command);
					// Таблица для данных
					List<Model> temp = new List<Model>();
					DataTable tempTable = new DataTable();
					adapter.Fill(tempTable);

					foreach (DataRow item in tempTable.Rows)
					{
						temp.Add(new Model((int)item[0], item[2].ToString()));
					}

					return temp;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

		}

		public static void AddProduct(Product product)
		{
			// название процедуры
			string sqlExpression = "addProduct";
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					SqlCommand command = new SqlCommand(sqlExpression, connection)
					{
						// указываем, что команда представляет хранимую процедуру
						CommandType = System.Data.CommandType.StoredProcedure
					};
					// параметры для ввода
					SqlParameter VIN_param = new SqlParameter
					{
						ParameterName = "@VIN",
						Value = product.Value
					};
					SqlParameter Country_param = new SqlParameter
					{
						ParameterName = "@country_id",
						Value = product.Country.Id
					};
					SqlParameter Model_param = new SqlParameter
					{
						ParameterName = "@model_id",
						Value = product.Model.Id
					};
					SqlParameter Stock_param = new SqlParameter
					{
						ParameterName = "@in_stock",
						Value = product.In_stock
					};
					SqlParameter Price_param = new SqlParameter
					{
						ParameterName = "@price",
						Value = product.Price
					};
					SqlParameter TechData_param = new SqlParameter
					{
						ParameterName = "@tech_data_id",
						Value = product.Tech_Data.Id
					};
					// добавляем параметры
					command.Parameters.Add(VIN_param);
					command.Parameters.Add(Country_param);
					command.Parameters.Add(Model_param);
					command.Parameters.Add(Stock_param);
					command.Parameters.Add(Price_param);
					command.Parameters.Add(TechData_param);

					var result = command.ExecuteNonQuery();

				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		// добавление новой Марки
		public static void AddBrand(string value)
		{
			// название процедуры
			string sqlExpression = "addBrand";

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					SqlCommand command = new SqlCommand(sqlExpression, connection)
					{
						// указываем, что команда представляет хранимую процедуру
						CommandType = System.Data.CommandType.StoredProcedure
					};
					// параметр для ввода
					SqlParameter Name_param = new SqlParameter
					{
						ParameterName = "@name",
						Value = value
					};
					// добавляем параметр
					command.Parameters.Add(Name_param);
					var result = command.ExecuteNonQuery();

				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		// добавление новой Страны
		public static void AddCountry(string value)
		{
			// название процедуры
			string sqlExpression = "addCountry";

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					SqlCommand command = new SqlCommand(sqlExpression, connection)
					{
						// указываем, что команда представляет хранимую процедуру
						CommandType = System.Data.CommandType.StoredProcedure
					};
					// параметр для ввода
					SqlParameter Name_param = new SqlParameter
					{
						ParameterName = "@name",
						Value = value
					};
					// добавляем параметр
					command.Parameters.Add(Name_param);
					var result = command.ExecuteNonQuery();

				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		// добавление новой Модели
		public static void AddModel(Model model)
		{
			// название процедуры
			string sqlExpression = "addModel";

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					SqlCommand command = new SqlCommand(sqlExpression, connection)
					{
						// указываем, что команда представляет хранимую процедуру
						CommandType = System.Data.CommandType.StoredProcedure
					};
					// параметры для ввода
					SqlParameter Name_param = new SqlParameter
					{
						ParameterName = "@name",
						Value = model.Value
					};
					SqlParameter Brand_param = new SqlParameter
					{
						ParameterName = "@brand_id",
						Value = model.Brand.Id
					};
					// добавляем параметры
					command.Parameters.Add(Name_param);
					command.Parameters.Add(Brand_param);

					var result = command.ExecuteNonQuery();

				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}
}
