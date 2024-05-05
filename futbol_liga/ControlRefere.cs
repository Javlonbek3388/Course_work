using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlTypes;
using System.Xml;
namespace futbol_liga
{
    internal class ControlRefere : ConnectDB
    {
        public bool insertRefere(referees refere)
        {
            int e = 0;
            sqlString = "INSERT INTO referees VALUES( '" + refere.name + "' , '" + refere.last_name + "', '" + refere.username + "','" + refere.password + "' , '" + refere.picture + "');";
            try
            {
                cmd = new SqlCommand(sqlString, conn);
                e = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (e == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable getDataRefere()
        {
            DataTable dt = new DataTable();
            sqlString = "SELECT*FROM referees;";
            try
            {
                adapter = new SqlDataAdapter(sqlString, conn);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }
        public bool deleteData(int id)
        {
            int e = 0;
            sqlString = "DELETE referees WHERE id=" + id;
            try
            {
                cmd = new SqlCommand(sqlString, conn);
                e = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (e == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool updateRefere(referees refere)
        {
            int e = 0;
            sqlString = "UPDATE referees SET name='" + refere.name + "', last_name='" + refere.last_name + "', username='" + refere.username + "', password='" + refere.password + "', picture='" + refere.picture + "' WHERE id=" + refere.id + ";";
            try
            {
                cmd = new SqlCommand(sqlString, conn);
                e = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (e == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int countXodimlar()
        {
            int soni = 0;
            DataTable dt = new DataTable();
            sqlString = "SELECT COUNT(id) AS soni FROM referees;";
            try
            {
                adapter = new SqlDataAdapter(sqlString, conn);
                adapter.Fill(dt);
                soni = int.Parse(dt.Rows[0]["soni"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return soni;
            
        }
        public class referees
        {
            public int id;
            public string name;
            public string last_name;
            public string username;
            public string password;
            public string picture;
            public referees(int id, string name, string last_name, string username, string password, string picture)
            {
                this.id = id;
                this.name = name;
                this.last_name = last_name;
                this.username = username;
                this.password = password;
                this.picture = picture;
            }
            public referees(string name, string last_name, string username, string password, string picture)
            {
                this.name = name;
                this.last_name = last_name;
                this.username = username;
                this.password = password;
                this.picture = picture;
            }
        }
    }
}
