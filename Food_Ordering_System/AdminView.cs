﻿using System;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Food_Ordering_System
{
    public partial class AdminView : Form
    {
        public AdminView()
        {
            InitializeComponent();
        }

        private void page_load(object sender, EventArgs e)
        {
            try
            {
                DataTable userInformationTable = new DataTable();
                DataTable restaurantInformationTable = new DataTable();
                DataTable nUserDeliveryTable = new DataTable();
                SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TOHIR\source\repos\Food_Ordering_System\Food_Ordering_System\Database\PaantaHaariDB.mdf;Integrated Security=True;Connect Timeout=30");
                new SqlDataAdapter($"SELECT * FROM UserInfo", connect).Fill(userInformationTable);
                new SqlDataAdapter($"SELECT * FROM RestaurantInformation", connect).Fill(restaurantInformationTable);
                new SqlDataAdapter($"SELECT * FROM UserInfo WHERE user_type = 'Delivery'", connect).Fill(nUserDeliveryTable);
                userInformationGrid.DataSource = userInformationTable;
                dataGridView1.DataSource = restaurantInformationTable;
                int n_deliveryMan = nUserDeliveryTable.Rows.Count;
                int n_restaurants = restaurantInformationTable.Rows.Count;
                int n_user = userInformationTable.Rows.Count - (n_restaurants + n_deliveryMan);
                nDelivery.Text = Convert.ToString(n_deliveryMan);
                nRestaurants.Text = Convert.ToString(n_restaurants);
                nUser.Text = Convert.ToString(n_user);
                todaysDate.Text = $"{DateTime.Now.Day.ToString()}/{DateTime.Now.Month.ToString()}/{DateTime.Now.Year} {DateTime.Now.DayOfWeek}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            new LoginScreen().Show();
        }
    }
}
