using DevExpress.XtraBars;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_bachel
{
    public partial class FluentDesignForm1 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FluentDesignForm1()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=DESKTOP-VFFBM2L\MSSQLSERVER04;
                                        Initial Catalog=Dairy;Integrated Security=True";

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage1);
            tabControl2.SelectTab(tabPage6);
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage1);
            tabControl2.SelectTab(tabPage7);
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage1);
            tabControl2.SelectTab(tabPage8);
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage1);
            tabControl2.SelectTab(tabPage9);
        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage2);
            tabControl3.SelectTab(tabPage12);
        }

        private void FluentDesignForm1_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = new DbConnection().GetData($"SELECT * FROM TypeProduct");
            dataGridView3.DataSource = new DbConnection().GetData($"SELECT * FROM Greasiness");
            dataGridView4.DataSource = new DbConnection().GetData($"SELECT Packaging.Id, TypePackaging.Namee, VolumePackaging.Valuee " +
                " FROM Packaging JOIN TypePackaging ON TypePackaging.ID = Packaging.TypePackagingID " +
                "JOIN VolumePackaging ON VolumePackaging.ID = Packaging.VolumePackagingID ");

            ShowMaker();
            ShowCheckProduct();
            ShowCheckUnique();
            RefreshSearchForm();


            using (SqlConnection sqlConnection = new SqlConnection(connectionString))//Show PriceList
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("ShowPrice", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                dataGridView5.DataSource = dt;
                sqlConnection.Close();
            }
            ShowAllSale();

            //
            ChartControl chart = new ChartControl();

            // Generate a data table and bind the chart to it.
            chart.DataSource = CreateChartData();

            // Specify data members to bind the chart's series template.
            chart.SeriesDataMember = "Month";
            chart.SeriesTemplate.ArgumentDataMember = "Section";
            chart.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Value" });

            // Specify the template's series view.
            chart.SeriesTemplate.View = new StackedBarSeriesView();

            // Specify the template's name prefix.
            chart.SeriesNameTemplate.BeginText = "Month: ";

            // Dock the chart into its parent, and add it to the current form.
            chart.Dock = DockStyle.Fill;
            this.Controls.Add(chart);

        }
        public void ShowMaker()
        {
            Thread.Sleep(1000);
            dataGridView1.DataSource = new DbConnection().GetData($"SELECT * FROM Maker");
        }

        private void simpleButton8_Click(object sender, EventArgs e)//INSERT Maker
        {
            Task task = new Task(InsertMaker);
            task.Start();
            task.Wait();

            textBox9.Text = "";
            ShowMaker();
        }
        public void InsertMaker()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Insert(textBox9.Text, "Maker");
        }

        private void simpleButton7_Click_1(object sender, EventArgs e)//UPDATE Maker
        {
            Task task = new Task(UpdateMaker);
            task.Start();
            task.Wait();

            textBox10.Text = "";
            textBox11.Text = "";

            ShowMaker();
        }
        public void UpdateMaker()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Update("Namee", textBox10.Text, "Maker", textBox11.Text);
        }



        private void simpleButton6_Click_1(object sender, EventArgs e)//DELETE Maker
        {
            Task task = new Task(DeleteMaker);
            task.Start();
            task.Wait();

            textBox12.Text = "";
            ShowMaker();
        }
        public void DeleteMaker()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Delete(textBox12.Text, "Maker");
        }
        private void simpleButton11_Click(object sender, EventArgs e)//INSERT TypeProduct
        {
            Task task = new Task(InsertTypeProduct);
            task.Start();
            task.Wait();

            textBox7.Text = "";
            dataGridView2.DataSource = new DbConnection().GetData($"SELECT * FROM TypeProduct");
        }

        public void InsertTypeProduct()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Insert(textBox7.Text, "TypeProduct");
        }


        private void simpleButton10_Click_1(object sender, EventArgs e)//UPDATE TypeProduct
        {
            Task task = new Task(UpdateTypeProduct);
            task.Start();
            task.Wait();

            textBox2.Text = "";
            textBox4.Text = "";

            dataGridView2.DataSource = new DbConnection().GetData($"SELECT * FROM TypeProduct");
        }
        public void UpdateTypeProduct()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Update("Namee", textBox2.Text, "TypeProduct", textBox4.Text);
        }


        private void simpleButton9_Click_1(object sender, EventArgs e)//DELETE TypeProduct
        {
            Task task = new Task(DeleteTypeProduct);
            task.Start();
            task.Wait();

            textBox1.Text = "";
            dataGridView2.DataSource = new DbConnection().GetData($"SELECT * FROM TypeProduct");
        }
        public void DeleteTypeProduct()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Delete(textBox1.Text, "TypeProduct");
        }
        private async void simpleButton3_Click(object sender, EventArgs e)
        {
            if (label55.Visible)
                label55.Visible = false;
            Task task = new Task(InsertPriceList);
            task.Start();
            task.Wait();

            textBox34.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";
            textBox37.Text = "";
            textBox39.Text = "";

            label55.Visible = true;
            label55.Text = "Натисніть клавішу \"Оновити\", щоб дані в таблиці оновилися.";
            await Task.Delay(4000);
            label55.Text = "";
        }

        public void InsertPriceList()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Insert(textBox34.Text, textBox35.Text, textBox36.Text, textBox37.Text, textBox39.Text, "PriceList");
        }
        private async void simpleButton4_Click_1(object sender, EventArgs e)//UPDATE PriceList
        {
            if (label55.Visible)
                label55.Visible = false;
            Task task = new Task(UpdatePriceList);
            task.Start();
            task.Wait();

            textBox23.Text = "";
            textBox32.Text = "";
            textBox31.Text = "";
            textBox30.Text = "";
            textBox22.Text = "";
            textBox33.Text = "";

            label55.Visible = true;
            label55.Text = "Натисніть клавішу \"Оновити\", щоб дані в таблиці оновилися.";
            await Task.Delay(4000);
            label55.Text = "";
        }

        public void UpdatePriceList()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>
            {
                ["ID"] = textBox23.Text,
                ["TypeProductID"] = textBox32.Text,
                ["MakerID"] = textBox31.Text,
                ["Price"] = textBox30.Text,
                ["PackagingID"] = textBox22.Text,
                ["GreasinessID"] = textBox33.Text,
            };

            DbConnection dbConnection = new DbConnection();
            dbConnection.Update(keyValuePairs, "PriceList");
        }

        private async void simpleButton5_Click_1(object sender, EventArgs e)//DELETE PriceList
        {
            if (label55.Visible)
                label55.Visible = false;
            Task task = new Task(DeletePriceList);
            task.Start();
            task.Wait();

            textBox21.Text = "";
            label55.Visible = true;
            label55.Text = "Натисніть клавішу \"Оновити\", щоб дані в таблиці оновилися.";
            await Task.Delay(4000);
            label55.Text = "";
            textBox21.Text = "";
            label55.Visible = true;
            label55.Text = "Натисніть клавішу \"Оновити\", щоб дані в таблиці оновилися.";
            await Task.Delay(4000);
            label55.Text = "";
        }
        public void DeletePriceList()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Delete(textBox21.Text, "PriceList");

        }



        private void button26_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)//Refresh PriceList
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("ShowPrice", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                dataGridView5.DataSource = dt;
                sqlConnection.Close();
            }
        }

        public void ShowCheckProduct()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("ShowCheckProduct", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                dataGridView7.DataSource = dt;
                sqlConnection.Close();
            }
        }
        public void ShowCheckUnique()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("ShowCheckUnique", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                dataGridView6.DataSource = dt;
                sqlConnection.Close();
            }
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView6.Rows[e.RowIndex];

            if (dataGridView6.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView6.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView6.Rows[selectedrowindex];
                string a = Convert.ToString(selectedRow.Cells["Id"].Value);

                int rowIndex = -1;
                try
                {
                    foreach (DataGridViewRow rows in dataGridView7.Rows)
                    {
                        if (rows.Cells[0].Value.ToString().Equals(a))
                        {
                            rowIndex = rows.Index;
                            dataGridView7.Rows[rows.Index].Selected = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                }

                dataGridView1.ClearSelection();
            }

        }

        private void accordionControlElement10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage2);
            tabControl4.SelectTab(tabPage10);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage3);
            tabControl4.SelectTab(tabPage10);
        }
        /////////////////   search form         ///////////////////////////////////////////////////////////////////////////
        public void RefreshSearchForm()
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {

                sqlConnection.Open();
                SqlCommand command = new SqlCommand("SearchProductsBy", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("TypeProduct", SqlDbType.NVarChar).Value = textBox3.Text.Trim();
                command.Parameters.AddWithValue("Maker", SqlDbType.NVarChar).Value = textBox5.Text.Trim();
                command.Parameters.AddWithValue("TypePackaging", SqlDbType.NVarChar).Value = comboBox1.Text.Trim();
                command.Parameters.AddWithValue("VolumePackaging", SqlDbType.NVarChar).Value = comboBox2.Text.Trim();
                command.Parameters.AddWithValue("Greasiness", SqlDbType.NVarChar).Value = comboBox3.Text.Trim();
                command.Parameters.AddWithValue("Price", SqlDbType.NVarChar).Value = textBox6.Text.Trim();
                command.ExecuteNonQuery();
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                dataGridView8.DataSource = dt;
                sqlConnection.Close();

            }
        }
        ////////////////////        Analyst form                              //////////////////////////////////////////////////////////////////////////
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            RefreshSearchForm();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            RefreshSearchForm();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSearchForm();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSearchForm();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSearchForm();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            RefreshSearchForm();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        public void ShowGroup()
        {
            try
            {
                string columns = "";

                if (checkBox1.Checked)
                {
                    columns += "TypeProduct.Namee, ";
                }
                if (checkBox2.Checked)
                {
                    columns += "Maker.Namee, ";
                }
                if (checkBox3.Checked)
                {
                    columns += "TypePackaging.Namee, ";
                }
                if (checkBox4.Checked)
                {
                    columns += "VolumePackaging.valuee, ";
                }
                if (checkBox5.Checked)
                {
                    columns += "Greasiness.Valuee, ";
                }
                if (!string.IsNullOrEmpty(columns) && !string.IsNullOrWhiteSpace(columns))
                {
                    int index = columns.LastIndexOf(",");

                    columns = columns.Remove(index);
                }
                string from = "Maker JOIN PriceList ON Maker.Id=PriceList.MakerID JOIN TypeProduct ON TypeProduct.Id = PriceList.TypeProductID JOIN Packaging ON Packaging.Id = PriceList.PackagingID  JOIN TypePackaging ON TypePackaging.Id = Packaging.TypePackagingID JOIN VolumePackaging ON VolumePackaging.Id = Packaging.VolumePackagingID JOIN Greasiness ON Greasiness.Id = PriceList.GreasinessID  JOIN CheckProduct ON CheckProduct.PriceListID = PriceList.Id JOIN CheckUnique ON CheckUnique.Id = CheckProduct.CheckUniqueID JOIN Affiliate ON Affiliate.Id = CheckUnique.AffiliateID";

                string query = $"SELECT {columns}, Sum(CheckProduct.Countt) as Count, SUM(PriceList.Price*CheckProduct.Countt) as Sum FROM {from} GROUP BY {columns}";
                dataGridView9.DataSource = null;
                dataGridView9.DataSource = new DbConnection().GetData(query);
            }
            catch
            {
                
            }
        }
        public void ShowAllSale()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))//ShowAllSale
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("ShowAllSale", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                dataGridView9.DataSource = dt;
                sqlConnection.Close();
            }
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;

            ShowAllSale();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ShowGroup();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ShowGroup();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            ShowGroup();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            ShowGroup();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            ShowGroup();
        }
        /// <summary>
        /// //////////////////      Form for counting sales  ///////////////////////////////////
        /// </summary>
        /// <param 
        /// 
        public async void ToFiltr()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                int count = 0;
                int sum = 0;
                sqlConnection.Open();
                SqlDataReader sqlReader = null;
                SqlCommand command;
                command = new SqlCommand("OrdersProc", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("TypeProduct", SqlDbType.NVarChar).Value = textBox15.Text.Trim();
                command.Parameters.AddWithValue("Maker", SqlDbType.NVarChar).Value = textBox14.Text.Trim();
                command.Parameters.AddWithValue("TypePackaging", SqlDbType.NVarChar).Value = comboBox6.Text.Trim();
                command.Parameters.AddWithValue("VolumePackaging", SqlDbType.NVarChar).Value = comboBox5.Text.Trim();
                command.Parameters.AddWithValue("Greasiness", SqlDbType.NVarChar).Value = comboBox4.Text.Trim();

                try
                {

                    sqlReader = await command.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        count = Convert.ToInt32(sqlReader["CountProduct"]);
                        sum = Convert.ToInt32(sqlReader["SumProduct"]);

                    }
                    textBox13.Text = Convert.ToString(count);
                    textBox8.Text = Convert.ToString(sum);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не знайдено, оберіть іншу характеристику.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();
                }

            }
        }
        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            ToFiltr();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            ToFiltr();

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToFiltr();

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToFiltr();

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToFiltr();

        }

        private void accordionControlElement12_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage2);
            tabControl3.SelectTab(tabPage11);
        }
        private DataTable CreateChartData()
        {
            // Create an empty table.
            DataTable table = new DataTable("Table1");

            // Add three columns to the table.
            table.Columns.Add("Month", typeof(String));
            table.Columns.Add("Section", typeof(String));
            table.Columns.Add("Value", typeof(Int32));

            // Add data rows to the table.
            table.Rows.Add(new object[] { "Jan", "Section1", 10 });
            table.Rows.Add(new object[] { "Jan", "Section2", 20 });
            table.Rows.Add(new object[] { "Feb", "Section1", 20 });
            table.Rows.Add(new object[] { "Feb", "Section2", 30 });
            table.Rows.Add(new object[] { "March", "Section1", 15 });
            table.Rows.Add(new object[] { "March", "Section2", 25 });

            return table;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }
    }
}
