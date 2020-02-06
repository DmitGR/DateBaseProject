using Car_ShowRoom.Auth;
using Car_ShowRoom.DateBase;
using Car_ShowRoom.Logic;
using System;
using System.Windows.Forms;

namespace Car_ShowRoom
{
	public partial class Form1 : Form
	{
		private DB_Storage DB_Storage;
		private bool City_Changed;
		private bool New_Client;
		private User user;
		public Form1()
		{
			InitializeComponent();
			City_Changed = true;
		//	groupBox7.Enabled = New_Client = false;

			Update();
			tabControl.TabPages.Remove(tabExit);

			Auth();
		}

		private void ViewProducts_Click(object sender, EventArgs e)
		{
			productsView.DataSource = DB_Product_Query.GetAllProducts();

			GridAutoSize(productsView);
		}

		private void AddProduct_Click(object sender, EventArgs e)
		{
			Engine engine = new Engine((DB_Element)comboxTypeEngine.SelectedItem, ((DB_Element)comBoxPlace.SelectedItem),
				float.Parse(comboxEngineCapacity.SelectedItem.ToString()));
			engine.Id = DB_TechData_Query.AddEngine(engine);
			Tech_Data tech_Data = new Tech_Data((DB_Element)comboxCarcase.SelectedItem, engine, (int)comboxDoors.SelectedItem,
				(int)comboxSeats.SelectedItem);
			tech_Data.Id = DB_TechData_Query.AddTech_data(tech_Data);
			Product product = new Product(InputVIN.Text, (DB_Element)comboxCountry.SelectedItem,
				engine, (Model)comboxModel.SelectedItem, tech_Data, true, decimal.Parse(InputPrice.Text));
			DB_Product_Query.AddProduct(product);
			Update();

		}

		private void SelectBrand_Click(object sender, EventArgs e)
		{
			comboxModel.DataSource = DB_Storage.GetBrandModels(((DB_Element)comboxBrand.SelectedItem).Id);
		}

		private void AddBrandBtn_Click(object sender, EventArgs e)
		{
			if (DB_Storage.CheckBrand(addBrandText.Text))
				DB_Product_Query.AddBrand(addBrandText.Text);
			Update();
		}

		private void AddModelBtn_Click(object sender, EventArgs e)
		{
			if (DB_Storage.CheckModel(addModelText.Text))
				DB_Product_Query.AddModel(new Model(addModelText.Text, ((DB_Element)addModelBrand.SelectedItem).Id));
			Update();

		}

		private void AddTypeEngineBtn_Click(object sender, EventArgs e)
		{
			DB_TechData_Query.AddEngine_type(addTypeEngineText.Text);
			Update();

		}

		private void AddCarcaseBtn_Click(object sender, EventArgs e)
		{
			DB_TechData_Query.AddCarcase(addCarecaseText.Text);
			Update();

		}

		private void AddPlaceEngineBtn_Click(object sender, EventArgs e)
		{
			DB_TechData_Query.AddEngine_place(groupBox6.Text);
			Update();

		}

		private new void Update()
		{
			DB_Storage = new DB_Storage();
			comboxEngineCapacity.DataSource = DB_Storage.GetCapacity();
			comboxDoors.DataSource = DB_Storage.GetDoors();
			comboxSeats.DataSource = DB_Storage.GetSeats();
			comboxModel.DataSource = DB_Storage.Models;
			comboxCarcase.DataSource = DB_Storage.Carcases;
			comboxCountry.DataSource = DB_Storage.Countries;
			comboxBrand.DataSource = DB_Storage.Brands;
			comboxTypeEngine.DataSource = DB_Storage.Engine_types;
			comBoxPlace.DataSource = DB_Storage.Engine_places;
			addModelBrand.DataSource = DB_Storage.Brands;
			comboxPayType.DataSource = DB_Storage.Payment_types;
			comBoxCities.DataSource = DB_Storage.Cities;
			comBoxClients.DataSource = DB_Storage.Clients;
			

			//BrandSaleSelect.DataSource = DB_Storage.Brands;
			TotalSumGridView.DataSource = DB_Sale_Query.GetTotalSum("");
			productsView.DataSource = DB_Product_Query.GetAllProducts();

		}

		private void UpdateBtn_Click(object sender, EventArgs e)
		{
			Update();
		}

		private void productsView_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
		{
			if (bool.Parse(productsView[11, e.RowIndex].Value.ToString()))
			{
				SaleItem.Text = string.Format("Продать {0} {1} {2}",
					productsView[1, e.RowIndex].Value,
					productsView[2, e.RowIndex].Value,
					productsView[0, e.RowIndex].Value);
				e.ContextMenuStrip = contextMenuStrip1;
				SaleItem.Enabled = true;

				boxVINsale.Text = productsView[0, e.RowIndex].Value.ToString();
				boxNameSale.Text = string.Format("{0} {1}",
					productsView[1, e.RowIndex].Value,
					productsView[2, e.RowIndex].Value);
				boxPriceSale.Text = productsView[10, e.RowIndex].Value.ToString();
			}
			else
			{
				SaleItem.Text = "Нет в наличии";
				e.ContextMenuStrip = contextMenuStrip1;
				SaleItem.Enabled = false;
			}
			Console.WriteLine("ECHO: " + productsView[0, e.RowIndex].Value);
		}

		private void SaleItem_Click(object sender, EventArgs e)
		{
			tabControl.SelectedIndex = tabControl.TabPages.IndexOf(tabSale);
		}

		private void DoSale(object sender, EventArgs e)
		{
			DB_Element city = new DB_Element();
			Client client = new Client();
			Sale sale;
			if (City_Changed)
			{
				city.Value = comBoxCities.Text;
				city.Id = DB_Sale_Query.AddCity(city.Value);
			}
			else
			{
				city.Id = ((DB_Element)comBoxCities.SelectedItem).Id;
				Console.WriteLine("ID::" + city.Id);
			}

			if (comBoxClients.SelectedIndex < 0)
			{
				client = new Client(comBoxClients.Text, clientPhone.Text, city);
				client.Id = DB_Sale_Query.AddClient(client);
			}
			else
			{
				client.Id = ((Client)comBoxClients.SelectedItem).Id;
			}

			sale = new Sale(client, new DB_Element(boxVINsale.Text), (DB_Element)comboxPayType.SelectedItem);

			DB_Sale_Query.AddSale(sale);

			Update();
		}

		private void ComBoxCities_Select(object sender, EventArgs e)
		{
			City_Changed = true;
			foreach (var item in DB_Storage.Cities)
			{
				if (item.Value == (comBoxCities.Text))
					City_Changed = false;
			}
		}

		private void new_client_check_CheckedChanged(object sender, EventArgs e)
		{
			New_Client = !New_Client;
			groupBox7.Enabled = New_Client;
		}

		private void comBoxClients_SelectedIndexChanged(object sender, EventArgs e)
		{
			comBoxCities.Text = ((Client)comBoxClients.SelectedItem).City.Value;
			
			clientPhone.Text = ((Client)comBoxClients.SelectedItem).Phone;
			clientPhone.ReadOnly = true;
			

		}

		private void addCountryBtn_Click(object sender, EventArgs e)
		{
			DB_Product_Query.AddCountry(addCountryText.Text);
			Update();

		}

		private void tabTotalSum_Click(object sender, EventArgs e)
		{
			TotalSumGridView.DataSource = DB_Sale_Query.GetTotalSum("");

			GridAutoSize(TotalSumGridView);
		}

		private void GridAutoSize(DataGridView gridView)
		{
			gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

			gridView.AllowUserToOrderColumns = true;
			gridView.AllowUserToResizeColumns = true;
		}

		private void tabControl_Click(object sender, EventArgs e)
		{
			GridAutoSize(TotalSumGridView);
			GridAutoSize(productsView);
			GridAutoSize(brandSaleGridView);
			if (tabControl.SelectedTab == tabExit)
				tabExit_Click();

		}

		private void InputVIN_TextChanged(object sender, EventArgs e)
		{
			Console.WriteLine("pp");
		}

		private void Auth()
		{
			//AuthList.DataSource = User.users;
			tabControl.TabPages.Remove(tabAdd);
			tabControl.TabPages.Remove(tabBrand);
			tabControl.TabPages.Remove(tabFill);
			tabControl.TabPages.Remove(tabAuto);
			tabControl.TabPages.Remove(tabSale);
			tabControl.TabPages.Remove(tabTotalSum);
			authError.Text = "";
		}

		private void BtnAuth_Click(object sender, EventArgs e)
		{
			user = new User(User.Auth(enterLogin.Text, EnterPass.Text));
			SetPermissions();
		}

		private void SetPermissions()
		{
			if (user.Type == Car_ShowRoom.Auth.Type.Guest) {
				authError.Text = "Непривальный логин или пароль";
			}
			else
			{
				switch (user.Type)
				{
					default:
						break;
					case Car_ShowRoom.Auth.Type.Administrator:
						{
							tabControl.TabPages.Remove(tabAuth);
							tabControl.TabPages.Add(tabAdd);
							tabControl.TabPages.Add(tabFill);
							tabControl.TabPages.Add(tabBrand);
							tabControl.TabPages.Add(tabTotalSum);
						}
						break;
					case Car_ShowRoom.Auth.Type.Manager:
						{
							tabControl.TabPages.Remove(tabAuth);
							tabControl.TabPages.Add(tabAuto);
							tabControl.TabPages.Add(tabSale);
						}
						break;

				}

				tabControl.TabPages.Add(tabExit);

			}
		}

		private void BtnSearchAuto_Click(object sender, EventArgs e)
		{
			productsView.DataSource = DB_Product_Query.SearchAuto(SearchWord.Text);

			GridAutoSize(productsView);

		}

		private void tabExit_Click()
		{
			Auth();
			tabControl.TabPages.Remove(tabExit);
			tabControl.TabPages.Add(tabAuth);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Console.WriteLine("SelecteIdnex: "+comBoxClients.SelectedIndex);
			Console.WriteLine("Like a Client: "+(Client)comBoxClients.SelectedItem);
			Console.WriteLine("Like a text: "+comBoxClients.Text);
		}

		private void comBoxClients_TextChanged(object sender, EventArgs e)
		{
			if (comBoxClients.SelectedIndex < 0)
			{
				//comBoxCities.Text = ((Client)comBoxClients.SelectedItem).City.Value;
				comBoxCities.DropDownStyle = ComboBoxStyle.DropDown;
				clientPhone.ReadOnly = false;
			}
		}

		private void BrandSumSearch_TextChanged(object sender, EventArgs e)
		{
			TotalSumGridView.DataSource = DB_Sale_Query.GetTotalSum(BrandSumSearch.Text);
		}

		private void SalesSearch_TextChanged(object sender, EventArgs e)
		{
			brandSaleGridView.DataSource = DB_Sale_Query.GetSales(SalesSearch.Text);
		}


	}
}