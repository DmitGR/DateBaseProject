using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Car_ShowRoom.Auth
{
	internal enum Type
	{
		Manager, Administrator, Guest
	}
	class User
	{
		const string connectionString = @"Data Source=SMILEX-PC\SQLEXPRESS;Initial Catalog=car_showroom;Integrated Security=True";

		Type type;
		private string login, password;

		public User(string login, string password, Type type)
		{
			Login = login;
			Password = password;
			Type = type;
		}

		public User(Type type)
		{
			Type = type;
		}

		public string Login { get => login; set => login = value; }
		public string Password { get => password; set => password = value; }
		internal Type Type { get => type; set => type = value; }

		public static Type Auth(string log, string pass)
		{
			pass = CreateMD5(pass);
			// название процедуры
			string sqlExpression = "Authorization";
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
					SqlParameter Login = new SqlParameter
					{
						ParameterName = "@login",
						Value = log
					};
					SqlParameter Pass = new SqlParameter
					{
						ParameterName = "@pass",
						Value = pass
					};
					// добавляем параметр
					command.Parameters.Add(Login);
					command.Parameters.Add(Pass);

					// Адаптер для работы с полученными данными
					SqlDataAdapter adapter = new SqlDataAdapter(command);
					// Таблица для данных
					DataTable tempTable = new DataTable();
					adapter.Fill(tempTable);
					if (tempTable.Rows.Count > 0)
						return GetType(tempTable.Rows[0][0].ToString());
					else
						return Type.Guest;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		private static Type GetType(string type)
		{
			switch (type.ToUpper())
			{
				default:
					break;
				case "A":
					return Type.Administrator;
				case "M":
					return Type.Manager;
			}
			return Type.Guest;
		}

		public override string ToString()
		{
			return Type.ToString();
		}

		private static string CreateMD5(string input)
		{
			// Use input string to calculate MD5 hash
			using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
			{
				byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
				byte[] hashBytes = md5.ComputeHash(inputBytes);

				// Convert the byte array to hexadecimal string
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < hashBytes.Length; i++)
				{
					sb.Append(hashBytes[i].ToString("X2"));
				}
				return sb.ToString();
			}
		}
	}
}
