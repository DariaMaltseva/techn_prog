using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp_lab1
{
    public class DBProvider
    {
        private static MySqlConnection connect = null;

        public static void OpenConnection(string connectionString)
        {
            connect = new MySqlConnection(connectionString);
            connect.Open();
        }

        public static void InsertPr(List<string> param)
        {
            string sql;
            sql = "INSERT INTO `Производитель`" + " VALUES ('', @Name, @Address, @Phone, '0')";
            MySqlCommand com = new MySqlCommand(sql, connect);
            com.Parameters.AddWithValue("@Name", param[0]);
            com.Parameters.AddWithValue("@Address", param[1]);
            com.Parameters.AddWithValue("@Phone", param[2]);

            connect.Open();
            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connect.Close();
        }

        public static void InsertT(List<string> param)
        {
            string sql;
            sql = "INSERT INTO `Товар`" + " VALUES ('', @Name, @Cost, @Shelf_life, @ID_Pr, '0')";
            MySqlCommand com_it = new MySqlCommand(sql, connect);
            com_it.Parameters.AddWithValue("@Name", param[0]);
            com_it.Parameters.AddWithValue("@Cost", param[1]);
            com_it.Parameters.AddWithValue("@Shelf_life", param[2]);
            com_it.Parameters.AddWithValue("@ID_Pr", param[3]);

            connect.Open();
            try
            {
                com_it.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connect.Close();
        }

        public static void UpdatePr(List<string> param)
        {
            string sql;
            sql = "UPDATE `Производитель` SET `Наименование`=@Name, `Адрес`=@Address, `Телефон`=@Phone WHERE `Идентификатор`=@pkval";
            MySqlCommand com = new MySqlCommand(sql, connect);
            com.Parameters.AddWithValue("@Name", param[0]);
            com.Parameters.AddWithValue("@Address", param[1]);
            com.Parameters.AddWithValue("@Phone", param[2]);
            com.Parameters.AddWithValue("@pkval", param[3]);
            connect.Open();
            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connect.Close();
        }
        public static void UpdateT(List<string> param)
        {
            string sql;
            sql = "UPDATE `Товар` SET `Наименование`=@Name, `Стоимость`=@Cost, `Срок_годности`=@Shelf_life, `ИД_Производителя`=@ID_Pr WHERE `Идентификатор`=@pkval";
            MySqlCommand com_ut = new MySqlCommand(sql, connect);
            com_ut.Parameters.AddWithValue("@Name", param[0]);
            com_ut.Parameters.AddWithValue("@Cost", param[1]);
            com_ut.Parameters.AddWithValue("@Shelf_life", param[2]);
            com_ut.Parameters.AddWithValue("@ID_Pr", param[3]);
            com_ut.Parameters.AddWithValue("@pkval", param[4]);
            connect.Open();
            try
            {
                com_ut.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connect.Close();
        }
        public static void CloseConnection()
        {
            connect.Close();
        }   

        public static bool ExecuteNonQuery(string sql)
        {
            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public static DataTable ExecuteQuery(string sql)
        {
            DataTable dt = null;
            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                try
                {
                    MySqlDataReader dr = cmd.ExecuteReader();
                    dt = new DataTable();
                    dt.Load(dr);
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return dt;
        }
    }
}
