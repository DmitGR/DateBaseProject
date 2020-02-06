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
	static class DB_TechData_Query
	{
		const string connectionString = @"Data Source=SMILEX-PC\SQLEXPRESS;Initial Catalog=car_showroom;Integrated Security=True";

		public static void AddCarcase(string value)
		{
			// название процедуры
			string sqlExpression = "addCarcase";

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
						ParameterName = "@type",
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

		public static void AddEngine_place(string value)
		{
			// название процедуры
			string sqlExpression = "addEngine_place";

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

		public static void AddEngine_type(string value)
		{
			// название процедуры
			string sqlExpression = "addEngine_type";

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
						ParameterName = "type",
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

		public static int AddEngine(Engine engine)
		{
			// название процедуры
			string sqlExpression = "addEngine";
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
					SqlParameter Type_param = new SqlParameter
					{
						ParameterName = "@type_id",
						Value = engine.Type.Id
					};
					// параметры для ввода
					SqlParameter Place_param = new SqlParameter
					{
						ParameterName = "@place_id",
						Value = engine.Place.Id
					};
					// параметры для ввода
					SqlParameter Capacity_param = new SqlParameter
					{
						ParameterName = "@capacity",
						Value = engine.Capacity
					};
					// добавляем параметры
					command.Parameters.Add(Type_param);
					command.Parameters.Add(Place_param);
					command.Parameters.Add(Capacity_param);

					return (int)command.ExecuteScalar();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static int AddTech_data(Tech_Data tech_Data)
		{
			// название процедуры
			string sqlExpression = "addTech_data";

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
					SqlParameter Carcase_param = new SqlParameter
					{
						ParameterName = "@cracase_id",
						Value = tech_Data.Car_case.Id
					}; SqlParameter Doors_param = new SqlParameter
					{
						ParameterName = "@doors_count",
						Value = tech_Data.Doors_count
					}; SqlParameter Seats_param = new SqlParameter
					{
						ParameterName = "@seats_count",
						Value = tech_Data.Seats_count
					}; SqlParameter Engine_param = new SqlParameter
					{
						ParameterName = "@engine_id",
						Value = tech_Data.Engine.Id
					};
					// добавляем параметр
					command.Parameters.Add(Carcase_param);
					command.Parameters.Add(Doors_param);
					command.Parameters.Add(Seats_param);
					command.Parameters.Add(Engine_param);

					return (int)command.ExecuteScalar();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static List<DB_Element> GetAllCarcases()
		{
			// название процедуры
			string sqlExpression = "getAllCarcases";
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

		public static List<DB_Element> GetAllEngine_places()
		{
			// название процедуры
			string sqlExpression = "getAllEngine_places";
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

		public static List<DB_Element> GetAllEngine_types()
		{
			// название процедуры
			string sqlExpression = "getAllEngine_types";
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



	}
}
