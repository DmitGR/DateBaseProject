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
	static class DB_Sale_Query
	{
		const string connectionString = @"Data Source=SMILEX-PC\SQLEXPRESS;Initial Catalog=car_showroom;Integrated Security=True";

		public static int AddCity(string value)
		{
			// название процедуры
			string sqlExpression = "addCity";

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
					return (int)command.ExecuteScalar();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static int AddClient(Client client)
		{
			// название процедуры
			string sqlExpression = "addClient";

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
						Value = client.Value
					};
					SqlParameter City_param = new SqlParameter
					{
						ParameterName = "@city_id",
						Value = client.City.Id
					};
					SqlParameter Phone_param = new SqlParameter
					{
						ParameterName = "@phone",
						Value = client.Phone
					};
					// добавляем параметры
					command.Parameters.Add(Name_param);
					command.Parameters.Add(City_param);
					command.Parameters.Add(Phone_param);

					return (int)command.ExecuteScalar();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void AddPayment_type(string value)
		{
			// название процедуры
			string sqlExpression = "addPayment_type";

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

		public static void AddSale(Sale sale)
		{
			// название процедуры
			string sqlExpression = "addSale";

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
					SqlParameter Client_param = new SqlParameter
					{
						ParameterName = "@client_id",
						Value = sale.Client.Id
					}; SqlParameter Prod_param = new SqlParameter
					{
						ParameterName = "@product_id",
						Value = sale.Product.Value
					}; SqlParameter Paym_param = new SqlParameter
					{
						ParameterName = "@payment_type_id",
						Value = sale.Payment_type.Id
					};
					// добавляем параметры
					command.Parameters.Add(Client_param);
					command.Parameters.Add(Prod_param);
					command.Parameters.Add(Paym_param);

					var result = command.ExecuteNonQuery();

				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static List<DB_Element> GetAllPayment_types()
		{
			// название процедуры
			string sqlExpression = "getAllPayment_types";
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

		public static DataTable GetSales(string search)
		{
			// название процедуры
			string sqlExpression = "getBrandSales";
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
					SqlParameter Search = new SqlParameter
					{
						ParameterName = "@search",
						Value = search
					};
					// добавляем параметры
					command.Parameters.Add(Search);
					// Адаптер для работы с полученными данными
					SqlDataAdapter adapter = new SqlDataAdapter(command);
					// Таблица для данных
					DataTable tempTable = new DataTable();
					adapter.Fill(tempTable);
					tempTable.Columns[0].ColumnName = "VIN";
					tempTable.Columns[1].ColumnName = "Марка";
					tempTable.Columns[2].ColumnName = "Модель";
					tempTable.Columns[3].ColumnName = "Имя";
					tempTable.Columns[4].ColumnName = "Город";
					tempTable.Columns[5].ColumnName = "Телефон";
					tempTable.Columns[6].ColumnName = "Цена (руб)";
					tempTable.Columns[7].ColumnName = "Тип оплаты";

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

		public static DataTable GetTotalSum(string search)
		{
			// название процедуры
			string sqlExpression = "getBrandSum";
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
					SqlParameter Search = new SqlParameter
					{
						ParameterName = "@search",
						Value = search
					};
					// добавляем параметры
					command.Parameters.Add(Search);
					// Адаптер для работы с полученными данными
					SqlDataAdapter adapter = new SqlDataAdapter(command);
					// Таблица для данных
					DataTable tempTable = new DataTable();
					adapter.Fill(tempTable);
					tempTable.Columns[0].ColumnName = "Марка";
					tempTable.Columns[1].ColumnName = "Модель";
					tempTable.Columns[2].ColumnName = "Общая сумма (руб)";
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

		public static List<DB_Element> GetAllCities()
		{
			// название процедуры
			string sqlExpression = "getAllCities";
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

		public static List<Client> GetAllClients()
		{
			// название процедуры
			string sqlExpression = "getAllClients";
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
					List<Client> temp = new List<Client>();
					DataTable tempTable = new DataTable();
					adapter.Fill(tempTable);

					foreach (DataRow item in tempTable.Rows)
					{
						temp.Add(new Client((int)item[0], item[1].ToString(), item[3].ToString(),new DB_Element(item[2].ToString())));

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




	}
}
