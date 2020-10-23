using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace App_bachel
{
    class DbConnection
    {
        string connectionString = @"Data Source=DESKTOP-VFFBM2L\MSSQLSERVER04;
                                        Initial Catalog=Dairy;Integrated Security=True";

        public DbConnection()
        {
        }

        public DataTable GetData(string sqlQuery)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, conn);

                DataSet ds = new DataSet();

                adapter.Fill(ds);

                return ds.Tables[0];
            }
        }

        public async void Insert(string textboxValue, string tableName)
        {
            try
            {
                if (!string.IsNullOrEmpty(textboxValue) && !string.IsNullOrWhiteSpace(textboxValue))
                {
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        SqlCommand command = new SqlCommand($"INSERT INTO [{tableName}] VALUES (@namee)", sqlConnection);

                        command.Parameters.AddWithValue("namee", textboxValue);

                        await command.ExecuteNonQueryAsync();

                    }
                    MessageBox.Show("Успішно додано!", "Повідомлення!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Заповніть поле \"Namee\"!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async void Insert(string column1, string column2, string column3, string tableName)
        {
            try
            {
                if ((!string.IsNullOrEmpty(column1) && !string.IsNullOrWhiteSpace(column1)) &
                    (!string.IsNullOrEmpty(column2) && !string.IsNullOrWhiteSpace(column2)) &
                    (!string.IsNullOrEmpty(column3) && !string.IsNullOrWhiteSpace(column3)))
                {
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        SqlCommand command = new SqlCommand($"INSERT INTO [{tableName}] VALUES (@column1, @column2, @column3)", sqlConnection);

                        command.Parameters.AddWithValue("@column1", @column1);
                        command.Parameters.AddWithValue("@column2", @column2);
                        command.Parameters.AddWithValue("@column3", @column3);

                        await command.ExecuteNonQueryAsync();

                    }
                    MessageBox.Show("Успішно додано!", "Повідомлення!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Заповніть всі необхідні поля!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async void Insert(string column1, string column2, string column3, string column4, string column5, string tableName)
        {
            try
            {
                if ((!string.IsNullOrEmpty(column1) && !string.IsNullOrWhiteSpace(column1)) &
                    (!string.IsNullOrEmpty(column2) && !string.IsNullOrWhiteSpace(column2)) &
                    (!string.IsNullOrEmpty(column3) && !string.IsNullOrWhiteSpace(column3)) &
                    (!string.IsNullOrEmpty(column4) && !string.IsNullOrWhiteSpace(column4)) &
                    (!string.IsNullOrEmpty(column5) && !string.IsNullOrWhiteSpace(column5)))
                {
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        SqlCommand command = new SqlCommand($"INSERT INTO [{tableName}] VALUES (@column1, @column2, @column3, @column4, @column5)", sqlConnection);

                        command.Parameters.AddWithValue("@column1", @column1);
                        command.Parameters.AddWithValue("@column2", @column2);
                        command.Parameters.AddWithValue("@column3", @column3);
                        command.Parameters.AddWithValue("@column4", @column4);
                        command.Parameters.AddWithValue("@column5", @column5);


                        await command.ExecuteNonQueryAsync();

                    }
                    MessageBox.Show("Успішно додано!", "Повідомлення!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Заповніть всі необхідні поля!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void Update(string columnName, string columnValue, string tableName, string id)////Update table
        {
            try
            {
                if (!string.IsNullOrEmpty(columnValue) && !string.IsNullOrWhiteSpace(columnValue) &
                    (!string.IsNullOrEmpty(id) && !string.IsNullOrWhiteSpace(id)))
                {

                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        SqlCommand command = new SqlCommand($"UPDATE [{tableName}] SET [{columnName}]=@value WHERE id=@id", sqlConnection);

                        command.Parameters.AddWithValue("id", id);
                        command.Parameters.AddWithValue($"{columnName}", columnName);
                        command.Parameters.AddWithValue("value", columnValue);

                        await command.ExecuteNonQueryAsync();
                    }
                    MessageBox.Show("Успішно редаговано!", "Повідомлення!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Заповніть всі необхідні поля!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async void Update(string column1Name, string column1Value, string column2Name, string column2Value, string column3Name, string column3Value, string tableName, string id)//Update with 3 parameters
        {
            try
            {
                if ((!string.IsNullOrEmpty(column1Value) && !string.IsNullOrWhiteSpace(column1Value)) &
                    (!string.IsNullOrEmpty(column2Value) && !string.IsNullOrWhiteSpace(column2Value)) &
                    (!string.IsNullOrEmpty(column3Value) && !string.IsNullOrWhiteSpace(column3Value)))
                {
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        SqlCommand command = new SqlCommand($"UPDATE [{tableName}] SET [{column1Name}]=@value1, [{column2Name}]=@value2, [{column3Name}]=@value3 WHERE id=@id", sqlConnection);

                        command.Parameters.AddWithValue("id", id);
                        command.Parameters.AddWithValue($"{column1Name}", column1Name);
                        command.Parameters.AddWithValue($"{column2Name}", column2Name);
                        command.Parameters.AddWithValue($"{column3Name}", column3Name);
                        command.Parameters.AddWithValue("value1", column1Value);
                        command.Parameters.AddWithValue("value2", column2Value);
                        command.Parameters.AddWithValue("value3", column3Value);

                        await command.ExecuteNonQueryAsync();

                    }
                    MessageBox.Show("Успішно редаговано!", "Повідомлення!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Заповніть всі необхідні поля!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async void Update(Dictionary<string, string> keyValuePairs, string tableName)
        {
            string column1Value = keyValuePairs["GreasinessID"];
            string column2Value = keyValuePairs["TypeProductID"];
            string column3Value = keyValuePairs["MakerID"];
            string column4Value = keyValuePairs["Price"];
            string column5Value = keyValuePairs["PackagingID"];
            string id = keyValuePairs["ID"];

            try
            {
                if ((!string.IsNullOrEmpty(column1Value) && !string.IsNullOrWhiteSpace(column1Value)) &
                    (!string.IsNullOrEmpty(column2Value) && !string.IsNullOrWhiteSpace(column2Value)) &
                    (!string.IsNullOrEmpty(column3Value) && !string.IsNullOrWhiteSpace(column3Value)) &
                    (!string.IsNullOrEmpty(column4Value) && !string.IsNullOrWhiteSpace(column4Value)) &
                    (!string.IsNullOrEmpty(column5Value) && !string.IsNullOrWhiteSpace(column5Value)) &
                    (!string.IsNullOrEmpty(id) && !string.IsNullOrWhiteSpace(id)))
                {
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        SqlCommand command = new SqlCommand($"UPDATE [{tableName}] SET [GreasinessID]=@value1, [TypeProductID]=@value2, [MakerID]=@value3, [Price]=@value4, [PackagingID]=@value5 WHERE id=@id", sqlConnection);

                        command.Parameters.AddWithValue("id", id);
                        command.Parameters.AddWithValue("value1", column1Value);
                        command.Parameters.AddWithValue("value2", column2Value);
                        command.Parameters.AddWithValue("value3", column3Value);
                        command.Parameters.AddWithValue("value4", column4Value);
                        command.Parameters.AddWithValue("value5", column5Value);

                        await command.ExecuteNonQueryAsync();
                    }
                    MessageBox.Show("Успішно редаговано!", "Повідомлення!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Заповніть всі необхідні поля!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void Delete(string textboxValue, string tableName)
        {
            try
            {
                if (!string.IsNullOrEmpty(textboxValue) && !string.IsNullOrWhiteSpace(textboxValue))
                {
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        SqlCommand command = new SqlCommand($"DELETE FROM [{tableName}] WHERE [Id]=@Id", sqlConnection);
                        command.Parameters.AddWithValue("Id", textboxValue);

                        await command.ExecuteNonQueryAsync();

                    }
                    MessageBox.Show("Видалено!", "Повідомлення!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Заповніть всі необхідні поля!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
